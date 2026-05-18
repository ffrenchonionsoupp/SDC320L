/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Demonstrates composition by containing a list
 *          of Contact objects.
 *******************************************************/
public class ContactBook
{
    public List<Contact> Contacts { get; set; }

    public ContactBook()
    {
        Contacts = new List<Contact>();
    }

    public void AddContact(Contact c)
    {
        Contacts.Add(c);
    }

    public void DisplayAll()
    {
        foreach (var c in Contacts)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(c.GetInfo());
        }
    }
}
