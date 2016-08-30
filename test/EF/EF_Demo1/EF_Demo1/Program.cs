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
            //Sample 1: using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = context.Contacts;
            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1}", contact.FirstName, contact.LastName);
            //    }
            //}

            //Sample 2:Querying with LINQ to Entities
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from a in context.Contacts where a.FirstName == "Robert" select a;
            //    Console.WriteLine("{0} {1}", contacts.FirstOrDefault<Contact>().FirstName, contacts.FirstOrDefault<Contact>().LastName);
            //}

            //Sample 3:Querying with Object Services and Entity SQL
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var queryString = "SELECT VALUE b " + "FROM PROGRAMMINGEFDB1Entities.Contacts AS b " + "Where b.FirstName='Robert'";
            //    ObjectQuery<Contact> contacts = context.CreateQuery<Contact>(queryString);
            //}

            //Sample 4:LINQ to Entity with projection, anonymous type
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from c in context.Contacts where c.FirstName == "Robert" select new { c.Title, c.FirstName, c.LastName };

            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1} {2}", contact.Title, contact.FirstName, contact.LastName);
            //    }
            //}


            //Sample 5:LINQ to Entity with projection, anonymous type
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from c in context.Contacts where c.FirstName == "Robert" let foo = new { c.Title, c.FirstName, c.LastName } select foo;

            //    foreach (var contact in contacts)
            //    {
            //        Console.WriteLine("{0} {1} {2}", contact.Title, contact.FirstName, contact.LastName);
            //    }
            //}

            //Sample 6:LINAQ to Entity, anonyouus type as a property
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from c in context.Contacts where c.FirstName == "Robert" let foo = new { ContactName = new { c.Title, c.FirstName, c.LastName }, c.Addresses } orderby foo.ContactName.FirstName select foo;

            //    foreach (var contact in contacts)
            //    {
            //        var name = contact.ContactName;
            //        Console.WriteLine("{0} {1} {2}: Address {3}", name.Title.Trim(), name.FirstName.Trim(), name.LastName.Trim(), contact.Addresses.Count);
            //    }
            //}

            //Sample 7:LINAQ to Entity, Navigation
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var addresses = from n in context.Addresses where n.CountryRegion =="UK" select new{n,n.Contact};
            //    foreach (var address in addresses)
            //    {                    
            //        Console.WriteLine("{0} {1} {2}", address.Contact.LastName,address.n.Street1,address.n.City);
            //    }
            //}

            //Sample 8:Navigation, Filtering and Sorting with an entityreference
            //using (var context=new PROGRAMMINGEFDB1Entities())
            //{
            //    var addresses=from n in context.Addresses where n.Contact.AddDate > new System.DateTime(2000,1,1) select new {n.Contact.LastName,n};

            //    foreach(var address in  addresses)
            //    {
            //        Console.WriteLine("{0} {1} {2}", address.LastName, address.n.ContactID, address.n.addressID);
            //    }
            //}

            //Sample 9:Navigation to Entity Collections
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts = from a in context.Contacts where a.FirstName == "Donna" select new { a, a.Addresses };

            //    foreach(var contact in contacts)
            //    {
            //        //Console.WriteLine("{0} {1}", contact.a.FirstName, contact.a.Addresses.Count);
            //        foreach(var address in contact.a.Addresses)
            //        {
            //            Console.WriteLine("{0}",address.City);
            //        }
            //    }
            //}

            //Sample 10: Navigation to Entity Collections, projecting properties from entityCollection entities
            //using (var context=new PROGRAMMINGEFDB1Entities())
            //{
            //    var contacts=from a in context.Contacts where a.FirstName.Equals("Donna") let foo =new {a.LastName,a.FirstName, StreetCities= from c in a.Addresses select new {c.Street1,c.City } } select foo;
            //}

            //Sample 11: Aggregates in LINQ Methods
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var type = context.Contacts.Select(c => new { c.LastName, MaxCode= c.Addresses.Max(a=>a.PostalCode)});
            //}

            //Sample 12: Joins in queries, how to combine data from Contact entities and vOfficeAddresses entities using the JOIN
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var types = from c in context.Contacts join oa in context.vOfficeAddresses on c.ContactID equals oa.ContactID select new { oa.FirstName, oa.LastName, c.Title, oa.Street1, oa.City, oa.StateProvince };
            //    foreach(var type in types)
            //    {
            //        Console.WriteLine("{0} {1} {2} {3}",type.FirstName,type.LastName,type.Title,type.StateProvince);
            //    }

            //}

            //Sample 13: Nested query
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var types = from oa in context.vOfficeAddresses select new { oa.FirstName, oa.LastName, Titile = (from c in context.Contacts where c.ContactID == oa.ContactID select c.Title).FirstOrDefault() };

            //    foreach(var type in types)
            //    {
            //        Console.WriteLine("{0} {1} {2}", type.FirstName, type.LastName, type.Titile);
            //    }
            //}

            //Sample 14: LINQ to Entity, Group
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var group = from c in context.Contacts group c by c.Title into mygroup select mygroup;

            //    foreach (var type in group)
            //    {
            //        Console.WriteLine("{0}", type.Key);
            //    }
            //}

            //Sample 15: LINQ to Entity, filtering on a group property
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    var group = from c in context.Contacts group c by c.Title into mygroup where mygroup.Count()>150 select new { MyTitle=mygroup.Key,mygroup, Count=mygroup.Count()};

            //    foreach (var type in group)
            //    {
            //        Console.WriteLine("{0} {1}", type.MyTitle,type.Count);
            //    }
            //}

            //Sample 16: Shaping data return by queries
            //using (var context = new PROGRAMMINGEFDB1Entities())
            //{
            //    //You are querying Contact
            //    var addresses = from c in context.Addresses where c.CountryRegion == "Canada" select new { c, c.Contact };

            //    //As the Contact and Address entities are materialized ,the Entity Framewoerk recognizes that they are realted to 
            //    //each oether and wires them up so that you can navigate between them
            //    foreach(var address in addresses)
            //    {
            //        Console.WriteLine("First Name: {0} Addresses: {1}", address.Contact.FirstName, address.Contact.Addresses.Count);

            //        //The Address have a Contact object in their Contact property, on the contrary, Contract have Addresss objectes 
            //        //their Addresses property
            //        foreach (Address a in address.Contact.Addresses)
            //        {
            //            Console.WriteLine("City: {0}",a.City);
            //        }
            //    }
            //}

            //Samele 17: Deferred loading
            using (var context = new PROGRAMMINGEFDB1Entities())
            {
                context.Configuration.LazyLoadingEnabled = true;

                var contacts = from c in context.Contacts select c;

                foreach (var contact in contacts)
                {
                    //Lazy loading
                    Console.WriteLine("{0}#Addresses: {1}", contact.FirstName, contact.Addresses.Count());
                    Console.WriteLine("{0}#City: {1}", contact.FirstName, contact.Addresses.FirstOrDefault().City);
                }
            }

            Console.ReadLine();
        }
    }
}
