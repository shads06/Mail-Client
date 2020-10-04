using Mail_Client.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Mail_Client.Core;
using Mail_Client.Constants;
using Mail_Client.Helpers;

namespace Mail_Client.Managers
{

    public class ContactManager : AbstractManagerDB<Contact>
    {

        // Location of Contacts.xml file for storing contact information
        string _DataLocation = XMLDataStorage.Location + "Contacts.xml";

        public override void Add(Contact item)
        {

            try
            {

                // Read XML file and get all contacts in memory
                XDocument ContactsDocument = XDocument.Load(_DataLocation);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement ContactsRoot = ContactsDocument.Root;

                // Create a new XML element for new contact
                XElement NewContact = new XElement("Contact");

                // Set ID attribute of new contact XML element
                NewContact.SetAttributeValue("ID", item.ID.ToString());

                // Create a new XML element for new contact Name
                XElement Name = new XElement("Name");

                // Set name of the new contact
                Name.SetValue(item.Name);

                // Create a new XML element for new contact Email ID
                XElement Email = new XElement("EmailID");

                // Set EmailID of the new contact
                Email.SetValue(item.Email);

                // Create a new XML element for new contact Status
                XElement Status = new XElement("Status");

                // Set Status of the new contact
                Status.SetValue(Convert.ToInt32(Mail_Client.Constants.Status.Active));

                // Create a new XML element for new contact Created On Date
                XElement CreatedOn = new XElement("CreatedOn");

                // Set created on date for new contact in UTC Current DateTime
                CreatedOn.SetValue(DateTime.UtcNow);

                // Create a new XL element for new contact Last Updated On Date 
                // But keep it empty as this is a new contact so no date for last updated on
                XElement LastUpdatedOn = new XElement("LastUpdatedOn");

                // Add every new XML element created above for new contact into parent element of the new contact as Contact
                NewContact.Add(Name);           // Name of new contact
                NewContact.Add(Email);          // Email of new contact
                NewContact.Add(Status);         // Status of new contact
                NewContact.Add(CreatedOn);      // Created On Date of new contact
                NewContact.Add(LastUpdatedOn);  // Last Updated Date of new contact

                // Add new created Contact XML element into root element of the document
                ContactsRoot.Add(NewContact);

                // Finally, save the document back
                ContactsDocument.Save(_DataLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        public override void Delete(dynamic ItemId)
        {

            try
            {

                // Read XML file and get all contacts in memory
                XDocument ContactsDocument = XDocument.Load(_DataLocation);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement ContactsRoot = ContactsDocument.Root;

                // Get the element that has to be deleted
                XElement toBeDeletedContact =
                (from contact in ContactsRoot.Elements("Contact")
                 where contact.Attribute("ID").Value == Convert.ToString(ItemId)
                 select contact).SingleOrDefault();

                // Change the status of the contact to Deleted
                toBeDeletedContact.Element("Status").Value = Mail_Client.Constants.Status.Deleted.ToString();

                // Finally, Save the document back
                ContactsDocument.Save(_DataLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        public override void Update(Contact item)
        {

            try
            {

                // Read XML file and get all contacts in memory
                XDocument ContactsDocument = XDocument.Load(_DataLocation);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement ContactsRoot = ContactsDocument.Root;

                // Get the element that has to be updated
                XElement toBeUpdatedContact =
                (from contact in ContactsRoot.Elements("Contact")
                 where contact.Attribute("ID").Value == Convert.ToString(item.ID)
                 select contact).SingleOrDefault();

                // Set Updated Name of the Contact
                toBeUpdatedContact.Element("Name").SetValue(item.Name);

                // Set Updated Email ID of the Contact
                toBeUpdatedContact.Element("EmailID").SetValue(item.Email);

                // Set Updated Status of the Contact
                toBeUpdatedContact.Element("Status").SetValue(Convert.ToInt32(item.Status));

                // Set Last Updated On value to the current UTC time
                toBeUpdatedContact.Element("LastUpdatedOn").SetValue(DateTime.UtcNow.ToString());

                // Finally, Save the document back
                ContactsDocument.Save(_DataLocation);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        public override Contact GetSingle(dynamic ItemId)
        {

            try
            {
                Contact contact = new Contact();

                // Read XML file and get all contacts in memory
                XDocument ContactsDocument = XDocument.Load(_DataLocation);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement ContactsRoot = ContactsDocument.Root;

                // Get the single contact by it's ID
                XElement RetrievedContact =
                    (from singleContact in ContactsRoot.Elements("Contact")
                     where singleContact.Attribute("ID").Value == Convert.ToString(ItemId)
                     select singleContact).SingleOrDefault();

                if (RetrievedContact != null)
                {

                    contact.ID = Convert.ToInt32(RetrievedContact.Attribute("ID").Value);

                    contact.Name = RetrievedContact.Element("Name").Value;

                    contact.Email = RetrievedContact.Element("EmailID").Value;

                    contact.Status = (Status)Convert.ToInt32(RetrievedContact.Element("Status").Value);

                    contact.CreatedOn = Convert.ToDateTime(RetrievedContact.Element("CreatedOn").Value).ToLocalTime();

                    if(!string.IsNullOrEmpty(RetrievedContact.Element("LastUpdatedOn").Value))
                        contact.LastUpdatedOn = Convert.ToDateTime(RetrievedContact.Element("LastUpdatedOn").Value).ToLocalTime();
                    else
                        contact.LastUpdatedOn = null;

                    return contact;

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

        public override Contact GetItem(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Contact> GetAll()
        {

            List<Contact> ContactsRetrieved = new List<Contact>();

            try
            {

                // Read XML file and get all contacts in memory
                XDocument ContactsDocument = XDocument.Load(_DataLocation);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement ContactsRoot = ContactsDocument.Root;

                // Get the single contact by it's ID
                IEnumerable<XElement> RetrievedContacts =
                    (from AllContacts in ContactsRoot.Elements("Contact")
                     where XMLHelper.CheckElementActiveInActive(Convert.ToInt32(AllContacts.Element("Status").Value)) == true
                     orderby Convert.ToDateTime(AllContacts.Element("CreatedOn").Value) descending
                     select AllContacts);

                if (RetrievedContacts != null)
                {

                    foreach (var RetrievedContact in RetrievedContacts)
                    {

                        var finalContact = new Contact();

                        finalContact.ID = Convert.ToInt32(RetrievedContact.Attribute("ID").Value);

                        finalContact.Name = RetrievedContact.Element("Name").Value;

                        finalContact.Email = RetrievedContact.Element("EmailID").Value;

                        finalContact.Status = (Status)Convert.ToInt32(RetrievedContact.Element("Status").Value);

                        finalContact.CreatedOn = Convert.ToDateTime(RetrievedContact.Element("CreatedOn").Value).ToLocalTime();

                        if (!string.IsNullOrEmpty(RetrievedContact.Element("LastUpdatedOn").Value))
                            finalContact.LastUpdatedOn = Convert.ToDateTime(RetrievedContact.Element("LastUpdatedOn").Value).ToLocalTime();
                        else
                            finalContact.LastUpdatedOn = null;

                        ContactsRetrieved.Add(finalContact);

                    }

                    return ContactsRetrieved;

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

    }

}
