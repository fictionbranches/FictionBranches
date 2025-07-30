using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbpotentialuser
{
    public string Token { get; set; } = null!;

    public string? Author { get; set; }

    public DateTime? Date { get; set; }

    public string? Email { get; set; }

    public string? Passwordhash { get; set; }

    public string? Username { get; set; }
}
