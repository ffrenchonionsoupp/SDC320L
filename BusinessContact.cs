/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Business contact derived from Contact.
 *******************************************************/
public class BusinessContact : Contact
{
    public string Company { get; set; }

    public BusinessContact(string first, string last, string phone, string email, string company)
        : base(first, last, phone, email)
    {
        Company = company;
    }
    
    public override string GetPrintableText()   // Polymorphism
    {
        return base.GetPrintableText() + $"\nCompany: {Company}";
    }
}
