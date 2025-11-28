# EFCoreRelations – Entity Framework Core Relations Demo

This project demonstrates how to build and manage **database relationships** using **Entity Framework Core**, including One-to-One, One-to-Many, and Many-to-Many relations.
It also includes practical CRUD operations to understand how EF Core interacts with relational databases.

---

## 🚀 Overview

The project represents a simple airline management domain with entities such as:

* **AirLine**
* **AirCraft**
* **Crew**
* **Employee**
* **Transaction**
* **Route**
* **RouteAircraft (Join Table)**

The goal is to practice real-world EF Core relationship mapping and perform common data operations inside `Program.cs`.

---

## 🔗 Implemented Relationships (Fluent API)

### ✔ One-to-One

**AirCraft ↔ Crew**
Each aircraft has exactly one crew, and each crew is assigned to one aircraft.

```csharp
modelBuilder.Entity<AirCraft>()
    .HasOne(a => a.ACrew)
    .WithOne(c => c.CAirCraft)
    .HasForeignKey<Crew>(c => c.CrewId);
```

---

### ✔ One-to-Many

**AirLine ↔ AirCraft**
One airline can own multiple aircrafts.

```csharp
modelBuilder.Entity<AirCraft>()
    .HasOne(a => a.AirLine)
    .WithMany(l => l.airCrafts)
    .HasForeignKey(a => a.AirLineId);
```

---

### ✔ One-to-Many

**AirLine ↔ Employee**

```csharp
modelBuilder.Entity<Employee>()
    .HasOne(e => e.EAirline)
    .WithMany(a => a.employees)
    .HasForeignKey(e => e.AirLineId);
```

---

### ✔ One-to-Many

**AirLine ↔ Transaction**

```csharp
modelBuilder.Entity<Transaction>()
    .HasOne(t => t.TAirLine)
    .WithMany(a => a.transactions)
    .HasForeignKey(t => t.AirLineId);
```

---

### ✔ Many-to-Many (With Extra Fields)

**AirCraft ↔ Route**
Implemented through the join entity **RouteAircraft**, which contains additional fields such as:

* Number of passengers
* Price
* Arrival & departure time
* Duration

```csharp
modelBuilder.Entity<RouteAircraft>()
    .HasKey(ra => new { ra.AirCraftId, ra.RouteId });
```

---

## 🧠 Concepts Covered

This project demonstrates several important EF Core concepts:

### 🔸 1. **Database Context Configuration**

* Using `DbContext`
* Setting SQL Server connection string
* Overriding `OnModelCreating` for Fluent API mapping

### 🔸 2. **Applying Different Types of Relations**

* One-to-One (with foreign key on Crew)
* One-to-Many (AirLine → AirCraft, Employees, Transactions)
* Many-to-Many with custom join table (RouteAircraft)

### 🔸 3. **Navigation Properties**

* Required vs optional relationships
* Collections vs references
* How EF Core tracks relations automatically

### 🔸 4. **CRUD Operations**

Inside `Program.cs`, examples include:

* Creating new airline, aircraft, route, transaction
* Reading employees or transactions belonging to specific airline
* Updating aircraft capacity
* Deleting old transactions
* Querying with `.Where()`, `.Select()`, `.GroupBy()`

### 🔸 5. **Join Table with Composite Key**

* Creating composite primary keys
* Connecting many-to-many using navigation collections

### 🔸 6. **Best Practices Learned**

* Always configure relations in Fluent API
* Avoid relying on EF Core conventions when relations are complex
* Keep navigation properties consistent
* Use HashSet for collection initialization
* Separate domain models from DbContext logic

---

## ▶️ How to Run

1. Ensure SQL Server is running.
2. Update the connection string if needed.
3. Apply migrations if required.
4. Run the project to test CRUD operations.

---

## 👤 Author

**abdalla adel aboaziz**
EF Core Training & Practice Project
