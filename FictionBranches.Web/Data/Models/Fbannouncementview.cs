using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbannouncementview
{
    public long Id { get; set; }

    public long? AnnouncementId { get; set; }

    public string? ViewerId { get; set; }

    public virtual Fbannouncement? Announcement { get; set; }

    public virtual Fbuser? Viewer { get; set; }
}
