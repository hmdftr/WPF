# Account Management WPF Application

This is a C# WPF application designed for managing user accounts. It provides functionality for viewing, adding, editing, and removing user accounts, with specific user access control.

## Features

* **User Account Management:**
    * View a list of user accounts with details such as Employee ID, Job Title, and Last Login.
    * Add new user accounts (Specific user only).
    * Edit existing user accounts (Specific user or users can update their own password).
    * Remove user accounts (Specific user only).
    * Users can update their own password.
* **Specific User Access Control:**
    * Specific User with a predefined Employee ID and password has full access to add, edit, and remove accounts.
    * Standard users can only edit their own password.
* **Login System:**
    * Users must log in with their Employee ID and password.
* **Data Persistence:**
    * User account data is stored in a JSON file (`accounts.json`).
* **Logging:**
    * Login actions are logged to a text file (`login_logs.txt`).

## Getting Started

### Prerequisites

* **Visual Studio:** You will need Visual Studio to open and build the project.
* **.NET 8.0 SDK:** Ensure you have the .NET 8.0 SDK installed.

### Installation

1.  **Clone the Repository:**
    ```bash
    git clone <repository_url>
    ```
    (Replace `<repository_url>` with the URL of your GitHub repository.)

2.  **Open the Solution:**
    * Open the `AccountManagementProgram.sln` file in Visual Studio.

3.  **Build and Run:**
    * Build the solution.
    * Run the `LoginProgram` project to log in and access the Account Management application.

### Usage

1.  **Login:**
    * Enter your Employee ID and password in the `LoginProgram` window.
    * Click the "Login" button.

2.  **Account Management (Specific User):**
    * The user with a predefined EmployeeID and password will see buttons to add, edit, and remove accounts.
    * Select an account from the list to edit or remove it.
    * Enter the new account details in the text boxes and click "Add" or "Edit".
    * Click the remove button to remove a selected account.

3.  **Account Management (Standard User):**
    * Standard users will only be able to edit their own password.
    * Select their own account and only the password textbox will be editable.

## File Structure
