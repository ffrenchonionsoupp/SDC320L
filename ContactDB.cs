/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: Handles CRUD operations for the Contacts table.
 ************************************************************/

using System.Data.SQLite;

public class ContactDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
        "CREATE TABLE IF NOT EXISTS Contacts (" +
        "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
        "FirstName TEXT," +
        "LastName TEXT," +
        "Phone TEXT," +
        "Email TEXT," +
        "ContactType TEXT," +
        "ExtraInfo TEXT);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddContact(SQLiteConnection conn, ContactRecord c)
    {
        string sql = string.Format(
            "INSERT INTO Contacts (FirstName, LastName, Phone, Email, ContactType, ExtraInfo) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
            c.FirstName, c.LastName, c.Phone, c.Email, c.ContactType, c.ExtraInfo);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateContact(SQLiteConnection conn, ContactRecord c)
    {
        string sql = string.Format(
            "UPDATE Contacts SET FirstName='{0}', LastName='{1}', Phone='{2}', Email='{3}', " +
            "ContactType='{4}', ExtraInfo='{5}' WHERE ID={6}",
            c.FirstName, c.LastName, c.Phone, c.Email, c.ContactType, c.ExtraInfo, c.ID);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteContact(SQLiteConnection conn, int id)
    {
        string sql = $"DELETE FROM Contacts WHERE ID={id}";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<ContactRecord> GetAllContacts(SQLiteConnection conn)
    {
        List<ContactRecord> contacts = new List<ContactRecord>();
        string sql = "SELECT * FROM Contacts";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            contacts.Add(new ContactRecord(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetString(5),
                rdr.GetString(6)
            ));
        }

        return contacts;
    }

    public static ContactRecord GetContact(SQLiteConnection conn, int id)
    {
        string sql = $"SELECT * FROM Contacts WHERE ID={id}";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new ContactRecord(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetString(5),
                rdr.GetString(6)
            );
        }

        return new ContactRecord(-1, "", "", "", "", "", "");
    }
}
