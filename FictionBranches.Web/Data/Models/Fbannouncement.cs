using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbannouncement
{
    public long Id { get; set; }

    public string? Body { get; set; }

    public DateTime? Date { get; set; }

    public string? AuthorId { get; set; }

    public virtual Fbuser? Author { get; set; }

    public virtual ICollection<Fbannouncementview> Fbannouncementviews { get; set; } = new List<Fbannouncementview>();
}
