using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public IEnumerable<Product> GetAll()
    {
        using (var connection = GetOpenConnection())
        {
            return connection.Query<Product>("SELECT * FROM Products");
        }
    }

    public Product GetById(int id)
    {
        using (var connection = GetOpenConnection())
        {
            return connection.QuerySingleOrDefault<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
        }
    }

    public void Add(Product product)
    {
        using (var connection = GetOpenConnection())
        {
            connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", product);
        }
    }

    public void Update(Product product)
    {
        using (var connection = GetOpenConnection())
        {
            connection.Execute("UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id", product);
        }
    }

    public void Delete(int id)
    {
        using (var connection = GetOpenConnection())
        {
            connection.Execute("DELETE FROM Products WHERE Id = @Id", new { Id = id });
        }
    }

    private IDbConnection GetOpenConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    internal void Delete(Product product)
    {
        throw new NotImplementedException();
    }
}
