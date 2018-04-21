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
        private finalproject.User.Users userObject = null;

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
                    string jobType = "";
                    string phone = "";
                    string address1 = "";
                    string address2 = "";
                    string city = "";
                    string province = "";
                    string zipCode = "";
                    string education = "";
                    string phoneNumber = "";

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
                        jobType = e.Element("jobType").Value;
                        phone = e.Element("phone").Value;
                        address1 = e.Element("address1").Value;
                        address2 = e.Element("address2").Value;
                        city = e.Element("city").Value;
                        province = e.Element("province").Value;
                        zipCode = e.Element("zipCode").Value;
                        education = e.Element("education").Value;
                        phoneNumber = e.Element("phone").Value;
                    }
                    logIn.LogIn(userId, accountType, firstName, lastName, email, jobType, phone,address1,address2,city,province,zipCode,education,phoneNumber);
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
        public finalproject.User.Users GetUsersDetails(string userId)
        {           
            try
            {
                XElement outPut = null;
                if (File.Exists(USER_DATA))
                {
                    XElement doc = XElement.Load(USER_DATA);
                    IEnumerable<XElement> childList =
                        from el in doc.Descendants("user")
                        where (string)el.Element("userId") == userId
                        select el;                    
                    foreach (XElement e in childList)
                    {
                        outPut = e;
                    }
                    finalproject.User.Users userObject = new finalproject.User.Users(outPut.Element("firstName").Value, outPut.Element("lastName").Value, outPut.Element("phone").Value, outPut.Element("email").Value, outPut.Element("password").Value, outPut.Element("education").Value, outPut.Element("address1").Value, outPut.Element("address2").Value, outPut.Element("city").Value, outPut.Element("province").Value, outPut.Element("zipCode").Value, outPut.Element("jobType").Value);
                    return userObject;
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
