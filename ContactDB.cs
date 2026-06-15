/************************************************************
 * Name: Francis Hampton
 * Date: 6/14/2026
 * Purpose: Handles CRUD operations for the Contacts table.
 ************************************************************/

using System.Data.SQLite;
using System.Collections.Generic;

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

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public static void AddContact(SQLiteConnection conn, ContactRecord c)
    {
        string sql =
        "INSERT INTO Contacts (FirstName, LastName, Phone, Email, ContactType, ExtraInfo) " +
        "VALUES (@fn, @ln, @ph, @em, @type, @extra)";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@fn", c.FirstName);
            cmd.Parameters.AddWithValue("@ln", c.LastName);
            cmd.Parameters.AddWithValue("@ph", c.Phone);
            cmd.Parameters.AddWithValue("@em", c.Email);
            cmd.Parameters.AddWithValue("@type", c.ContactType);
            cmd.Parameters.AddWithValue("@extra", c.ExtraInfo);

            cmd.ExecuteNonQuery();
        }
    }

    public static void UpdateContact(SQLiteConnection conn, ContactRecord c)
    {
        string sql =
        "UPDATE Contacts SET " +
        "FirstName=@fn, LastName=@ln, Phone=@ph, Email=@em, " +
        "ContactType=@type, ExtraInfo=@extra " +
        "WHERE ID=@id";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@fn", c.FirstName);
            cmd.Parameters.AddWithValue("@ln", c.LastName);
            cmd.Parameters.AddWithValue("@ph", c.Phone);
            cmd.Parameters.AddWithValue("@em", c.Email);
            cmd.Parameters.AddWithValue("@type", c.ContactType);
            cmd.Parameters.AddWithValue("@extra", c.ExtraInfo);
            cmd.Parameters.AddWithValue("@id", c.ID);

            cmd.ExecuteNonQuery();
        }
    }


    public static void DeleteContact(SQLiteConnection conn, int id)
    {
        string sql = "DELETE FROM Contacts WHERE ID=@id";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public static List<ContactRecord> GetAllContacts(SQLiteConnection conn)
    {
        List<ContactRecord> contacts = new List<ContactRecord>();
        string sql = "SELECT * FROM Contacts";

        using (var cmd = new SQLiteCommand(sql, conn))
        using (var rdr = cmd.ExecuteReader())
        {
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
        }

        return contacts;
    }

    public static ContactRecord GetContact(SQLiteConnection conn, int id)
    {
        string sql = "SELECT * FROM Contacts WHERE ID=@id";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);

            using (var rdr = cmd.ExecuteReader())
            {
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
            }
        }

        return new ContactRecord(-1, "", "", "", "", "", "");
    }

}