using Microsoft.Data.SqlClient;

namespace DevPace.EntityFramework.Services.Helpers
{
    internal class SqlParametersHelper
    {
        public SqlParameter? Name { get; set; }
        public SqlParameter? CompanyName { get; set; }
        public SqlParameter? Email { get; set; }
        public SqlParameter? Phone { get; set; }
        public SqlParameter? Ascending { get; set; }
        public SqlParameter? SortField { get; set; }
        public SqlParameter Skip { get; set; }
        public SqlParameter Take { get; set; }
        public SqlParameter OverallCount { get; set; }
    }
}
