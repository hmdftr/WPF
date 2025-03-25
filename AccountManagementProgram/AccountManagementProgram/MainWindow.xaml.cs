using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace AccountManagementProgram
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        private string accountsFilePath = "C:\\Users\\Fitri\\Documents\\WPF\\AccountManagementProgram\\AccountManagementProgram\\bin\\Debug\\net8.0-windows\\accounts.json"; // Correct

        public MainWindow()
        {
            InitializeComponent();
            LoadAccounts();
            accountList.ItemsSource = accounts;

            
        }

        private void LoadAccounts()
        {
            if (File.Exists(accountsFilePath))
            {
                try
                {
                    string json = File.ReadAllText(accountsFilePath);
                    var loadedAccounts = JsonSerializer.Deserialize<ObservableCollection<Account>>(json);
                    if (loadedAccounts != null)
                    {
                        accounts = loadedAccounts;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveAccounts()
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to add this account?", "Confirm Add", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var newAccount = new Account
                {
                    EmployeeId = employeeIdTextBox.Text,
                    Password = passwordTextBox.Text,
                    JobTitle = jobTitleTextBox.Text,
                    LastLogin = DateTime.Now
                };

                accounts.Add(newAccount);
                SaveAccounts();
                ClearInputFields();
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAccount = accountList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    accounts.Remove(selectedAccount);
                    SaveAccounts();
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAccount = accountList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this account?", "Confirm Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    selectedAccount.EmployeeId = employeeIdTextBox.Text;
                    selectedAccount.Password = passwordTextBox.Text;
                    selectedAccount.JobTitle = jobTitleTextBox.Text;

                    SaveAccounts();
                    accountList.Items.Refresh();
                    ClearInputFields();
                }

            }
        }

        private void ClearInputFields()
        {
            employeeIdTextBox.Text = "";
            passwordTextBox.Text = "";
            jobTitleTextBox.Text = "";
        }

        private void AccountList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedAccount = accountList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                employeeIdTextBox.Text = selectedAccount.EmployeeId;
                passwordTextBox.Text = selectedAccount.Password;
                jobTitleTextBox.Text = selectedAccount.JobTitle;
            }
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
          
            var selectedAccount = accountList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                employeeIdTextBox.Text = selectedAccount.EmployeeId;
                passwordTextBox.Text = selectedAccount.Password;
                jobTitleTextBox.Text = selectedAccount.JobTitle;
            }
        }
    }
}