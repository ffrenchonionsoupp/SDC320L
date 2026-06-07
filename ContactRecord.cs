/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: Represents a single row in the Contacts table.
 ************************************************************/

public class ContactRecord
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // Business, Family, Friend, what is what
    public string ContactType { get; set; }

    // Company, Relation, Nickname, extra bits
    public string ExtraInfo { get; set; }

    public ContactRecord(int id, string first, string last, string phone, string email, string type, string extra)
    {
        ID = id;
        FirstName = first;
        LastName = last;
        Phone = phone;
        Email = email;
        ContactType = type;
        ExtraInfo = extra;
    }

    public ContactRecord(string first, string last, string phone, string email, string type, string extra)
    {
       
