using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbemailchange
{
    public string Token { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string? Newemail { get; set; }

    public string? UserId { get; set; }

    public virtual Fbuser? User { get; set; }
}
