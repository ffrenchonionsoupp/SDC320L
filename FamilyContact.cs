/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/26
 * Purpose: Family contact derived from Contact.
 *******************************************************/
public class FamilyContact : Contact
{
    public string Relation { get; private set; }

    public FamilyContact(string first, string last, string phone, string email, string relation)
        : base(first, last, phone, email)
    {
        Relation = relation;
    }
        
    //Abstraction, required by the base class
    public override string GetContactType() => "Family";

    //Polymorphism, override formatting
    public override string GetPrintableText()
    {
        return base.GetPrintableText() + $"\nRelation: {Relation}";
    }
}
