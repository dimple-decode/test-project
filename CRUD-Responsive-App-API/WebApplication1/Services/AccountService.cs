using CRUD_Resonsive_Web_API.Interfaces;
using CRUD_Resonsive_Web_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Resonsive_Web_API.Services
{
    public class AccountService : IAccountService
    {
        private IDictionary<string, (string password, Account account)> _account;

        public AccountService(IDictionary<string, string> credentials)
        {
            _account = new Dictionary<string, (string password, Account account)>();
            foreach(var credential in credentials)
            {
                _account.Add(credential.Key.ToLower(), (credential.Value, new Account(credential.Key)));
            }
        }
        public Task<bool> ValidateCredentials(string username, string password, out Account account)
        {
            account = null;
            username = username.ToLower();
            if (_account.ContainsKey(username) && password.Equals(_account[username].password)){
                account = _account[username].account;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
