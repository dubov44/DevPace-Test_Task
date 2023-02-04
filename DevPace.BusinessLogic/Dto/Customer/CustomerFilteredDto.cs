using DevPace.Shared.Enums;

namespace DevPace.BusinessLogic.Dto.Customer
{
    public class CustomerFilteredDto : CustomerDto
    {
        public bool? Ascending { get; set; } = true;
        public SortField? SortField { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
