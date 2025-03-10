using Npgsql;

namespace Master_Pol.Database.Testing.Moq;

public class DatabaseService : IDatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public decimal? GetProductCoefficient(int productTypeId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT coefficient FROM product_types WHERE id = @product_type_id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("product_type_id", productTypeId);
                object result = command.ExecuteScalar();
                return result is decimal ? (decimal?)result : null;
            }
        }
    }

    public decimal? GetWastePercentage(int materialTypeId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT defect_percentage FROM material_types WHERE id = @material_type_id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("material_type_id", materialTypeId);
                object result = command.ExecuteScalar();
                return result is decimal ? (decimal?)result : null;
            }
        }
    }
}