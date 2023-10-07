using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public abstract class Account
    {
        private int _id;
        private string _password;
        private Person _person;
        private AccountStatus _status;

        protected Account(int id, string password, Person person, AccountStatus status)
        {
            Id = id;
            Password = password;
            Person = person;
            Status = status;
        }

        public int Id { get => _id; set => _id = value; }
        public string Password { get => _password; set => _password = value; }
        public Person Person { get => _person; set => _person = value; }
        public AccountStatus Status { get => _status; set => _status = value; }
    }
}
