using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbflaggedcomment
{
    public long Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Text { get; set; }

    public long? CommentId { get; set; }

    public string? UserId { get; set; }

    public virtual Fbcomment? Comment { get; set; }

    public virtual Fbuser? User { get; set; }
}
