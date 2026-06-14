using FictionBranches.Web.Data;
using FictionBranches.Web.Data.Models;
using FictionBranches.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FictionBranches.Web.Controllers;

public class CommentController(IDbContextFactory<ApplicationDbContext> dbContextFactory) : Controller
{
    [HttpGet("/fb/deletecomment")]
    public async Task<IActionResult> Index(long commentId, string redirectTo)
    {
        if (string.IsNullOrWhiteSpace(redirectTo))
            return Redirect("/fb");
        if (commentId <= 0)
            return Redirect(redirectTo);
        await using var db = await dbContextFactory.CreateDbContextAsync();
        var comment = await db.Fbcomments.FindAsync(commentId);
        if (comment == null || comment.UserId != User.Username() && !User.IsMod())
            return Redirect(redirectTo);

        await using (var transaction = await db.Database.BeginTransactionAsync())
        {
            try
            {
                await db.Fbflaggedcomments.Where(e => e.CommentId == comment.Id).ExecuteDeleteAsync();
                await db.Fbnotifications.Where(e => e.CommentId == comment.Id).ExecuteDeleteAsync();
                await db.Fbcomments.Where(e => e.Id == comment.Id).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return Redirect(redirectTo);
    }
}