/*******************************************************
 * Name: Francis Hampton
 * Date: 5/24/2026
 * Purpose: Week 2 demonstration of interface, inheritance,
 *          composition, and polymorphism.
 *******************************************************/
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Week 2 Project - Friendly Faces");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This application is currently under repair!");
        Console.WriteLine("This is my week two deliverable!");
        Console.WriteLine("This version of my application demonstrates inheritance, composition, interfaces, and polymorphism.");
        Console.WriteLine();

        // Composition: ContactBook contains Contact objects
        ContactBook book = new ContactBook();

        // Inheritance: Derived classes
        Contact c1 = new BusinessContact("Maria", "Semple", "555-1234", "Maria@Putnam.com", "Putnam Publishing");
        Contact c2 = new FamilyContact("Patty", "Hampton", "555-9876", "Patty@example.com", "Mom");
        Contact c3 = new FriendContact("Francis", "Hampton", "555-2222", "Francis@example.com", "That's me!");

        book.AddContact(c1);
        book.AddContact(c2);
        book.AddContact(c3);

        Console.WriteLine("Displaying contacts (polymorphism):\n");
        
        // Polymorphism: Each object uses its own override
        foreach (var contact in book.Contacts)
        {
            Console.WriteLine(contact.GetPrintableText());
            Console.WriteLine("----------------------------------");
        }


        Console.WriteLine("\nEnd of Week 2 demonstration.");
    }
}