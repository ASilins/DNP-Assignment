using App.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(PostSearchParameterDto dto)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();

        if (!string.IsNullOrEmpty(dto.OwnerName))
        {
            // we know OwnerName is unique, so just fetch the first
            query = query.Where(todo =>
                todo.Owner.UserName.ToLower().Equals(dto.OwnerName.ToLower()));
        }

        if (!string.IsNullOrEmpty(dto.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(dto.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
}