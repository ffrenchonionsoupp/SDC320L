/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/26
 * Purpose: Abstract base class for all contacts.
 * Demonstrates abstraction, constructors, and access control.
 *******************************************************/
public abstract class Contact : IPrintable   // Interface implemented here
{
    //Private fields (encapsulation)
    private string _FirstName;
    private sring _LastName;

    //Public properties
    public string FirstName
    {
        get => _FirstName;
        protected set => _FirstName = value;
    }
    public string LastName
     {
        get => _LastName;
        protected set => _LastName = value;
    }
    public string Phone { get; set; }
    public string Email { get; set; }

    //Base constructor
    protected Contact(string first, string last, string phone, string email)
    {
        FirstName = first;
        LastName = last;
        Phone = phone;
        Email = email;
    }

    //Overloaded constructor
    protected Contact(string first, string last)
    {
        FirstName = first;
        LastName = last;
        Phone = "Unknown";
        Email = "Unknkown";
    }

    //Abstraction
    public abstract string GetContactType();

    //Polymorphism
    public virtual string GetPrintableText()
    {
        return $"{GetContactType()} Contact\n" +
               $"{FirstName} {LastName}\n" +
               $"Phone: {Phone}\n" +
               $"Email: {Email}";
    }
}