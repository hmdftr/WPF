using LoginProgram;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Diagnostics;

namespace LoginProgram
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        //private string accountsFilePath = "C:\\Users\\Fitri\\Documents\\WPF\\AccountManagementProgram\\bin\\Debug\\accounts.json";
        private string accountsFilePath = "C:\\Users\\Fitri\\Documents\\WPF\\AccountManagementProgram\\AccountManagementProgram\\bin\\Debug\\net8.0-windows\\accounts.json"; // Correct
        //private string accountsFilePath = @"C:\Users\Fitri\Documents\WPF\AccountManagementProgram\bin\Debug\accounts.json"; 
        private string logFilePath = "login_logs.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadAccounts();
        }

        private ObservableCollection<Account> LoadAccounts()
        {
            if (File.Exists(accountsFilePath))
            {
                try
                {
                    //MessageBox.Show("accounts.json exists at: " + accountsFilePath); // Debugging line
                    string json = File.ReadAllText(accountsFilePath);
                    var loadedAccounts = JsonSerializer.Deserialize<ObservableCollection<Account>>(json);
                    return loadedAccounts; // Return the loaded collection
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null; // Return null to indicate an error
                }
            }
            else
            {
                //MessageBox.Show("accounts.json does not exist at: " + accountsFilePath); // Debugging line
                return null;
            }
            return null; // Return null if the file doesn't exist
        }


        private void SaveAccounts(ObservableCollection<Account> accounts)
        {
            try
            {
                string json = JsonSerializer.Serialize(accounts);
                File.WriteAllText(accountsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving accounts: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogLogin(string employeeId)
        {
            try
            {
                string logEntry = $"{DateTime.Now}: Employee ID {employeeId} logged in.\n";
                File.AppendAllText(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging login: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = employeeIdTextBox.Text;
            string password = passwordTextBox.Text;

            ObservableCollection<Account> accounts = LoadAccounts();

            if (accounts != null)
            {
                var account = accounts.FirstOrDefault(a => a.EmployeeId == employeeId && a.Password == password);

                if (account != null)
                {
                    // Login successful
                    account.LastLogin = DateTime.Now;
                    SaveAccounts(accounts);
                    LogLogin(employeeId);
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Start Account Management Program
                    string accountManagementProgramPath = @"C:\Users\Fitri\Documents\WPF\AccountManagementProgram\AccountManagementProgram\bin\Debug\net8.0-windows\AccountManagementProgram.exe"; // Replace with your actual path!

                    if (File.Exists(accountManagementProgramPath))
                    {
                        Process.Start(accountManagementProgramPath);

                        // Optionally, close the Login Program
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account Management Program not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Login failed. Invalid credentials.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Error loading accounts.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}