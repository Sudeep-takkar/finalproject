using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace finalproject
{
    class Authonticate
    {
        public string USER_DATA = @"..\..\Xmls\user.xml";
        DataSet dataSet = new DataSet();
        private finalproject.User.Users logIn = new finalproject.User.Users();
        public finalproject.User.Users AuthonticateUser( string email, string password )
        {
            try
            {
                
                if (File.Exists(USER_DATA))
                {
                    string userId = "";
                    string accountType = "";
                    string firstName = "";
                    string lastName = "";

                    XElement doc = XElement.Load(USER_DATA);
                    IEnumerable<XElement> childList =
                        from el in doc.Descendants("user")
                        where (string)el.Element("email") == email &&
                              (string)el.Element("password") == password
                        select el;

                    foreach (XElement e in childList)
                    {
                        userId = e.Element("userId").Value;
                        accountType = e.Element("accountType").Value;
                        firstName = e.Element("firstName").Value;
                        lastName = e.Element("lastName").Value;
                    }
                    logIn.LogIn(userId, accountType, firstName, lastName, email);
                    return logIn;
                }
                else
                {
                    
                    throw new System.ArgumentException("Configuration error!", "original");
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString(), "original"); 
            }

        }
    }
}
