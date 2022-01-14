using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Models
{
    public class UserAuth
    {
        public string Username { get; set; }
        public string BearerToken { get; set; }
        public List<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
