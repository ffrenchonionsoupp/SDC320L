/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Week 1 project starter application.
 *******************************************************/
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Week 1 Project - Friendly Faces");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This application is currently under repair!");
        Console.WriteLine("This is my week one deliverable!");
        Console.WriteLine("This version of my application demonstrates inheritance and composition.");
        Console.WriteLine();

        // Composition: ContactBook contains Contact objects
        ContactBook book = new ContactBook();

        // Inheritance: Derived classes
        BusinessContact bc = new BusinessContact("Maria", "Semple", "555-1234", "Maria@Putnam.com", "Putnam Publishing");
        FamilyContact fc = new FamilyContact("Patty", "Hampton", "555-9876", "Patty@example.com", "Mom");
        FriendContact fr = new FriendContact("Francis", "Hampton", "555-2222", "Francis@example.com", "That's me!");

        book.AddContact(bc);
        book.AddContact(fc);
        book.AddContact(fr);

        Console.WriteLine("Displaying sample contacts:");
        book.DisplayAll();

        Console.WriteLine("\nEnd of Week 1 demonstration.");
    }
}