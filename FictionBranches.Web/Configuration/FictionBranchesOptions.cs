namespace FictionBranches.Web.Configuration;

public class FictionBranchesOptions
{
    public const string Section = "FictionBranches";
    public required bool DevMode { get; init; }
    public required int PageSize { get; init; }
}