using DevPace.Shared.Enums;

namespace DevPace.WebApi.Common.Models
{
    public class CustomerFiltered : Customer
    {
        public bool? Ascending { get; set; } = true;
        public SortField? SortField { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
