using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using Mail_Client.Constants;

namespace Mail_Client.Helpers
{
    public class XMLHelper
    {

        public int LastElementUniqueID(string location, string ChildName)
        {

            try
            {

                // Read XML file and get all contacts in memory
                XDocument MainDocument = XDocument.Load(location);

                // Get the root (Contacts) of the document to add new contact with existing ones
                XElement DocumentRoot = MainDocument.Root;

                // Get all the items using LINQ and find the max ID or last ID assigned to element
                //var lastUniqueID =
                //    (from selectItems in DocumentRoot.Elements(ChildName)
                //     orderby Convert.ToInt32(selectItems.Attribute("ID").Value) descending
                //     select selectItems).Max();

                if (DocumentRoot.HasElements)
                {
                    XElement node = DocumentRoot.Element(ChildName);

                    if (node != null)
                    {
                        
                        var lastUniqueID =
                            (DocumentRoot.Elements(ChildName)
                            .Max(item => (int)item.Attribute("ID")));

                        return lastUniqueID;

                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    return 0;
                }

                //var maxID = Convert.ToInt32(lastUniqueID.Attribute("ID").Value);

            }
            catch (Exception ex)
            {

                throw;

            }

        }

        public static bool CheckElementActiveInActive(int StatusInInteger)
        {

            try
            {

                if (StatusInInteger == (int)Status.Active || StatusInInteger == (int)Status.InActive)
                    return true;
                else
                    return false;
                
            }
            catch (Exception ex)
            {

                throw;

            }

        }

    }
}
