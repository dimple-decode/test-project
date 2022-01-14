namespace CRUD_Resonsive_Web_API.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class Account
    {
        public string Username { get; set; }

        public Account(string username)
        {
            Username = username;
        }
    }
}
