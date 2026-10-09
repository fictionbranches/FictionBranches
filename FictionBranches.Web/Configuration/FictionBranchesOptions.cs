namespace FictionBranches.Web.Configuration;

public class FictionBranchesOptions
{
    public const string Section = "FictionBranches";
    public required bool DevMode { get; init; }
    public required int PageSize { get; init; }
    public required string SmtpUsername { get; init; }
    public required string SmtpPassword { get; init; }
    public required string SmtpServer { get; init; }
    public required int SmtpPort { get; init; }
    public required string SmtpSendAs { get; init; }
}