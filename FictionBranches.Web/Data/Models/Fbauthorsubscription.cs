using System;
using System.Collections.Generic;

namespace FictionBranches.Web.Data.Models;

public partial class Fbauthorsubscription
{
    public long Id { get; set; }

    public long Createddate { get; set; }

    public string? SubscribedtoId { get; set; }

    public string? SubscriberId { get; set; }

    public virtual Fbuser? Subscribedto { get; set; }

    public virtual Fbuser? Subscriber { get; set; }
}
