using System.ComponentModel.DataAnnotations;

namespace FictionBranches.Web.Constants;

public enum ChildSort
{
    [Display(Name = "Oldest first (default)", ShortName = ChildSortHelper.OldestFirst)]
    OldestFirst = 0,
    [Display(Name = "Newest first", ShortName = ChildSortHelper.NewestFirst)]
    NewestFirst,
    [Display(Name = "Children (descending)", ShortName = ChildSortHelper.ChildrenDescending)]
    ChildrenDescending,
    [Display(Name = "Children (ascending)", ShortName = ChildSortHelper.ChildrenAscending)]
    ChildrenAscending,
    [Display(Name = "Random", ShortName = ChildSortHelper.Random)]
    Random
}

public static class ChildSortHelper
{

    public const string OldestFirst = "oldest";
    public const string NewestFirst = "newest";
    public const string ChildrenDescending = "mostfirst";
    public const string ChildrenAscending = "leastfirst";
    public const string Random = "random";
    
    public static ChildSort GetFromShortName(string shortName)
    {
        return shortName switch
        {
            ChildrenAscending => ChildSort.ChildrenAscending,
            ChildrenDescending => ChildSort.ChildrenDescending,
            Random => ChildSort.Random,
            NewestFirst => ChildSort.NewestFirst,
            _ => ChildSort.OldestFirst
        };
    }
}