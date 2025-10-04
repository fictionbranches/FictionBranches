using System;
using System.Collections.Generic;
using FictionBranches.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FictionBranches.Web.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fbannouncement> Fbannouncements { get; set; }

    public virtual DbSet<Fbannouncementview> Fbannouncementviews { get; set; }

    public virtual DbSet<Fbarchivetoken> Fbarchivetokens { get; set; }

    public virtual DbSet<Fbauthorsubscription> Fbauthorsubscriptions { get; set; }

    public virtual DbSet<Fbcomment> Fbcomments { get; set; }

    public virtual DbSet<Fbcommentsub> Fbcommentsubs { get; set; }

    public virtual DbSet<Fbemailchange> Fbemailchanges { get; set; }

    public virtual DbSet<Fbepisode> Fbepisodes { get; set; }

    public virtual DbSet<Fbepisodetag> Fbepisodetags { get; set; }

    public virtual DbSet<Fbepisodeview> Fbepisodeviews { get; set; }

    public virtual DbSet<Fbfailedloginattempt> Fbfailedloginattempts { get; set; }

    public virtual DbSet<Fbfavep> Fbfaveps { get; set; }

    public virtual DbSet<Fbflaggedcomment> Fbflaggedcomments { get; set; }

    public virtual DbSet<Fbflaggedepisode> Fbflaggedepisodes { get; set; }

    public virtual DbSet<Fbloginban> Fbloginbans { get; set; }

    public virtual DbSet<Fbmodepisode> Fbmodepisodes { get; set; }

    public virtual DbSet<Fbnotification> Fbnotifications { get; set; }

    public virtual DbSet<Fbpasswordreset> Fbpasswordresets { get; set; }

    public virtual DbSet<Fbpotentialuser> Fbpotentialusers { get; set; }

    public virtual DbSet<Fbrecentuserblock> Fbrecentuserblocks { get; set; }

    public virtual DbSet<Fbsitesetting> Fbsitesettings { get; set; }

    public virtual DbSet<Fbtag> Fbtags { get; set; }

    public virtual DbSet<Fbtheme> Fbthemes { get; set; }

    public virtual DbSet<Fbupvote> Fbupvotes { get; set; }

    public virtual DbSet<Fbuser> Fbusers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add Identity entity configurations
        // Configure Identity entities with their primary keys
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable("roles");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("userclaims");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("userlogins");
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("usertokens");
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("userroles");
            entity.HasKey(e => new { e.UserId, e.RoleId });
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("roleclaims");
            entity.HasKey(e => e.Id);
        });
        
        
        
        modelBuilder.Entity<Fbannouncement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbannouncements_pkey");

            entity.ToTable("fbannouncements");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(255)
                .HasColumnName("author_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");

            entity.HasOne(d => d.Author).WithMany(p => p.Fbannouncements)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("fk3xe75e0j9yttkprse44df77p9");
        });

        modelBuilder.Entity<Fbannouncementview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbannouncementviews_pkey");

            entity.ToTable("fbannouncementviews");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");
            entity.Property(e => e.ViewerId)
                .HasMaxLength(255)
                .HasColumnName("viewer_id");

            entity.HasOne(d => d.Announcement).WithMany(p => p.Fbannouncementviews)
                .HasForeignKey(d => d.AnnouncementId)
                .HasConstraintName("fknshw2jucw1p0s2cjq1wawj2wn");

            entity.HasOne(d => d.Viewer).WithMany(p => p.Fbannouncementviews)
                .HasForeignKey(d => d.ViewerId)
                .HasConstraintName("fk4ney7yabt558kvopprhqhr33b");
        });

        modelBuilder.Entity<Fbarchivetoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbarchivetokens_pkey");

            entity.ToTable("fbarchivetokens");

            entity.HasIndex(e => e.Token, "uk_2fq2h3p230ef6p1boflsarg64").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Token).HasColumnName("token");
        });

        modelBuilder.Entity<Fbauthorsubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbauthorsubscriptions_pkey");

            entity.ToTable("fbauthorsubscriptions");

            entity.HasIndex(e => new { e.SubscriberId, e.SubscribedtoId }, "uka07ci6945k3kc3hf1qxb7pk7m").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.SubscribedtoId)
                .HasMaxLength(255)
                .HasColumnName("subscribedto_id");
            entity.Property(e => e.SubscriberId)
                .HasMaxLength(255)
                .HasColumnName("subscriber_id");

            entity.HasOne(d => d.Subscribedto).WithMany(p => p.FbauthorsubscriptionSubscribedtos)
                .HasForeignKey(d => d.SubscribedtoId)
                .HasConstraintName("fkgbm3ft2df9nebw67f47yguoah");

            entity.HasOne(d => d.Subscriber).WithMany(p => p.FbauthorsubscriptionSubscribers)
                .HasForeignKey(d => d.SubscriberId)
                .HasConstraintName("fk7gq1evpy1cr9mxvplnxxupana");
        });

        modelBuilder.Entity<Fbcomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbcomments_pkey");

            entity.ToTable("fbcomments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Editdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("editdate");
            entity.Property(e => e.EditorId)
                .HasMaxLength(255)
                .HasColumnName("editor_id");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.Modvoice)
                .HasDefaultValue(false)
                .HasColumnName("modvoice");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Editor).WithMany(p => p.FbcommentEditors)
                .HasForeignKey(d => d.EditorId)
                .HasConstraintName("fk6rnmixm3m4dk7krre8atdctbs");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbcomments)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk344ylqk2chdvhmirf7076wqp6");

            entity.HasOne(d => d.User).WithMany(p => p.FbcommentUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkfwppbf9bst2pk7cf77cj58w8e");
        });

        modelBuilder.Entity<Fbcommentsub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbcommentsubs_pkey");

            entity.ToTable("fbcommentsubs");

            entity.HasIndex(e => new { e.EpisodeGeneratedid, e.UserId }, "uk1fi8d6b10aqv1ax6mk14kplnf").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbcommentsubs)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk9plrw0erv21vd4kq60993k520");

            entity.HasOne(d => d.User).WithMany(p => p.Fbcommentsubs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkqaru6fiei0w9qtxisx4q564sk");
        });

        modelBuilder.Entity<Fbemailchange>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("fbemailchanges_pkey");

            entity.ToTable("fbemailchanges");

            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Newemail).HasColumnName("newemail");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Fbemailchanges)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkdsbx42chvw1x9ppa19cpri4g8");
        });

        modelBuilder.Entity<Fbepisode>(entity =>
        {
            entity.HasKey(e => e.Generatedid).HasName("fbepisodes_pkey");

            entity.ToTable("fbepisodes");

            entity.HasIndex(e => e.Date, "ep_date_index");

            entity.HasIndex(e => e.Oldmap, "uk_5kqds4rxwiq5qh15urpctlac2").IsUnique();

            entity.Property(e => e.Generatedid)
                .ValueGeneratedNever()
                .HasColumnName("generatedid");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(255)
                .HasColumnName("author_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.Childcount).HasColumnName("childcount");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Editdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("editdate");
            entity.Property(e => e.EditorId)
                .HasMaxLength(255)
                .HasColumnName("editor_id");
            entity.Property(e => e.Legacyid)
                .HasMaxLength(255)
                .HasColumnName("legacyid");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.Newmap).HasColumnName("newmap");
            entity.Property(e => e.Oldmap).HasColumnName("oldmap");
            entity.Property(e => e.ParentGeneratedid).HasColumnName("parent_generatedid");
            entity.Property(e => e.Tagdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tagdate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Viewcount)
                .HasDefaultValue(0L)
                .HasColumnName("viewcount");

            entity.HasOne(d => d.Author).WithMany(p => p.FbepisodeAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("fk59nj53wh7qlje013erl884kbf");

            entity.HasOne(d => d.Editor).WithMany(p => p.FbepisodeEditors)
                .HasForeignKey(d => d.EditorId)
                .HasConstraintName("fkf2531iimwtfmjwwy8y0pj6r5k");

            entity.HasOne(d => d.ParentGenerated).WithMany(p => p.InverseParentGenerated)
                .HasForeignKey(d => d.ParentGeneratedid)
                .HasConstraintName("fk9g5au8ye310xeaa88f23in3vv");
        });

        modelBuilder.Entity<Fbepisodetag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbepisodetags_pkey");

            entity.ToTable("fbepisodetags");

            entity.HasIndex(e => e.TagId, "idx6glbrb9706ndl78n4po1q31p3");

            entity.HasIndex(e => e.TaggedbyId, "idx6wbgto5he13slswpm3muantap");

            entity.HasIndex(e => e.EpisodeGeneratedid, "idxclrec9v1rw5348dw9bjvas1tj");

            entity.HasIndex(e => e.Taggeddate, "idxfxkct3g8hdmh07qroh0hmgbgo");

            entity.HasIndex(e => new { e.EpisodeGeneratedid, e.TagId }, "uk5095m2mxm9rkn4ksataksfr0").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TaggedbyId)
                .HasMaxLength(255)
                .HasColumnName("taggedby_id");
            entity.Property(e => e.Taggeddate).HasColumnName("taggeddate");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbepisodetags)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fkckw00wx70serlw1kbawbcu7wk");

            entity.HasOne(d => d.Tag).WithMany(p => p.Fbepisodetags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fkqkytddc188eqxtuxnbywoiq42");

            entity.HasOne(d => d.Taggedby).WithMany(p => p.Fbepisodetags)
                .HasForeignKey(d => d.TaggedbyId)
                .HasConstraintName("fk6qb905bt9nkjiunnmovpj0rdf");
        });

        modelBuilder.Entity<Fbepisodeview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbepisodeviews_pkey");

            entity.ToTable("fbepisodeviews");

            entity.HasIndex(e => e.Date, "idx4075itwl1o036bys3ds2tsp60");

            entity.HasIndex(e => e.UserId, "idx9fjwfue99stcs4sxnijwuc4k0");

            entity.HasIndex(e => e.EpisodeGeneratedid, "idxccvjbggf4me4vbhhokfcxw4bg");

            entity.HasIndex(e => new { e.EpisodeGeneratedid, e.UserId }, "ukbhxqnt6rnqbmssnsbo9490wou").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbepisodeviews)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fkihpilnxwx6i1xeamjb1kl6bs1");

            entity.HasOne(d => d.User).WithMany(p => p.Fbepisodeviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkmyl1oym9gfcgr5vd4ifkka9bo");
        });

        modelBuilder.Entity<Fbfailedloginattempt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbfailedloginattempts_pkey");

            entity.ToTable("fbfailedloginattempts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ip)
                .HasMaxLength(255)
                .HasColumnName("ip");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<Fbfavep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbfaveps_pkey");

            entity.ToTable("fbfaveps");

            entity.HasIndex(e => new { e.EpisodeGeneratedid, e.UserId }, "ukkj448x377yghlrgiqyq5kjyr8").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbfaveps)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk7om33wahqw6v55fievvb2icme");

            entity.HasOne(d => d.User).WithMany(p => p.Fbfaveps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkeyolm2p18u6mqj8d5id9mlxqy");
        });

        modelBuilder.Entity<Fbflaggedcomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbflaggedcomments_pkey");

            entity.ToTable("fbflaggedcomments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Comment).WithMany(p => p.Fbflaggedcomments)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("fkotxfof7l9ns5q46qh2d2ptuym");

            entity.HasOne(d => d.User).WithMany(p => p.Fbflaggedcomments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fks7fhiw81skw4d3b637w58d2tq");
        });

        modelBuilder.Entity<Fbflaggedepisode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbflaggedepisodes_pkey");

            entity.ToTable("fbflaggedepisodes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbflaggedepisodes)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fkokgei59wft1f1jmxd8bthh4i5");

            entity.HasOne(d => d.User).WithMany(p => p.Fbflaggedepisodes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkc9u2mpdi6wk3u5dffth6465fq");
        });

        modelBuilder.Entity<Fbloginban>(entity =>
        {
            entity.HasKey(e => e.Ip).HasName("fbloginbans_pkey");

            entity.ToTable("fbloginbans");

            entity.Property(e => e.Ip)
                .HasMaxLength(255)
                .HasColumnName("ip");
            entity.Property(e => e.Bancount).HasColumnName("bancount");
            entity.Property(e => e.Until).HasColumnName("until");
        });

        modelBuilder.Entity<Fbmodepisode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbmodepisodes_pkey");

            entity.ToTable("fbmodepisodes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbmodepisodes)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk6j9revek9um6a702pevgoqs6s");
        });

        modelBuilder.Entity<Fbnotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbnotifications_pkey");

            entity.ToTable("fbnotifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.SenderId)
                .HasMaxLength(255)
                .HasColumnName("sender_id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Comment).WithMany(p => p.Fbnotifications)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("fkg6rr20rd7ko6xivl84vmdk4ah");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbnotifications)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk7ceksuy8hd0ai32ginrgp09u2");

            entity.HasOne(d => d.Sender).WithMany(p => p.FbnotificationSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("fkr67sxjjp5uvex1x3ta4s2sfb6");

            entity.HasOne(d => d.User).WithMany(p => p.FbnotificationUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkmxxr1jnbawose6dku5ue6oq91");
        });

        modelBuilder.Entity<Fbpasswordreset>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("fbpasswordresets_pkey");

            entity.ToTable("fbpasswordresets");

            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Fbpasswordresets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkg2sdbvhjp1eu110rxipqr3r6u");
        });

        modelBuilder.Entity<Fbpotentialuser>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("fbpotentialusers_pkey");

            entity.ToTable("fbpotentialusers");

            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Fbrecentuserblock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbrecentuserblocks_pkey");

            entity.ToTable("fbrecentuserblocks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BlockeduserId)
                .HasMaxLength(255)
                .HasColumnName("blockeduser_id");
            entity.Property(e => e.BlockinguserId)
                .HasMaxLength(255)
                .HasColumnName("blockinguser_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");

            entity.HasOne(d => d.Blockeduser).WithMany(p => p.FbrecentuserblockBlockedusers)
                .HasForeignKey(d => d.BlockeduserId)
                .HasConstraintName("fkrqbktmevocrexrdtnw4l8y8ht");

            entity.HasOne(d => d.Blockinguser).WithMany(p => p.FbrecentuserblockBlockingusers)
                .HasForeignKey(d => d.BlockinguserId)
                .HasConstraintName("fkp0tbw069wnvhbdwhuwpg9o2qm");
        });

        modelBuilder.Entity<Fbsitesetting>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("fbsitesettings_pkey");

            entity.ToTable("fbsitesettings");

            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Fbtag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbtags_pkey");

            entity.ToTable("fbtags");

            entity.HasIndex(e => e.Shortname, "idxrqjtrdudtdg2yocvvngu48r71");

            entity.HasIndex(e => e.Shortname, "uk_crm05y4qlhyhltl6n83qneeeu").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedbyId)
                .HasMaxLength(255)
                .HasColumnName("createdby_id");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EditedbyId)
                .HasMaxLength(255)
                .HasColumnName("editedby_id");
            entity.Property(e => e.Editeddate).HasColumnName("editeddate");
            entity.Property(e => e.Longname).HasColumnName("longname");
            entity.Property(e => e.Shortname).HasColumnName("shortname");

            entity.HasOne(d => d.Createdby).WithMany(p => p.FbtagCreatedbies)
                .HasForeignKey(d => d.CreatedbyId)
                .HasConstraintName("fk7l099dekvrnwg001ly43o69sq");

            entity.HasOne(d => d.Editedby).WithMany(p => p.FbtagEditedbies)
                .HasForeignKey(d => d.EditedbyId)
                .HasConstraintName("fk7p4031xej38cy0hvagdsyoc5a");
        });

        modelBuilder.Entity<Fbtheme>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("fbthemes_pkey");

            entity.ToTable("fbthemes");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Css).HasColumnName("css");
        });

        modelBuilder.Entity<Fbupvote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbupvotes_pkey");

            entity.ToTable("fbupvotes");

            entity.HasIndex(e => e.EpisodeGeneratedid, "idx6ptpvnyrxr7d12ntoflbcav3f");

            entity.HasIndex(e => e.Date, "idxbbfnbongm0jrh0nqqh6u2gjuo");

            entity.HasIndex(e => e.UserId, "idxf63lcdws5rerv7a8cwjvfif2q");

            entity.HasIndex(e => new { e.EpisodeGeneratedid, e.UserId }, "uk3usmmoftdasoxog2jp7o3mipd").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EpisodeGeneratedid).HasColumnName("episode_generatedid");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.EpisodeGenerated).WithMany(p => p.Fbupvotes)
                .HasForeignKey(d => d.EpisodeGeneratedid)
                .HasConstraintName("fk6t4ojhv1x4tohfk71j2tsfok8");

            entity.HasOne(d => d.User).WithMany(p => p.Fbupvotes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk440roqsvo8qhv08hl9u1y8dgs");
        });

        modelBuilder.Entity<Fbuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fbusers_pkey");

            entity.ToTable("fbusers");

            entity.HasIndex(e => e.Email, "uk_6uw40lt55at3tt4qc1ypxaqj5").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Authorsubmail).HasColumnName("authorsubmail");
            entity.Property(e => e.Authorsubsite).HasColumnName("authorsubsite");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Bodytextwidth)
                .HasDefaultValue(900)
                .HasColumnName("bodytextwidth");
            entity.Property(e => e.Childmail)
                .HasDefaultValue(false)
                .HasColumnName("childmail");
            entity.Property(e => e.Childsite)
                .HasDefaultValue(true)
                .HasColumnName("childsite");
            entity.Property(e => e.Commentmail)
                .HasDefaultValue(false)
                .HasColumnName("commentmail");
            entity.Property(e => e.Commentsite)
                .HasDefaultValue(true)
                .HasColumnName("commentsite");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Hideimages)
                .HasDefaultValue(false)
                .HasColumnName("hideimages");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Theme)
                .HasMaxLength(255)
                .HasColumnName("theme");
            entity.Property(e => e.ThemeName)
                .HasMaxLength(255)
                .HasColumnName("theme_name");

            entity.HasOne(d => d.ThemeNameNavigation).WithMany(p => p.Fbusers)
                .HasForeignKey(d => d.ThemeName)
                .HasConstraintName("fkrbykt6si6h8et3vny0uyfhvi2");
            
            // Tell EF to ignore UserName as a column since it's computed from Id
            entity.Ignore(e => e.UserName);
            
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.SecurityStamp).HasDefaultValueSql("gen_random_uuid()::text");
            entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("gen_random_uuid()::text");
            entity.Property(e => e.NormalizedUserName).HasComputedColumnSql("UPPER([id])");
            entity.Property(e => e.NormalizedEmail).HasComputedColumnSql("UPPER([email])");
            
            
            
        });
        modelBuilder.HasSequence("hibernate_sequence");
    }
}
