/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Week 3 demonstration of interface, inheritance,
 *          composition, polymorphism, and now the introduction of abstraction.
 *******************************************************/
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Week 3 Project - Friendly Faces");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This application is currently under repair!");
        Console.WriteLine("This is my week three deliverable!");
        Console.WriteLine("This version of my application demonstrates abstraction, constructors,");
        Console.WriteLine("access specifiers, and polymorphism.\n");

        // Composition: ContactBook contains Contact objects
        ContactBook book = new ContactBook();

        // Inheritance: Derived classes
        Contact c1 = new BusinessContact("Maria", "Semple", "555-1234", "Maria@Putnam.com", "Putnam Publishing");
        Contact c2 = new FamilyContact("Patty", "Hampton", "555-9876", "Patty@example.com", "Mom");
        Contact c3 = new FriendContact("Francis", "Hampton", "555-2222", "Francis@example.com", "That's me!");

        book.AddContact(c1);
        book.AddContact(c2);
        book.AddContact(c3);

        Console.WriteLine("Displaying contacts (polymorphism & abstraction):\n");
        
        // Polymorphism: Each object uses its own override
        foreach (var contact in book.GetAllContacts())
        {
            Console.WriteLine(contact.GetPrintableText());
            Console.WriteLine("----------------------------------");
        }


        Console.WriteLine("\nEnd of Week 3 demonstration.");
    }
}