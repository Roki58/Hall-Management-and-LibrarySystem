namespace BlogPost.Application.Dto.Response
{
    public class UserResponse
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HallName { get; set; }
        public string? StudentId { get; set; }
        public string? MobileNumber { get; set; }

        public required string Email { get; set; }
    }

    public class UserLoginResponse : UserResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
