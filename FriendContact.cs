/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/26
 * Purpose: Friend contact derived from Contact.
 *******************************************************/
public class FriendContact : Contact
{
    public string Nickname { get; private set; }

    public FriendContact(string first, string last, string phone, string email, string nickname)
        : base(first, last, phone, email)
    {
        Nickname = nickname;
    }

    //Abstraction, required by the base class
    public override string GetContactType() => "Friend";

    //Polymorphism, override formatting
    public override string GetPrintableText()
    {
        return base.GetPrintableText() + $"\nNickname: {Nickname}";
    }

}
