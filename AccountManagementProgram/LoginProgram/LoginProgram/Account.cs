using System;

namespace LoginProgram 
{
    public class Account
    {
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public DateTime LastLogin { get; set; }

        public Account(string employeeId, string password, string jobTitle, DateTime lastLogin)
        {
            EmployeeId = employeeId;
            Password = password;
            JobTitle = jobTitle;
            LastLogin = lastLogin;
        }

        public Account() { } 
    }
}