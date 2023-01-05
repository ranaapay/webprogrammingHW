namespace floristWebApi.Dtos
{
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
