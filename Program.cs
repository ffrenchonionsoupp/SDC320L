/************************************************************
 * Name: Francis Hampton
 * Date: 6/14/2026
 * Assignment: Friendly Faces – Week 5 Final Touches
 * Purpose: Implement a menu, fix bugs, and confirm ability to run
 ************************************************************/

using System.Data.SQLite;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Friendly Faces");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This application has finally reached its peak!");
        Console.WriteLine("This is my final deliverable!");
        Console.WriteLine("This version of my program is the pinnacle of C# programming.");
        Console.WriteLine("Friendly Faces is a roladex program that showcases different classes,");
        Console.WriteLine("composition, polymorphism, class constructors, access specifiers, and SQLite data storage.\n");

        const string dbName = "FriendlyFaces.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new contact");
            Console.WriteLine("2. View all contacts");
            Console.WriteLine("3. Update a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("What type of contact is this?");
                    Console.WriteLine("1. Business");
                    Console.WriteLine("2. Friend");
                    Console.WriteLine("3. Family");
                    Console.Write("Enter your choice: ");
                    string typeChoice = Console.ReadLine();

                    string contactType = "";
                    string extraInfo = "";

                    switch (typeChoice)
                    {
                        case "1":
                            contactType = "Business";
                            Console.Write("Enter the work info: ");
                            extraInfo = Console.ReadLine();
                            break;

                        case "2":
                            contactType = "Friend";
                            Console.Write("Enter the nickname: ");
                            extraInfo = Console.ReadLine();
                            break;

                        case "3":
                            contactType = "Family";
                            Console.Write("Enter the relation: ");
                            extraInfo = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Invalid type. Returning to menu.");
                            break;
                    }

                    Console.Write("Enter the contact's name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter the contact's phone number: ");
                    string phone = Console.ReadLine();

                    db.AddContact(name, phone, contactType, extraInfo);
                    Console.WriteLine("Contact added successfully!");
                    break;

                case "2":
                    var contacts = db.GetContacts();
                    Console.WriteLine("Here are your friendly faces:");

                    foreach (var c in contacts)
                    {
                        Console.WriteLine($"{c.Id}. {c.Name} — {c.Phone}");
                    }
                    break;

                case "3":
                    Console.Write("Enter the ID of the contact to update: ");
                    int updateId = int.Parse(Console.ReadLine());

                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter the new phone number: ");
                    string newPhone = Console.ReadLine();

                    db.UpdateContact(updateId, newName, newPhone);
                    Console.WriteLine("Contact updated successfully!");
                    break;

                case "4":
                    Console.Write("Enter the ID of the contact to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    db.DeleteContact(deleteId);
                    Console.WriteLine("Contact deleted successfully!");
                    break;

                case "5":
                    Console.WriteLine("Thanks for using Friendly Faces! Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Oops! That wasn’t a valid choice. Try again.");
                    break;
            

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
