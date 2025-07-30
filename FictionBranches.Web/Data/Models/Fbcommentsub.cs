using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbcommentsub
{
    public long Id { get; set; }

    public DateTime? Date { get; set; }

    public long? EpisodeGeneratedid { get; set; }

    public string? UserId { get; set; }

    public virtual Fbepisode? EpisodeGenerated { get; set; }

    public virtual Fbuser? User { get; set; }
}
