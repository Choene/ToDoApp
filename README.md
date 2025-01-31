# 📌 Blazor To-Do App

This is a simple **Blazor Server** application for managing a **To-Do List**.\
It uses **C#**, **Entity Framework Core**, and **SQLite** for persistence.


---

## 🛠 Prerequisites

Ensure you have the following installed:

- **.NET 8 SDK** → [Download Here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **SQLite (Optional - can be embedded)** → [Download Here](https://www.sqlite.org/download.html)

---

## 🚀 Getting Started

### **1️⃣ Clone the Repository**

```sh
git clone [https://github.com/Choene/ToDoApp.git](https://github.com/Choene/ToDoApp.git)
cd ToDoApp
```

### **2️⃣ Install Dependencies**

Restore .NET dependencies:

```sh
dotnet restore
```

### **3️⃣ Set Up Database**

Run the following command to create and apply the database schema:

```sh
dotnet ef database update
```

> **Note:** The SQLite database will be created inside the `/Data/` folder.

### **4️⃣ Run the Application**

Start the Blazor Server app:

```sh
dotnet run
```

### **5️⃣ Open the App in Browser**

Once the app starts, open:

```
https://localhost:7219/todo
```

(Or `http://localhost:PORT/todo` based on the console output)

---

## ⚙️ Configuration

### **📌 Change Database Location**

By default, the SQLite database is stored in:

```
Data/todo.db
```

To change this, modify ``:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=NewDatabasePath/todo.db"
}
```

Then **run migrations again**:

```sh
dotnet ef database update
```

---

## 🛠 Troubleshooting

### **✅ Common Issues & Fixes**

| Issue                         | Solution                                                     |
| ----------------------------- | ------------------------------------------------------------ |
| ❌ `dotnet: command not found` | Install **.NET SDK** and restart your terminal.              |
| ❌ Database not created        | Run `dotnet ef database update` to initialize the SQLite DB. |

---

## 👨‍💻 Author

Developed by **Choene Chokoe**\
🔗 GitHub: [Profile](https://github.com/choene)

---

