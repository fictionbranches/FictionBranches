using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbepisodetag
{
    public long Id { get; set; }

    public long Taggeddate { get; set; }

    public long? EpisodeGeneratedid { get; set; }

    public long? TagId { get; set; }

    public string? TaggedbyId { get; set; }

    public virtual Fbepisode? EpisodeGenerated { get; set; }

    public virtual Fbtag? Tag { get; set; }

    public virtual Fbuser? Taggedby { get; set; }
}
