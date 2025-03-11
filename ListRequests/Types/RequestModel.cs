namespace ListRequests.Types;

public class RequestModel
{
    public int? RequestId { get; set; }
    public DateTime? StartDate { get; set; }
    public string? HomeTechType { get; set; } = string.Empty;
    public string? HomeTechModel { get; set; } = string.Empty;
    public string? ProblemDescription { get; set; } = string.Empty;
    public string? RequestStatus { get; set; } = string.Empty;
    public DateTime? CompletionDate { get; set; }
    public string? RepairParts { get; set; } = string.Empty;
    public int? MasterId { get; set; }
    public int? UserId { get; set; }
}