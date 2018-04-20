using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalproject.User
{
    class Users
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private string password;
        private string education;
        private string address1;
        private string address2;
        private string city;
        private string province;
        private string jobType;
        private string zipCode;

        public Users( string firstName, string lastName, string phoneNumber, string email, string password, string education, string address1, string address2, string city, string province, string zipCode, string jobType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.password = password;
            this.education = education;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.province = province;
            this.jobType = jobType;
            this.zipCode = zipCode;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Education { get => education; set => education = value; }
        public string Address1 { get => address1; set => address1 = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string City { get => city; set => city = value; }
        public string Province { get => province; set => province = value; }
        public string JobType { get => jobType; set => jobType = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }

        public override string ToString()
        {
            // Next line is for debugging
            //return string.Format("{0}, {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10}, {11}", firstName, lastName, phoneNumber, email,password,education,address1,address2,city,province, zipCode, jobType);
            return string.Format("Thanks {0} {1}, for registeration for the job of {2} !", firstName, lastName, jobType );
        }
    }
}
