using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbtag
{
    public long Id { get; set; }

    public long Createddate { get; set; }

    public string? Description { get; set; }

    public string? Longname { get; set; }

    public string Shortname { get; set; } = null!;

    public string? CreatedbyId { get; set; }

    public long Editeddate { get; set; }

    public string? EditedbyId { get; set; }

    public virtual Fbuser? Createdby { get; set; }

    public virtual Fbuser? Editedby { get; set; }

    public virtual ICollection<Fbepisodetag> Fbepisodetags { get; set; } = new List<Fbepisodetag>();
}
