namespace FictionBranches.Web.Configuration;

public class FictionBranchesOptions
{
    public const string Section = "FictionBranches";
    public required int PageSize { get; init; }
}