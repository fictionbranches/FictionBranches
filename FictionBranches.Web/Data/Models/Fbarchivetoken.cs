using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbarchivetoken
{
    public long Id { get; set; }

    public string? Comment { get; set; }

    public DateTime? Date { get; set; }

    public string? Token { get; set; }
}
