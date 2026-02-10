<div align="center">
  <img src="https://img.icons8.com/fluency/100/000000/driver-license.png" alt="Logo" width="100" height="100">
  <h1 align="center">DVLD System</h1>
  <p align="center">
    <b>Driving & Vehicle Licensing Department Management System</b>
    <br />
    A professional C# Solution for managing licensing processes.
  </p>
</div>

---

### 📖 Overview
The **DVLD** project is a desktop-based application designed to automate and organize the workflow of a licensing department. It's built with a strong focus on **Object-Oriented Programming (OOP)** and **N-Tier Architecture**.

---

### 🛠 Tech Stack
<table align="center">
  <tr>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=cs" width="40" height="40" alt="C#" />
      <br />C#
    </td>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=dotnet" width="40" height="40" alt=".NET" />
      <br />.NET WinForms
    </td>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=msql" width="40" height="40" alt="SQL Server" />
      <br />SQL Server
    </td>
    <td align="center" width="96">
      <img src="https://skillicons.dev/icons?i=visualstudio" width="40" height="40" alt="VS" />
      <br />Visual Studio
    </td>
  </tr>
</table>

---

### 🚀 Features & Roadmap

#### 🟢 Phase 1: People Management (Current)
- [x] **Advanced Search:** Filter people by ID, National No, Name, etc.
- [x] **Data Integrity:** Business rules to prevent duplicate National IDs.
- [x] **Image Management:** Store and display person photos dynamically.
- [ ] **Deletion Logic:** Secure deletion with database constraint checks.

#### 🟡 Phase 2: User & Security (Next)
- [ ] Role-based access control (Admin/User).
- [ ] Encrypted password storage.

#### 🔴 Phase 3: Applications & Licenses (Planned)
- [ ] Local & International license issuance.
- [ ] Test appointments and results management.

---

### 🏗 Architecture Structure
This project follows the **3-Tier Architecture** pattern:
* **`DVLD_UI`**: The interface where the user interacts with the system.
* **`DVLD_Business`**: The brain of the app (validation and logic).
* **`DVLD_DataAccess`**: The bridge to SQL Server using ADO.NET.

---

<div align="center">
  <sub>Built with ❤️ by Abdallbaset - 2026</sub>
</div>