using Dapper;
using Microsoft.Data.SqlClient;
using Tadbir.DapperDataAccess;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Repositories;

namespace Tadbir.DapperDataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DapperContext _context;

        public PersonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Person domain)
        {
            using (var connection =_context.CreateConnection())
            {
                var sql = $"INSERT INTO {nameof(Person)} (Id,FirstName,LastName,Age) VALUES (@Id,@FirstName,@LastName,@Age)";
                var rowsAffected =await connection.ExecuteAsync(sql,domain,commandTimeout:1000);
            }
        }

        public async Task UpdateAsync(Person domain)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = $"UPDATE  {nameof(Person)} SET FirstName =@FirstName ," +
                    $"LastName=@LastName ," +
                    $"Age=@Age WHERE Id= @Id";
                var rowsAffected = await connection.ExecuteAsync(sql, domain);
            }
        }
    }
}
