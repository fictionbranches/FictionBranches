using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbloginban
{
    public string Ip { get; set; } = null!;

    public int Bancount { get; set; }

    public long Until { get; set; }
}
