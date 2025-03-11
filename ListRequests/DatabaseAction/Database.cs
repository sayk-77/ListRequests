using System.Xml;
using ListRequests.Types;
using Npgsql;

namespace ListRequests.DatabaseAction;

public class Database
{
    private readonly string _connectionString = "Server=localhost; Port=5432; Database=ListRequestsDatabase; User Id=postgres; Password=postgres; CommandTimeout=120;";
    
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    public (string, int) Login(string login, string password)
    {
        using var connection = GetConnection();
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT userId, type, password FROM users WHERE login = @login";
        command.Parameters.AddWithValue("login", login);
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            var userPassword = reader.GetString(reader.GetOrdinal("password"));
            var userId = reader.GetInt32(reader.GetOrdinal("userId"));
            var type = reader.GetString(reader.GetOrdinal("type"));

            if (password == userPassword)
            {
                return (type, userId);
            }
        }
        return ("", -1);
    }

    public List<RequestModel> GetRequests(string type, int userId)
    {
        List<RequestModel> requests = new List<RequestModel>();
        
        using var connection = GetConnection();
        connection.Open();
        
        using var command = connection.CreateCommand();

        if (type == "Оператор")
        {
            command.CommandText = "SELECT * FROM requests";
        } else if (type == "Мастер")
        {
            command.CommandText = "SELECT * FROM requests WHERE masterId = @id";
            command.Parameters.AddWithValue("id", userId);
        }
        else
        {
            command.CommandText = "SELECT * FROM requests WHERE clientId = @userId";
            command.Parameters.AddWithValue("userId", userId);
        }
        
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            RequestModel request = new RequestModel
            {
                RequestId = reader.GetInt32(reader.GetOrdinal("requestId")),
                UserId = reader.GetInt32(reader.GetOrdinal("clientId")),
                StartDate = reader.GetDateTime(reader.GetOrdinal("startDate")),
                HomeTechModel = reader.GetString(reader.GetOrdinal("homeTechModel")),
                HomeTechType = reader.GetString(reader.GetOrdinal("homeTechType")),
                ProblemDescription = reader.GetString(reader.GetOrdinal("problemDescription")),
                RequestStatus = reader.GetString(reader.GetOrdinal("requestStatus")),
                CompletionDate = reader.IsDBNull(reader.GetOrdinal("completionDate")) 
                    ? (DateTime?)null 
                    : reader.GetDateTime(reader.GetOrdinal("completionDate")),
                RepairParts = reader.IsDBNull(reader.GetOrdinal("repairParts")) 
                    ? null 
                    : reader.GetString(reader.GetOrdinal("repairParts")),
                MasterId = reader.IsDBNull(reader.GetOrdinal("masterId")) 
                    ? (int?)null 
                    : reader.GetInt32(reader.GetOrdinal("masterId"))
            };

            requests.Add(request);
        }

        return requests;
    }

    public bool DeleteRequest(int requestId)
    { 
        using var connection = GetConnection();
        try
        {
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM requests WHERE requestId = @requestId";
            command.Parameters.AddWithValue("requestId", requestId);

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return false;
    }

    public bool AddRequest(RequestModel request)
    {
        using var connection = GetConnection();
        try
        {
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO requests (
                clientId, 
                startDate, 
                homeTechType, 
                homeTechModel, 
                problemDescription, 
                requestStatus, 
                completionDate, 
                repairParts, 
                masterId
            ) VALUES (
                @clientId, 
                @startDate, 
                @homeTechType, 
                @homeTechModel, 
                @problemDescription, 
                @requestStatus, 
                @completionDate, 
                @repairParts, 
                @masterId
            )";

            command.Parameters.AddWithValue("clientId", request.UserId);
            command.Parameters.AddWithValue("startDate", request.StartDate);
            command.Parameters.AddWithValue("homeTechType", request.HomeTechType ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("homeTechModel", request.HomeTechModel ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("problemDescription", request.ProblemDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("requestStatus", request.RequestStatus ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("completionDate", request.CompletionDate.HasValue ? (object)request.CompletionDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("repairParts", request.RepairParts ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("masterId", request.MasterId.HasValue ? (object)request.MasterId.Value : DBNull.Value);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
        return false;
    }


    public bool EditRequest(RequestModel request)
    {
        using var connection = GetConnection();
        try
        {
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE requests
                SET 
                    homeTechModel = @homeTechModel,
                    homeTechType = @homeTechType,
                    problemDescription = @problemDescription
                WHERE requestId = @requestId
            ";

            command.Parameters.AddWithValue("requestId", request.RequestId);
            command.Parameters.AddWithValue("homeTechModel", request.HomeTechModel);
            command.Parameters.AddWithValue("homeTechType", request.HomeTechType);
            command.Parameters.AddWithValue("problemDescription", request.ProblemDescription);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return false;
    }

    public List<MasterModel> GetMasters()
    {
        using var connection = GetConnection();
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT userId, fio from users where type = @type";
        command.Parameters.AddWithValue("type", "Мастер");
        
        using var reader = command.ExecuteReader();
        
        List<MasterModel> masters = new List<MasterModel>();

        var index = 0;
        
        while (reader.Read())
        {
            MasterModel master = new MasterModel
            {
                Id = index++,
                MasterId = reader.GetInt32(reader.GetOrdinal("userId")),
                MasterName = reader.GetString(reader.GetOrdinal("fio"))
            };
            masters.Add(master);
        }
        
        return masters;
    }

    public bool SelectMaster(int requestId, int masterId)
    {
        using var connection = GetConnection();
        connection.Open();
        
        if (!IsRequestAvailableForMasterAssignment(connection, requestId))
        {
            return false;
        }

        return AssignMasterToRequest(connection, requestId, masterId);
    }

    public bool IsRequestAvailableForMasterAssignment(NpgsqlConnection connection, int requestId)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT masterId FROM requests WHERE requestId = @requestId";
        command.Parameters.AddWithValue("requestId", requestId);

        object result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
        {
            return true;
        }

        return false;
    }

    private bool AssignMasterToRequest(NpgsqlConnection connection, int requestId, int masterId)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE requests SET masterId = @masterId WHERE requestId = @requestId";
        command.Parameters.AddWithValue("masterId", masterId);
        command.Parameters.AddWithValue("requestId", requestId);

        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public (string comment, string repairPart) GetCommentAndRepairPart(int requestId)
    {
        string comment = "";
        string repairPart = "";
        
        using var connection = GetConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT 
                                    COALESCE(r.repairParts, '') AS repairParts,
                                    COALESCE(c.message, '') AS message
                                FROM requests AS r 
                                JOIN comments AS c ON r.requestId = c.requestId
                                WHERE r.requestId = @requestId";
        command.Parameters.AddWithValue("requestId", requestId);
        
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            repairPart = reader.GetString(reader.GetOrdinal("repairParts"));
            comment = reader.GetString(reader.GetOrdinal("message"));
        }
        
        return (comment, repairPart);
    }

    public bool SaveDetailRequest(string comment, string repairPart, int masterId, int requestId)
    {
        using var connection = GetConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction();
        
        try
        {
            using var checkCommand = connection.CreateCommand();
            checkCommand.Transaction = transaction;
            checkCommand.CommandText = @"
                SELECT COUNT(*) 
                FROM comments 
                WHERE requestId = @requestId AND masterId = @masterId";
            
            checkCommand.Parameters.AddWithValue("@requestId", requestId);
            checkCommand.Parameters.AddWithValue("@masterId", masterId);

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            if (count > 0)
            {
                using var updateCommand = connection.CreateCommand();
                updateCommand.Transaction = transaction;
                updateCommand.CommandText = @"
                    UPDATE comments
                    SET message = @message
                    WHERE requestId = @requestId AND masterId = @masterId";
                
                updateCommand.Parameters.AddWithValue("@requestId", requestId);
                updateCommand.Parameters.AddWithValue("@masterId", masterId);
                updateCommand.Parameters.AddWithValue("@message", comment);
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                using var insertCommand = connection.CreateCommand();
                insertCommand.Transaction = transaction;
                insertCommand.CommandText = @"
                    INSERT INTO comments (message, masterId, requestId)
                    VALUES (@message, @masterId, @requestId)";
                
                insertCommand.Parameters.AddWithValue("@requestId", requestId);
                insertCommand.Parameters.AddWithValue("@masterId", masterId);
                insertCommand.Parameters.AddWithValue("@message", comment);
                insertCommand.ExecuteNonQuery();
            }

            using var command2 = connection.CreateCommand();
            command2.Transaction = transaction;
            command2.CommandText = @"
                UPDATE requests
                SET repairParts = @repairParts
                WHERE requestId = @requestId";
            
            command2.Parameters.AddWithValue("@requestId", requestId);
            command2.Parameters.AddWithValue("@repairParts", repairPart);
            command2.ExecuteNonQuery();

            transaction.Commit();
            return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            transaction.Rollback();
            return false;
        }
    }

    public bool UpdateCompleteStatusRequest(int requestId, string status, string repairPart)
    {
        using var connection = GetConnection();
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE requests SET requestStatus = @status, repairParts = @repairParts WHERE requestId = @requestId";
        command.Parameters.AddWithValue("@requestId", requestId);
        command.Parameters.AddWithValue("@status", status);
        command.Parameters.AddWithValue("@repairParts", repairPart);
        
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    public bool UpdateProcessStatusRequest(int requestId, string status)
    {
        using var connection = GetConnection();
        connection.Open();
        
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE requests SET requestStatus = @status WHERE requestId = @requestId";
        command.Parameters.AddWithValue("@requestId", requestId);
        command.Parameters.AddWithValue("@status", status);
        
        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }
    
}