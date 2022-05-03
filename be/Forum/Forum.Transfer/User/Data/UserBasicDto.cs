namespace Forum.Transfer.User.Data
{
    public class UserBasicDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchival { get; set; }
    }
}
