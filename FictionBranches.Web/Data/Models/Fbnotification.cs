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
    
    public const string LEGACY_NOTE="legacy_note";
    public const string NEW_CHILD_EPISODE="new_child_episode";
    public const string NEW_COMMENT_ON_OWN_EPISODE="new_comment_on_own_episode";
    public const string NEW_COMMENT_ON_SUBBED_EPISODE="new_comment_on_subbed_episode";
    public const string MODIFICATION_RESPONSE="modification_response";
    public const string NEW_AUTHOR_SUBSCRIPTION_EPISODE="new_author_subscription_episode";
}
