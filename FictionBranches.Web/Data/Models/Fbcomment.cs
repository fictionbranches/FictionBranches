using System;
using System.Collections.Generic;
using FictionBranches.Web.Data.Interfaces;

namespace FictionBranches.Web.Data.Models;

public partial class Fbcomment : IDated
{
    public long Id { get; set; }
    
    public DateTime? Date { get; set; }

    public long? EpisodeGeneratedid { get; set; }

    public string? UserId { get; set; }

    public DateTime? Editdate { get; set; }

    public string? Text { get; set; }

    public string? EditorId { get; set; }

    public bool Modvoice { get; set; }

    public virtual Fbuser? Editor { get; set; }

    public virtual Fbepisode? EpisodeGenerated { get; set; }

    public virtual ICollection<Fbflaggedcomment> Fbflaggedcomments { get; set; } = new List<Fbflaggedcomment>();

    public virtual ICollection<Fbnotification> Fbnotifications { get; set; } = new List<Fbnotification>();

    public virtual Fbuser? User { get; set; }
}
