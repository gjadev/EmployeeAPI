using EmployeeAPI.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace EmployeeAPI.Repositories.Tests
{
    public abstract class TestWithSqlite: IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private SqliteConnection _connection;

        protected EmployeeDbContext EmployeeDbContext;

        public void CreateSqliteContext()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseSqlite(_connection)
                .Options;
            EmployeeDbContext = new EmployeeDbContext(options);
            EmployeeDbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        [SetUp]
        public void InitialSetup()
        {
            CreateSqliteContext();
        }

        [TearDown]
        public void FinalTearDown()
        {
            Dispose();
        }
    }
}
