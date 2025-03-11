using ListRequests.DatabaseAction;
using ListRequests.Types;
using Npgsql;

namespace ListRequestsTests;

[TestClass]
public sealed class ListRquestsTests
{
    private Database _db = new Database();

    [TestMethod]
    public void LoginSuccessTest()
    {
        string login = "test5";
        string password = "test5";

        (string, int) result = _db.Login(login, password);

        Assert.AreNotEqual(-1, result.Item2);
    }

    [TestMethod]
    public void LoginFailureTest()
    {
        string login = "test5";
        string password = "test";

        (string, int) result = _db.Login(login, password);

        Assert.AreEqual(-1, result.Item2);
    }

    [TestMethod]
    public void GetRequestsTest()
    {
        string type = "Оператор";
        int userId = 2;

        List<RequestModel> requests = _db.GetRequests(type, userId);

        Assert.IsNotNull(requests);
    }

    [TestMethod]
    public void GetMastersTest()
    {
        List<MasterModel> masters = _db.GetMasters();

        Assert.IsNotNull(masters);
    }

    [TestMethod]
    public void IsRequestAvailableForMasterAssignmentTest1()
    {
        NpgsqlConnection conn = _db.GetConnection();
        conn.Open();

        bool isAvailable = _db.IsRequestAvailableForMasterAssignment(conn, 6);
        
        Assert.IsTrue(isAvailable);
    }

    [TestMethod]
    public void IsRequestAvailableForMasterAssignmentTest2()
    {
        NpgsqlConnection conn = _db.GetConnection();
        conn.Open();

        bool isAvailable = _db.IsRequestAvailableForMasterAssignment(conn, 5);

        Assert.IsFalse(isAvailable);
    }

    [TestMethod]
    public void GetEmptyCommentAndRepairPartTest()
    {
        (string, string) result = _db.GetCommentAndRepairPart(6);

        Assert.AreEqual("", result.Item1);
    }

    [TestMethod]
    public void GetNoEmptyCommentAndRepairPartTest()
    {
        (string, string) result = _db.GetCommentAndRepairPart(5);

        Assert.AreNotEqual("", result.Item1);
    }

    [TestMethod]
    public void UpdateProcessRequestStatusTest()
    {
        int reqId = 6;
        string status = "В процессе ремонта";

        bool isSuccess = _db.UpdateProcessStatusRequest(reqId, status);

        Assert.IsTrue(isSuccess);
    }
}