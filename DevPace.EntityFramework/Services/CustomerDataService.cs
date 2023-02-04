using System.Data;
using DevPace.Domain.Models;
using DevPace.Domain.Services;
using DevPace.EntityFramework.Services.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DevPace.EntityFramework.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly DevPaceDbContextOptionsFactory _contextFactory;

        public CustomerDataService(DevPaceDbContextOptionsFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<Tuple<IEnumerable<Customer>, int>> GetFilteredAsync(CustomerSearch filteredCustomer)
        {
            await using DevPaceDbContext context = _contextFactory.CreateDbContext();

            SqlParametersHelper sqlParameters = SetSqlParameters(filteredCustomer);
            
            var customers = await context.Set<Customer>().FromSql($"CustomerSearch @name = {sqlParameters.Name}, @companyName = {sqlParameters.CompanyName}, @email = {sqlParameters.Email}, @phone = {sqlParameters.Phone}, @ascending = {sqlParameters.Ascending}, @sortField= {sqlParameters.SortField}, @skip = {sqlParameters.Skip}, @take = {sqlParameters.Take}, @overallCount = {sqlParameters.OverallCount} OUTPUT").ToListAsync();

            int overallCount = (int)sqlParameters.OverallCount.Value;

            return new Tuple<IEnumerable<Customer>, int>(customers, overallCount);
        }

        private SqlParametersHelper SetSqlParameters(CustomerSearch filteredCustomer)
        {
            SqlParametersHelper helper = new SqlParametersHelper
            {
                Name = filteredCustomer.Name is not null
                    ? new SqlParameter
                    {
                        ParameterName = "name",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Value = filteredCustomer.Name,
                    }
                    : null,
                CompanyName = filteredCustomer.CompanyName is not null
                    ? new SqlParameter
                    {
                        ParameterName = "companyName",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 10,
                        Value = filteredCustomer.CompanyName,
                    }
                    : null,
                Email = filteredCustomer.Email is not null
                    ? new SqlParameter
                    {
                        ParameterName = "email",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Value = filteredCustomer.Email,
                    }
                    : null,
                Phone = filteredCustomer.Phone is not null
                    ? new SqlParameter
                    {
                        ParameterName = "phone",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Value = filteredCustomer.Phone,
                    }
                    : null,
                Ascending = filteredCustomer.Ascending is not null
                    ? new SqlParameter
                    {
                        ParameterName = "ascending",
                        SqlDbType = SqlDbType.Bit,
                        Value = filteredCustomer.Ascending,
                    }
                    : null,
                SortField = filteredCustomer.SortField is not null
                    ? new SqlParameter
                    {
                        ParameterName = "sortField",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 50,
                        Value = filteredCustomer.SortField,
                    }
                    : null,
                Skip = new SqlParameter
                    {
                        ParameterName = "skip",
                        SqlDbType = SqlDbType.Int,
                        Value = filteredCustomer.Skip,
                    },
                Take = new SqlParameter
                    {
                        ParameterName = "take",
                        SqlDbType = SqlDbType.Int,
                        Value = filteredCustomer.Take,
                    },
                OverallCount = new SqlParameter
                {
                    ParameterName = "overallCount",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                }
            };

            return helper;
        }
    }
}
