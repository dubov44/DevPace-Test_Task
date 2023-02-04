using DevPace.Domain.Models.Abstract;

namespace DevPace.Domain.Models
{
    public class Customer : AbstractBaseEntity
    {
        public string? Name { get; set; }

        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

    }
}
