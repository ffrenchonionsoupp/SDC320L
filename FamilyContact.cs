/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Family contact derived from Contact.
 *******************************************************/
public class FamilyContact : Contact
{
    public string Relation { get; set; }

    public FamilyContact(string first, string last, string phone, string email, string relation)
        : base(first, last, phone, email)
    {
        Relation = relation;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"\nRelation: {Relation}";
    }
}
