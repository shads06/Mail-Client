using MailClient.Core;
using MailClient.Core.Models;
using MailClient.Core.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MailClient.DAL.Managers
{
    public class MailServerRepository : IMailServerRepository
    {
        /// <summary>
        /// Parses a mail server from a line in the format:
        /// ID: {id}, Name: {name}, Description: {description}, Host: {host}, Port: {port}, Username: {username}, Password: {password}, FromAddress: {fromAddress}, IsSecured: {isSecured}, Status: {status}, Created On: {createdOn}, Last Modified On: {lastUpdatedOn}
        /// </summary>
        private MailServer ParseMailServerFromLine(string line)
        {
            try
            {
                var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                if (parts.Length < 12)
                    return null;

                var mailServer = new MailServer();

                foreach (var part in parts)
                {
                    if (part.StartsWith("ID: ") && int.TryParse(part.Substring(4), out int id))
                        mailServer.ID = id;

                    else if (part.StartsWith("Name: "))
                        mailServer.Name = part.Substring(6);

                    else if (part.StartsWith("Description: "))
                        mailServer.Description = part.Substring(13);

                    else if (part.StartsWith("Host: "))
                        mailServer.Host = part.Substring(6);

                    else if (part.StartsWith("Port: ") && int.TryParse(part.Substring(6), out int port))
                        mailServer.Port = port;

                    else if (part.StartsWith("Username: "))
                        mailServer.Username = part.Substring(10);

                    else if (part.StartsWith("Password: "))
                        mailServer.Password = part.Substring(10);

                    else if (part.StartsWith("FromAddress: "))
                        mailServer.FromAddress = part.Substring(13);

                    else if (part.StartsWith("IsSecured: ") && bool.TryParse(part.Substring(11), out bool isSecured))
                        mailServer.IsSecured = isSecured;

                    else if (part.StartsWith("Status: ") && byte.TryParse(part.Substring(8), out var status))
                        mailServer.Status = (Status)status;

                    else if (part.StartsWith("Created On: ") && DateTime.TryParse(part.Substring(12), out DateTime createdOn))
                        mailServer.CreatedOn = createdOn;

                    else if (part.StartsWith("Last Modified On: ") && DateTime.TryParse(part.Substring(18), out var lastUpdated))
                        mailServer.LastUpdatedOn = lastUpdated;
                }

                return mailServer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<MailServer> AddAsync(MailServer item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item));

                var name = (item.Name ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Mail server name is required.", nameof(item));

                if (string.IsNullOrWhiteSpace(item.Host))
                    throw new ArgumentException("Mail server host is required.", nameof(item));

                if (item.Port <= 0 || item.Port > 65535)
                    throw new ArgumentException("Mail server port must be between 1 and 65535.", nameof(item));

                var mailServersFilePath = Main.MailServersFileMainPath;

                if (!File.Exists(mailServersFilePath))
                    throw new FileNotFoundException("Mail servers file not found.", mailServersFilePath);

                // Get next ID
                var allServers = GetAllAsync().Result;
                var nextId = (allServers?.Max(s => s.ID) ?? 0) + 1;

                item.ID = nextId;
                item.CreatedOn = DateTime.UtcNow;
                item.LastUpdatedOn = null;

                // Append the mail server to the file
                using (var sw = File.AppendText(mailServersFilePath))
                {
                    sw.WriteLine(FormatMailServerLine(item));
                }

                return Task.FromResult(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<MailServer> DeleteAsync(dynamic id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException(nameof(id));

                if (!int.TryParse(id.ToString(), out int serverId))
                    throw new ArgumentException("Invalid mail server ID.", nameof(id));

                var mailServersFilePath = Main.MailServersFileMainPath;

                if (!File.Exists(mailServersFilePath))
                    throw new FileNotFoundException("Mail servers file not found.", mailServersFilePath);

                var lines = File.ReadAllLines(mailServersFilePath);
                var updatedLines = new List<string>();
                MailServer deletedServer = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        updatedLines.Add(line);
                        continue;
                    }

                    var mailServer = ParseMailServerFromLine(line);
                    if (mailServer != null && mailServer.ID == serverId)
                    {
                        mailServer.Status = Status.Deleted;
                        mailServer.LastUpdatedOn = DateTime.UtcNow;
                        updatedLines.Add(FormatMailServerLine(mailServer));
                        deletedServer = mailServer;
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }

                if (deletedServer == null)
                    throw new InvalidOperationException($"Mail server with ID {serverId} not found.");

                File.WriteAllLines(mailServersFilePath, updatedLines);

                return Task.FromResult(deletedServer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<MailServer>> GetAllAsync()
        {
            try
            {
                var mailServersFilePath = Main.MailServersFileMainPath;

                if (!File.Exists(mailServersFilePath))
                    return Task.FromResult<IEnumerable<MailServer>>(new List<MailServer>());

                var lines = File.ReadAllLines(mailServersFilePath)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                var mailServers = new List<MailServer>();

                foreach (var line in lines)
                {
                    var mailServer = ParseMailServerFromLine(line);
                    if (mailServer != null)
                        mailServers.Add(mailServer);
                }

                return Task.FromResult<IEnumerable<MailServer>>(mailServers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<MailServer> GetSingleAsync(dynamic id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException(nameof(id));

                if (!int.TryParse(id.ToString(), out int serverId))
                    throw new ArgumentException("Invalid mail server ID.", nameof(id));

                var mailServersFilePath = Main.MailServersFileMainPath;

                if (!File.Exists(mailServersFilePath))
                    throw new FileNotFoundException("Mail servers file not found.", mailServersFilePath);

                var lines = File.ReadAllLines(mailServersFilePath)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                foreach (var line in lines)
                {
                    var mailServer = ParseMailServerFromLine(line);
                    if (mailServer != null && mailServer.ID == serverId)
                        return Task.FromResult(mailServer);
                }

                throw new InvalidOperationException($"Mail server with ID {serverId} not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<MailServer> UpdateAsync(MailServer item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item));

                if (item.ID <= 0)
                    throw new ArgumentException("Mail server ID must be greater than zero.", nameof(item));

                var name = (item.Name ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Mail server name is required.", nameof(item));

                if (string.IsNullOrWhiteSpace(item.Host))
                    throw new ArgumentException("Mail server host is required.", nameof(item));

                if (item.Port <= 0 || item.Port > 65535)
                    throw new ArgumentException("Mail server port must be between 1 and 65535.", nameof(item));

                var mailServersFilePath = Main.MailServersFileMainPath;

                if (!File.Exists(mailServersFilePath))
                    throw new FileNotFoundException("Mail servers file not found.", mailServersFilePath);

                var lines = File.ReadAllLines(mailServersFilePath);
                var updatedLines = new List<string>();
                MailServer updatedServer = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        updatedLines.Add(line);
                        continue;
                    }

                    var mailServer = ParseMailServerFromLine(line);
                    if (mailServer != null && mailServer.ID == item.ID)
                    {
                        mailServer.Name = name;
                        mailServer.Description = item.Description;
                        mailServer.Host = item.Host;
                        mailServer.Port = item.Port;
                        mailServer.Username = item.Username;
                        mailServer.Password = item.Password;
                        mailServer.FromAddress = item.FromAddress;
                        mailServer.IsSecured = item.IsSecured;
                        mailServer.Status = item.Status;
                        mailServer.LastUpdatedOn = DateTime.UtcNow;

                        updatedLines.Add(FormatMailServerLine(mailServer));
                        updatedServer = mailServer;
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }

                if (updatedServer == null)
                    throw new InvalidOperationException($"Mail server with ID {item.ID} not found.");

                File.WriteAllLines(mailServersFilePath, updatedLines);

                return Task.FromResult(updatedServer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Formats a mail server object into a text line.
        /// Format: ID: {id}, Name: {name}, Description: {description}, Host: {host}, Port: {port}, Username: {username}, Password: {password}, FromAddress: {fromAddress}, IsSecured: {isSecured}, Status: {status}, Created On: {createdOn}, Last Modified On: {lastUpdatedOn}
        /// </summary>
        private string FormatMailServerLine(MailServer server)
        {
            return $"ID: {server.ID}, Name: {server.Name}, Description: {server.Description}, Host: {server.Host}, Port: {server.Port}, Username: {server.Username}, Password: {server.Password}, FromAddress: {server.FromAddress}, IsSecured: {server.IsSecured}, Status: {(int)server.Status}, Created On: {server.CreatedOn}, Last Modified On: {server.LastUpdatedOn}";
        }
    }
}
