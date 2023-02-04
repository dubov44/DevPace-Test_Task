using DevPace.Shared.Enums;

namespace DevPace.Domain.Models
{
    public class CustomerSearch : Customer
    {
        public bool? Ascending { get; set; } = true;
        public SortField? SortField { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
