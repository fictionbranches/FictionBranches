using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbrecentuserblock
{
    public long Id { get; set; }

    public DateTime? Date { get; set; }

    public string? BlockeduserId { get; set; }

    public string? BlockinguserId { get; set; }

    public virtual Fbuser? Blockeduser { get; set; }

    public virtual Fbuser? Blockinguser { get; set; }
}
