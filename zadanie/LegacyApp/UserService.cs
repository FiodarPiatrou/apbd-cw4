using System;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditService;

        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
        }

        public UserService(IClientRepository clientRepository, ICreditLimitService userCreditService)
        {
            _clientRepository = clientRepository;
            _creditService = userCreditService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsValid(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var clientRepository = _clientRepository;
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            SetCreditLimit(user,client.Type);

            if (VerifyCreditLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }


        private bool IsValid(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            if (CalculateAge(dateOfBirth) < 21)
            {
                return false;
            }

            return true;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private bool VerifyCreditLimit(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        private void SetCreditLimit(User user, string clientType)
        {
            if (clientType == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (clientType == "ImportantClient")
            {
                var userCreditService = _creditService;
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                var userCreditService = _creditService;
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}