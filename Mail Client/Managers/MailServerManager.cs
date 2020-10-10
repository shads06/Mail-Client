using Mail_Client.Core;
using Mail_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Mail_Client.Constants;
using Mail_Client.Helpers;

namespace Mail_Client.Managers
{
    public class MailServerManager : AbstractManagerDB<MailServer>
    {

        private string _mailServerXMLDataStorageLocation = XMLDataStorage.Location + "MailServers.xml";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(MailServer item)
        {

            try
            {

                XDocument MailServersDocument = XDocument.Load(_mailServerXMLDataStorageLocation);

                XElement RootMailServers = MailServersDocument.Root;

                XElement Server = new XElement("Server");
                Server.SetAttributeValue("ID", item.ID);

                XElement Name = new XElement("Name");

                Name.Value = item.Name;

                XElement Description = new XElement("Description");

                Description.Value = item.Description;

                XElement Host = new XElement("Host");

                Host.Value = item.Host;

                XElement Port = new XElement("Port");

                Port.Value = item.Port.ToString();

                XElement Username = new XElement("Username");

                Username.Value = item.Username;

                XElement Password = new XElement("Password");

                Password.Value = item.Password;

                XElement FromAddress = new XElement("FromAddress");

                FromAddress.Value = item.FromAddress;

                XElement IsSecured = new XElement("IsSecured");

                IsSecured.SetValue(Convert.ToInt32(item.IsSecured));

                XElement Status = new XElement("Status");

                Status.SetValue(Convert.ToInt32(Mail_Client.Constants.Status.Active));

                XElement CreatedOn = new XElement("CreatedOn");

                CreatedOn.SetValue(DateTime.UtcNow);

                XElement LastUpdatedOn = new XElement("LastUpdatedOn");

                Server.Add(Name);
                Server.Add(Description);
                Server.Add(Host);
                Server.Add(Port);
                Server.Add(Username);
                Server.Add(Password);
                Server.Add(FromAddress);
                Server.Add(IsSecured);
                Server.Add(Status);
                Server.Add(CreatedOn);
                Server.Add(LastUpdatedOn);

                RootMailServers.Add(Server);

                MailServersDocument.Save(_mailServerXMLDataStorageLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Update(MailServer item)
        {

            try
            {

                XDocument MailServersDocument = XDocument.Load(_mailServerXMLDataStorageLocation);

                XElement RootMailServers = MailServersDocument.Root;

                XElement SelectedElement =
                    (from selectedMailServer in RootMailServers.Elements("Server")
                     where Convert.ToInt32(selectedMailServer.Attribute("ID").Value) == item.ID
                     select selectedMailServer).SingleOrDefault();

                SelectedElement.Element("Name").Value = item.Name;

                SelectedElement.Element("Description").Value = item.Description;

                SelectedElement.Element("Host").Value = item.Host;

                SelectedElement.Element("Port").Value = item.Port.ToString();

                SelectedElement.Element("Username").Value = item.Username;

                SelectedElement.Element("Password").Value = item.Password;

                SelectedElement.Element("FromAddress").Value = item.FromAddress;

                SelectedElement.Element("IsSecured").SetValue(Convert.ToInt32(item.IsSecured));

                SelectedElement.Element("Status").SetValue(Convert.ToInt32(item.Status));

                SelectedElement.Element("LastUpdatedOn").Value = DateTime.UtcNow.ToString();

                MailServersDocument.Save(_mailServerXMLDataStorageLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemId"></param>
        public override void Delete(dynamic ItemId)
        {

            try
            {

                XDocument MailServersDocument = XDocument.Load(_mailServerXMLDataStorageLocation);

                XElement RootMailServers = MailServersDocument.Root;

                XElement SelectedElement =
                    (from selectedMailServer in RootMailServers.Elements("Server")
                     where Convert.ToInt32(selectedMailServer.Attribute("ID").Value) == ItemId
                     select selectedMailServer).SingleOrDefault();

                SelectedElement.Element("Status").SetValue(Convert.ToInt32(Mail_Client.Constants.Status.Deleted));

                SelectedElement.Element("LastUpdatedOn").Value = DateTime.UtcNow.ToString();

                MailServersDocument.Save(_mailServerXMLDataStorageLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        public override MailServer GetSingle(dynamic ItemId)
        {

            MailServer mailServer = new MailServer();

            try
            {

                XDocument MailServerDocument = XDocument.Load(_mailServerXMLDataStorageLocation);

                XElement RootMailServers = MailServerDocument.Root;

                XElement SelectedElement =
                    (from SelectedMailServer in RootMailServers.Elements("Server")
                     where Convert.ToInt32(SelectedMailServer.Attribute("ID").Value) == ItemId
                     select SelectedMailServer).SingleOrDefault();

                if (SelectedElement != null)
                {

                    mailServer.ID = Convert.ToInt32(SelectedElement.Attribute("ID").Value);

                    mailServer.Name = SelectedElement.Element("Name").Value;

                    mailServer.Description = SelectedElement.Element("Description").Value;

                    mailServer.Host = SelectedElement.Element("Host").Value;

                    mailServer.Port = Convert.ToInt32(SelectedElement.Element("Port").Value);

                    mailServer.Username = SelectedElement.Element("Username").Value;

                    mailServer.Password = SelectedElement.Element("Password").Value;

                    mailServer.FromAddress = SelectedElement.Element("FromAddress").Value;

                    mailServer.IsSecured = Convert.ToBoolean(Convert.ToInt32(SelectedElement.Element("IsSecured").Value));

                    mailServer.Status = (Status)Convert.ToInt32(SelectedElement.Element("Status").Value);

                    mailServer.CreatedOn = Convert.ToDateTime(SelectedElement.Element("CreatedOn").Value).ToLocalTime();

                    if (!string.IsNullOrEmpty(SelectedElement.Element("LastUpdatedOn").Value)) mailServer.LastUpdatedOn = Convert.ToDateTime(SelectedElement.Element("LastUpdatedOn").Value).ToLocalTime();
                    else mailServer.LastUpdatedOn = null;

                    return mailServer;

                }
                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<MailServer> GetAll()
        {
            
            List<MailServer> mailServers = new List<MailServer>();

            try
            {

                XDocument MailServerDocument = XDocument.Load(_mailServerXMLDataStorageLocation);

                XElement RootMailServers = MailServerDocument.Root;

                IEnumerable<XElement> SelectedServers =
                    (from AllMailServers in RootMailServers.Elements("Server")
                     where XMLHelper.CheckElementActiveInActive(Convert.ToInt32(AllMailServers.Element("Status").Value)) == true
                     orderby Convert.ToDateTime(AllMailServers.Element("CreatedOn").Value) descending
                     select AllMailServers);

                if (SelectedServers != null)
                {

                    foreach (var SingleMailServer in SelectedServers)
                    {

                        MailServer mailServer = new MailServer();

                        mailServer.ID = Convert.ToInt32(SingleMailServer.Attribute("ID").Value);

                        mailServer.Name = SingleMailServer.Element("Name").Value;

                        mailServer.Description = SingleMailServer.Element("Description").Value;

                        mailServer.Host = SingleMailServer.Element("Host").Value;

                        mailServer.Port = Convert.ToInt32(SingleMailServer.Element("Port").Value);

                        mailServer.Username = SingleMailServer.Element("Username").Value;

                        mailServer.Password = SingleMailServer.Element("Password").Value;

                        mailServer.FromAddress = SingleMailServer.Element("FromAddress").Value;

                        mailServer.IsSecured = Convert.ToBoolean(Convert.ToInt32(SingleMailServer.Element("IsSecured").Value));

                        mailServer.Status = (Status)Convert.ToInt32(SingleMailServer.Element("Status").Value);

                        mailServer.CreatedOn = Convert.ToDateTime(SingleMailServer.Element("CreatedOn").Value).ToLocalTime();

                        if (!string.IsNullOrEmpty(SingleMailServer.Element("LastUpdatedOn").Value)) mailServer.LastUpdatedOn = Convert.ToDateTime(SingleMailServer.Element("LastUpdatedOn").Value).ToLocalTime();
                        else mailServer.LastUpdatedOn = null;

                        mailServers.Add(mailServer);

                    }

                    return mailServers;

                }
                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override MailServer GetItem(System.Data.IDataReader reader)
        {
            throw new NotImplementedException();
        }

    }
}
