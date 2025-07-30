using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbtheme
{
    public string Name { get; set; } = null!;

    public string? Css { get; set; }

    public virtual ICollection<Fbuser> Fbusers { get; set; } = new List<Fbuser>();
}
