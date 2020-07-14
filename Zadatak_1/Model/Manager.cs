using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1.Model
{
    public class Manager
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public int Account { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sector { get; set; }
        public string AccessLevel { get; set; }

        public Manager()
        {
        }

        public Manager(int id, string firstName, string lastName, DateTime dateOfBirth, string jMBG, int account, string email, int salary, string position, string username, string password, string accessLevel)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JMBG = jMBG;
            Account = account;
            Email = email;
            Salary = salary;
            Position = position;
            Username = username;
            Password = password;
            AccessLevel = accessLevel;
        }
    }
}
