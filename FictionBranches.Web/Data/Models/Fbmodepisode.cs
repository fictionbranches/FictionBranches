using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbmodepisode
{
    public long Id { get; set; }

    public string? Body { get; set; }

    public DateTime? Date { get; set; }

    public string? Link { get; set; }

    public string? Title { get; set; }

    public long? EpisodeGeneratedid { get; set; }

    public virtual Fbepisode? EpisodeGenerated { get; set; }
}
