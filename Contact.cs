/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Base class for all contact types.
 *******************************************************/
public class Contact : IPrintable   // Interface implemented here
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Contact(string first, string last, string phone, string email)
    {
        FirstName = first;
        LastName = last;
        Phone = phone;
        Email = email;
    }

    public virtual string GetPrintableText()
    {
        return $"{FirstName} {LastName}\nPhone: {Phone}\nEmail: {Email}";
    }
}