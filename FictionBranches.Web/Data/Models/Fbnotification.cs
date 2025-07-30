using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbnotification
{
    public long Id { get; set; }

    public string? Body { get; set; }

    public DateTime? Date { get; set; }

    public bool Read { get; set; }

    public string? UserId { get; set; }

    public string? Type { get; set; }

    public long? CommentId { get; set; }

    public long? EpisodeGeneratedid { get; set; }

    public bool? Approved { get; set; }

    public string? SenderId { get; set; }

    public virtual Fbcomment? Comment { get; set; }

    public virtual Fbepisode? EpisodeGenerated { get; set; }

    public virtual Fbuser? Sender { get; set; }

    public virtual Fbuser? User { get; set; }
}
