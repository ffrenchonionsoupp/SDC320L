/************************************************************
 * Name: Francis Hampton
 * Date: 6/14/2026
 * Assignment: Friendly Faces – Week 5 Final Touches
 * Purpose: Implement a menu, fix bugs, and confirm ability to run
 ************************************************************/

using System;
using System.Data.SQLite;
using System.Collections.Generic;

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

        using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName}"))
        {
            conn.Open();
            ContactDB.CreateTable(conn);

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
                        AddContact(conn);
                        break;

                    case "2":
                        ViewContacts(conn);
                        break;

                    case "3":
                        UpdateContact(conn);
                        break;

                    case "4":
                        DeleteContact(conn);
                        break;

                    case "5":
                        Console.WriteLine("Thanks for using Friendly Faces! Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Oops! That wasn’t a valid choice. Try again.");
                        break;
                }
            }
        }
    }

    // -----------------------------
    // Add Contact
    // -----------------------------
    static void AddContact(SQLiteConnection conn)
    {
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
                return;
        }

        Console.Write("Enter first name: ");
        string first = Console.ReadLine();

        Console.Write("Enter last name: ");
        string last = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter email address: ");
        string email = Console.ReadLine();

        ContactRecord c = new ContactRecord(first, last, phone, email, contactType, extraInfo);
        ContactDB.AddContact(conn, c);

        Console.WriteLine("Contact added successfully!");
    }

    // -----------------------------
    // View Contacts
    // -----------------------------
    static void ViewContacts(SQLiteConnection conn)
    {
        List<ContactRecord> contacts = ContactDB.GetAllContacts(conn);

        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        Console.WriteLine("Here are your friendly faces:");
        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.ID}. {c.FirstName} {c.LastName} | {c.Phone} | {c.Email} | {c.ContactType} | {c.ExtraInfo}");
        }
    }

    // -----------------------------
    // Update Contact
    // -----------------------------
    static void UpdateContact(SQLiteConnection conn)
    {
        Console.Write("Enter the ID of the contact to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        ContactRecord existing = ContactDB.GetContact(conn, id);

        if (existing.ID == -1)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("Leave a field blank to keep the current value.");

        Console.Write($"First Name ({existing.FirstName}): ");
        string first = Console.ReadLine();
        if (first == "") first = existing.FirstName;

        Console.Write($"Last Name ({existing.LastName}): ");
        string last = Console.ReadLine();
        if (last == "") last = existing.LastName;

        Console.Write($"Phone ({existing.Phone}): ");
        string phone = Console.ReadLine();
        if (phone == "") phone = existing.Phone;

        Console.Write($"Email ({existing.Email}): ");
        string email = Console.ReadLine();
        if (email == "") email = existing.Email;

        Console.WriteLine("Select the contact type:");
        Console.WriteLine("1. Business");
        Console.WriteLine("2. Friend");
        Console.WriteLine("3. Family");
        Console.Write($"Current Type ({existing.ContactType}): ");

        string typeChoice = Console.ReadLine();
        string contactType = existing.ContactType;
        string extraInfo = existing.ExtraInfo;

        if (typeChoice == "1")
        {
            contactType = "Business";
            Console.Write("Enter the work info: ");
            extraInfo = Console.ReadLine();
        }
        else if (typeChoice == "2")
        {
            contactType = "Friend";
            Console.Write("Enter the nickname: ");
            extraInfo = Console.ReadLine();
        }
        else if (typeChoice == "3")
        {
            contactType = "Family";
            Console.Write("Enter the relation: ");
            extraInfo = Console.ReadLine();
        }

        ContactRecord updated = new ContactRecord(id, first, last, phone, email, contactType, extraInfo);
        ContactDB.UpdateContact(conn, updated);

        Console.WriteLine("Contact updated successfully.");
    }

    // -----------------------------
    // Delete Contact
    // -----------------------------
    static void DeleteContact(SQLiteConnection conn)
    {
        Console.Write("Enter the ID of the contact to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        ContactRecord existing = ContactDB.GetContact(conn, id);

        if (existing.ID == -1)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        ContactDB.DeleteContact(conn, id);
        Console.WriteLine("Contact deleted successfully.");
    }
}
