/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/26
 * Purpose: Business contact derived from Contact.
 *******************************************************/
public class BusinessContact : Contact
{
    public string Company { get; private set; }

    public BusinessContact(string first, string last, string phone, string email, string company)
        : base(first, last, phone, email)
    {
        Company = company;
    }

    //Abstraction, required by the base class
    public override string GetContactType() => "Business";

    //Polymorphism, override formatting
    public override string GetPrintableText()
    {
        return base.GetPrintableText() + $"\nCompany: {Company}";
    }
}
