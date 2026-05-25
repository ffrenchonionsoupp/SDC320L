/*******************************************************
 * Name: Francis Hampton
 * Date: 5/17/26
 * Purpose: Friend contact derived from Contact.
 *******************************************************/
public class FriendContact : Contact
{
    public string Nickname { get; set; }

    public FriendContact(string first, string last, string phone, string email, string nickname)
        : base(first, last, phone, email)
    {
        Nickname = nickname;
    }

    public override string GetPrintableText()   // Polymorphism
    {
        return base.GetPrintableText() + $"\nNickname: {Nickname}";
    }

}
