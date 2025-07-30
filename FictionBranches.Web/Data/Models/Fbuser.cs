using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbuser
{
    public string Id { get; set; } = null!;

    public string? Author { get; set; }

    public string? Avatar { get; set; }

    public string? Bio { get; set; }

    public DateTime? Date { get; set; }

    public string? Email { get; set; }

    public short Level { get; set; }

    public string? Password { get; set; }

    public string? Theme { get; set; }

    public bool Commentsite { get; set; }

    public bool Commentmail { get; set; }

    public bool Childsite { get; set; }

    public bool Childmail { get; set; }

    public string? ThemeName { get; set; }

    public bool? Authorsubmail { get; set; }

    public bool? Authorsubsite { get; set; }

    public int? Bodytextwidth { get; set; }

    public bool Hideimages { get; set; }

    public virtual ICollection<Fbannouncement> Fbannouncements { get; set; } = new List<Fbannouncement>();

    public virtual ICollection<Fbannouncementview> Fbannouncementviews { get; set; } = new List<Fbannouncementview>();

    public virtual ICollection<Fbauthorsubscription> FbauthorsubscriptionSubscribedtos { get; set; } = new List<Fbauthorsubscription>();

    public virtual ICollection<Fbauthorsubscription> FbauthorsubscriptionSubscribers { get; set; } = new List<Fbauthorsubscription>();

    public virtual ICollection<Fbcomment> FbcommentEditors { get; set; } = new List<Fbcomment>();

    public virtual ICollection<Fbcomment> FbcommentUsers { get; set; } = new List<Fbcomment>();

    public virtual ICollection<Fbcommentsub> Fbcommentsubs { get; set; } = new List<Fbcommentsub>();

    public virtual ICollection<Fbemailchange> Fbemailchanges { get; set; } = new List<Fbemailchange>();

    public virtual ICollection<Fbepisode> FbepisodeAuthors { get; set; } = new List<Fbepisode>();

    public virtual ICollection<Fbepisode> FbepisodeEditors { get; set; } = new List<Fbepisode>();

    public virtual ICollection<Fbepisodetag> Fbepisodetags { get; set; } = new List<Fbepisodetag>();

    public virtual ICollection<Fbepisodeview> Fbepisodeviews { get; set; } = new List<Fbepisodeview>();

    public virtual ICollection<Fbfavep> Fbfaveps { get; set; } = new List<Fbfavep>();

    public virtual ICollection<Fbflaggedcomment> Fbflaggedcomments { get; set; } = new List<Fbflaggedcomment>();

    public virtual ICollection<Fbflaggedepisode> Fbflaggedepisodes { get; set; } = new List<Fbflaggedepisode>();

    public virtual ICollection<Fbnotification> FbnotificationSenders { get; set; } = new List<Fbnotification>();

    public virtual ICollection<Fbnotification> FbnotificationUsers { get; set; } = new List<Fbnotification>();

    public virtual ICollection<Fbpasswordreset> Fbpasswordresets { get; set; } = new List<Fbpasswordreset>();

    public virtual ICollection<Fbrecentuserblock> FbrecentuserblockBlockedusers { get; set; } = new List<Fbrecentuserblock>();

    public virtual ICollection<Fbrecentuserblock> FbrecentuserblockBlockingusers { get; set; } = new List<Fbrecentuserblock>();

    public virtual ICollection<Fbtag> FbtagCreatedbies { get; set; } = new List<Fbtag>();

    public virtual ICollection<Fbtag> FbtagEditedbies { get; set; } = new List<Fbtag>();

    public virtual ICollection<Fbupvote> Fbupvotes { get; set; } = new List<Fbupvote>();

    public virtual Fbtheme? ThemeNameNavigation { get; set; }
}
