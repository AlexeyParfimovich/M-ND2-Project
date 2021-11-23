namespace MyFinance.DAL.Entities
{
    public class UserEntity: BaseEntity<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

    }
}
