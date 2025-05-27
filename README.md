# Hall Management and Library System

A complete web application for managing student hall meals and academic library services. Built with Angular (frontend) and .NET (backend).

## 🚀 Features

### 🔐 Authentication
- **Sign Up**: New students can register.
- **Sign In**: Registered students can log in securely.

### 🍽️ Hall Meal Token System
- Students can generate daily **meal tokens** after signing in.
- Option to **pay for meals** directly from the app.
- A **PDF document** of the generated token is available for download after confirmation.

### 📚 Library Management
- Students can **apply for academic books** from the hall library.
- Request tracking is available for book applications.

---

## 🛠️ Technologies Used

### Backend
- **.NET Core**
- **Entity Framework Core**
- **SQL Server / MySQL**

### Frontend
- **Angular**
- **Bootstrap / Tailwind CSS** (if used)

---

## ⚙️ Setup Instructions

### Backend Setup

1. Navigate to the backend folder:
   ```bash
   cd backend-folder-name

 🚀 Features
👤 User Authentication
Student registration with basic details.

Secure login with session management.

Password protection with encryption (if implemented).

🍽️ Hall Meal Token System
Daily meal token generation for logged-in students.

Meal types and time selection (if applicable).

Payment integration (manual/online).

After successful token generation, downloadable PDF meal token.

Token history view for tracking previous tokens.

📚 Hall Library System
Students can apply for academic books online.

Application form with book name, author, course info, etc.

Admin approval system for managing book requests (if implemented).

View current and past book applications.

📄 PDF Generation
Automated generation of downloadable PDF documents for:

Meal tokens

Payment receipts (if included)

📊 Dashboard (optional, if implemented)
Quick view of:

Today's meal status

Pending book applications

Recent activity logs

🛡️ Security and Validation
Backend form validation for user inputs.

Restricted access to authorized users only.

Error handling and toast/alert notifications (if used in frontend).

Bonus (If any of these were implemented)
Role-based access: admin vs student

Email confirmation on registration

Token cut-off time logic (e.g., token must be generated before 10 AM)

   
🙋‍♂️ User Capabilities
Register and log in securely

Generate and download daily meal tokens

Make payments for meals

Apply for academic books from the library

View and track the status of book applications
