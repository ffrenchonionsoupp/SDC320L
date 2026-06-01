/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/26
 * Purpose: Demonstrates composition by containing a list
 *          of Contact objects.
 *******************************************************/
public class ContactBook
{
    private List<Contact> _contacts = new List<Contact>();

    public void AddContact(Contact c) => _contacts.Add(c);

    public List<Contact> GetAllContacts() => _contacts;
}
