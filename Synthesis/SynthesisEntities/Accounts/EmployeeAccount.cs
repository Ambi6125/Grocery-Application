using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisEntities.Accounts
{
    public class EmployeeAccount : Account
    {
        private DateTime _birthdate;
        public DateTime Birthday
        {
            get => _birthdate;
            set
            {
                if(value.Date > DateTime.Today.AddYears(-18).Date)
                {
                    throw new ArgumentException("Employees must be at least 18 years old.");
                }
                _birthdate = value.Date;
            }
        }
        public EmployeeAccount(string username, string password, string email, DateTime birthdate) : base(username, password, email)
        {
            if (birthdate.Date > DateTime.Today.AddYears(-18).Date)
            {
                throw new ArgumentException("Employees must be at least 18 years old.");
            }
            _birthdate = birthdate.Date;
        }

        public EmployeeAccount(int id, string username, string salt, string password, string email, DateTime birthdate)
            :base(id, username, salt, password, email)
        {
            _birthdate = birthdate.Date;
        }
    }
}
