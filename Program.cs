/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Assignment: Friendly Faces – Week 4 Database Integration
 * Purpose: Demonstrates SQLite CRUD + LINQ using ContactRecord.
 ************************************************************/

using System.Data.SQLite;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nWeek 4 – Friendly Faces Database Integration");
        Console.WriteLine("Created by: Francis Hampton\n");
        Console.WriteLine("This demo shows SQLite CRUD operations using your contact data.\n");

        const string dbName = "FriendlyFaces.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            ContactDB.CreateTable(conn);

            // CREATE
            ContactDB.AddContact(conn, new ContactRecord("Maria", "Semple", "555-1234", "Maria@Putnam.com", "Business", "Putnam Publishing"));
            ContactDB.AddContact(conn, new ContactRecord("Patty", "Hampton", "555-9876", "Patty@example.com", "Family", "Mom"));
            ContactDB.AddContact(conn, new ContactRecord("Francis", "Hampton", "555-2222", "mike@example.com", "Friend", "That's me!"));

            // READ
            Console.WriteLine("\nAll Contacts:");
            var all = ContactDB.GetAllContacts(conn);
            PrintContacts(all);

            // LINQ: Filter by last name initial example 
            Console.WriteLine("\nContacts with last name starting with 'H':");
            var filtered = all.Where(c => c.LastName.StartsWith("H"));
            PrintContacts(filtered.ToList());

            // UPDATE
            ContactRecord update = new ContactRecord(1, "Maria", "Semple", "555-0000", "Maria@Putnam.com", "Business", "Putnam Publishing");
            ContactDB.UpdateContact(conn, update);

            Console.WriteLine("\nUpdated Contact (ID 1):");
            PrintContact(ContactDB.GetContact(conn, 1));

            // DELETE
            ContactDB.DeleteContact(conn, 3);

            Console.WriteLine("\nContacts After Deleting ID 3:");
            PrintContacts(ContactDB.GetAllContacts(conn));
        }
    }

    private static void PrintContacts(List<ContactRecord> contacts)
    {
        foreach (var c in contacts)
            PrintContact(c);
    }

    private static void PrintContact(ContactRecord c)
    {
        Console.WriteLine($"ID {c.ID}: {c.FirstName} {c.LastName} ({c.ContactType})");
        Console.WriteLine($"Phone: {c.Phone}");
        Console.WriteLine($"Email: {c.Email}");
        Console.WriteLine($"Extra: {c.ExtraInfo}\n");
    }
}
