using System;

namespace LegacyApp
{
    public class User
    {
        private Client _client;
        private DateTime _dateOfBirth;
        private string _email;
        private string _firstName;
        private string _lastName;
        private bool _hasCreditLimit;
        private int _creditLimit;
       

        

        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public void SetCreditLimit(string clientType)
        {
            
            
        }
        private bool VerifyName(string firstName, string lastName)
        {
            return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
        }
    }
}