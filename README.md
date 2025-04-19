## 📇 Simple Contact Manager (Console App in C#)

A console-based application built in **C#** to manage a list of contacts.  
This project follows **Object-Oriented Programming (OOP)** and applies **SOLID principles** for clean, maintainable, and scalable code.  
Data is saved locally using **JSON file storage**, and all actions are logged to the console.

---

### 📌 Features

- ✅ **Add Contact** – Input name, phone number, and email.
- ✏️ **Edit Contact** – Update contact information by ID.
- ❌ **Delete Contact** – Remove a contact from the system.
- 📋 **View All Contacts** – Display the full list of contacts.
- 💾 **JSON Persistence** – All contact data is saved in `contacts.json`.
- 🧾 **Log Actions** – Logs every action (add/edit/delete) via a simple logger.

---

### 🛠 Technologies Used

| Tool/Concept        | Description                            |
|---------------------|----------------------------------------|
| **C#**              | Core programming language              |
| **.NET Console App**| Simple CLI interface                   |
| **System.Text.Json**| Used for JSON serialization            |
| **OOP**             | Object-Oriented Programming structure  |
| **SOLID Principles**| For clean and scalable architecture    |

---

### 🧱 Project Structure

```
ContactManager/
│
├── Models/
│   └── Contact.cs            # Contact entity
│
├── Services/
│   ├── IServices.cs          # Interface for contact logic
│   └── Services.cs           # Contact CRUD logic + JSON persistence
│
├── Logger/
│   ├── ILogger.cs            # Logging interface
│   └── ConsoleLogger.cs      # Logs actions to console
│
└── Program.cs                # CLI app entry point and menu
```

---

### 💡 SOLID Principles Applied

- **S - Single Responsibility:** Each class has one job (e.g., logging, file handling).
- **O - Open/Closed:** Extend functionality (e.g., new logger or database) without changing core logic.
- **L - Liskov Substitution:** Uses interfaces to allow flexible implementations.
- **I - Interface Segregation:** Interfaces are small and focused.
- **D - Dependency Inversion:** Logger is injected, not hardcoded.

---

### 💾 Contact Storage (JSON)

All contacts are stored in a human-readable file:

📁 **contacts.json**
```json
[
  {
    "Id": 1,
    "Name": "Jane Doe",
    "Phone": "123456789",
    "Email": "jane@example.com"
  }
]
```

---

### 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/saraanbih/Contact-Manager.git
   ```
2. Open the project in **Visual Studio** or **VS Code**.
3. Run the application:
   ```bash
   dotnet run
   ```

---

### 📸 Sample Menu Output

```
--- Contact Manager ---
1. Add Contact
2. Edit Contact
3. Delete Contact
4. View All Contacts
5. Search
6. Exit
Choose an option:
```

---

### 🔮 Future Enhancements

- 🔍 Search contacts by name or email  
- 📂 Export to CSV  
- 🧪 Unit Testing  
- 🌐 Support for file-based or DB-based logging  
- ✅ Input validation and formatting

---

### 🤝 Contribution

This project is perfect for beginners practicing C#, OOP, and clean code principles.  
Feel free to fork, experiment, or contribute!
