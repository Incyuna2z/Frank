using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace EF_Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryContacts();
        }

        private static void QueryContacts()
        {
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = context.Contacts;
            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1}", contact.FirstName, contact.LastName);
            //    }
            //}

            //Querying with LINQ to Entities
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from a in context.Contacts where a.FirstName == "Robert" select a;
            //    Console.WriteLine("{0} {1}", contacts.FirstOrDefault<Contact>().FirstName, contacts.FirstOrDefault<Contact>().LastName);
            //}

            ////Querying with Object Services and Entity SQL
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var queryString = "SELECT VALUE b " + "FROM PROGRAMMINGEFDB1Entities.Contacts AS b " + "Where b.FirstName='Robert'";
            //    ObjectQuery<Contact> contacts = context.CreateQuery<Contact>(queryString);
            //}

            //LINQ to Entity with projection, anonymous type
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from c in context.Contacts where c.FirstName == "Robert" select new { c.Title, c.FirstName, c.LastName };

            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1} {2}", contact.Title, contact.FirstName, contact.LastName);
            //    }
            //}


            //LINQ to Entity with projection, anonymous type
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from c in context.Contacts where c.FirstName == "Robert" let foo = new { c.Title, c.FirstName, c.LastName } select foo;

            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1} {2}", contact.Title, contact.FirstName, contact.LastName);
            //    }
            //}

            using (var context = new PROGRAMMINGEFDB1Entities())
            {
                var contacts = from c in context.Contacts where c.FirstName == "Robert" let foo = new { ContactName = new { c.Title, c.FirstName, c.LastName }, c.Addresses } orderby foo.ContactName.FirstName select foo;

                foreach (var contact in contacts)
                {
                    var name = contact.ContactName;
                    Console.WriteLine("{0} {1} {2}: Address {3}", name.Title.Trim(), name.FirstName.Trim(), name.LastName.Trim(), contact.Addresses.Count);
                }
            }

            Console.ReadLine(); 


        }
    }
}
