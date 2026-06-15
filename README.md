# SDC320L
# Friendly Faces

This project is completiton of the Friendly Faces application developed in previous weeks. The Week 5 version introduces a menu and fixes any remaining bugs from the previous weeks. The application allows the user to perform full CRUD operations and continues running until the user chooses to exit.

---

## Project Overview

Friendly Faces is a C# console application designed to manage a list of contacts. The program allows the user to:

- Add new contacts  
- View all saved contacts  
- Update existing contacts  
- Delete contacts  
- Continue performing actions until selecting the option to quit  

This version stores all contact information in a SQLite database (`contacts.db`) so that data remains available between program runs.

---

## Contact Types

The program supports three types of contacts. Each type includes an additional piece of information stored in the `ExtraInfo` field:

| Contact Type | Extra Information Stored |
|--------------|---------------------------|
| Business     | Company or Work Information |
| Friend       | Nickname |
| Family       | Relation (e.g., cousin, aunt, sibling) |

The user selects the contact type during the Add and Update operations, and the program prompts for the appropriate extra information based on that selection.

---

## Class Overview

### Program.cs
- Displays the program header and welcome message  
- Presents the main menu  
- Accepts and validates user input  
- Prompts for contact type and extra information  
- Calls the appropriate CRUD methods  
- Continues running until the user chooses to quit  

### ContactRecord.cs
Represents a single row in the Contacts table.  
Fields include:

- ID  
- FirstName  
- LastName  
- Phone  
- Email  
- ContactType  
- ExtraInfo  

Includes constructors for both new contacts and contacts loaded from the database.

### ContactDB.cs
Handles all database operations using parameterized SQL statements:

- CreateTable  
- AddContact  
- UpdateContact  
- DeleteContact  
- GetAllContacts  
- GetContact  

Parameterized queries are used throughout to prevent SQL injection and avoid errors caused by apostrophes or other special characters.

---

## Database Structure

The SQLite table contains the following columns:

ID INTEGER PRIMARY KEY AUTOINCREMENT
FirstName TEXT
LastName TEXT
Phone TEXT
Email TEXT
ContactType TEXT
ExtraInfo TEXT

---

## How to Run the Program

1. Clone or download the repository  
2. Ensure the `System.Data.SQLite` package is installed  
3. Build the project  
4. Run the application  
5. Use the menu to add, view, update, or delete contacts  

The program will continue running until the user selects the option to quit.

---

## Required Screenshots for Submission

The following screenshots should be captured during execution:

1. Program header and welcome message  
2. Main menu  
3. Adding a Business, Friend, and Family contact  
4. Viewing all contacts  
5. Updating a contact  
6. Deleting a contact  
7. Exit message  

---

## Author

Francis Hampton  
ECPI University  
Software Development Coursework - SDC320L C#

