using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalproject.User
{
    class Appointments
    {
    	private string name;
        private string email;
        private string jobType;
        private string date;
        private string time;
        private string status;
        private string userId;

        public Appointments(string name, string email, string jobType, string date, string time, string status, string userId)
        {
            this.Name = name;
            this.Email = email;
            this.JobType = jobType;
            this.Date = date;
            this.Time = time;
            this.Status = status;
            this.userId = userId;
        }

        public Appointments(string date, string time, string status)
        {
            this.Date = date;
            this.Time = time;
            this.Status = status;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string JobType { get => jobType; set => jobType = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Status { get => status; set => status = value; }
        public string UserId { get => userId; set => userId = value; }
    }

}
