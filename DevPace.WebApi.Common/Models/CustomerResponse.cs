namespace DevPace.WebApi.Common.Models
{
    public class CustomerResponse
    {
        public IEnumerable<Customer> Customers { get; set; }

        public int Count { get; set; }
    }
}
