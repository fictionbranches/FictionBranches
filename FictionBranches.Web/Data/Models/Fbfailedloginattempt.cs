using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbfailedloginattempt
{
    public long Id { get; set; }

    public string? Ip { get; set; }

    public long Timestamp { get; set; }
}
