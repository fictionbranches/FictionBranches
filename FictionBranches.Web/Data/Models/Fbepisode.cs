using System;
using System.Collections.Generic;
using FictionBranches.Web.Data.Interfaces;

namespace FictionBranches.Web.Data.Models;

public partial class Fbepisode : IDated
{
    public long Generatedid { get; set; }

    public string? Body { get; set; }

    public int Childcount { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? Editdate { get; set; }

    public string? Oldmap { get; set; }

    public string? Legacyid { get; set; }

    public string? Link { get; set; }

    public string? Title { get; set; }

    public string? AuthorId { get; set; }

    public string? EditorId { get; set; }

    public long? ParentGeneratedid { get; set; }

    public long Viewcount { get; set; }

    public string? Newmap { get; set; }

    public DateTime? Tagdate { get; set; }

    public virtual Fbuser? Author { get; set; }

    public virtual Fbuser? Editor { get; set; }

    public virtual ICollection<Fbcomment> Fbcomments { get; set; } = new List<Fbcomment>();

    public virtual ICollection<Fbcommentsub> Fbcommentsubs { get; set; } = new List<Fbcommentsub>();

    public virtual ICollection<Fbepisodetag> Fbepisodetags { get; set; } = new List<Fbepisodetag>();

    public virtual ICollection<Fbepisodeview> Fbepisodeviews { get; set; } = new List<Fbepisodeview>();

    public virtual ICollection<Fbfavep> Fbfaveps { get; set; } = new List<Fbfavep>();

    public virtual ICollection<Fbflaggedepisode> Fbflaggedepisodes { get; set; } = new List<Fbflaggedepisode>();

    public virtual ICollection<Fbmodepisode> Fbmodepisodes { get; set; } = new List<Fbmodepisode>();

    public virtual ICollection<Fbnotification> Fbnotifications { get; set; } = new List<Fbnotification>();

    public virtual ICollection<Fbupvote> Fbupvotes { get; set; } = new List<Fbupvote>();

    public virtual ICollection<Fbepisode> InverseParentGenerated { get; set; } = new List<Fbepisode>();

    public virtual Fbepisode? ParentGenerated { get; set; }
}
