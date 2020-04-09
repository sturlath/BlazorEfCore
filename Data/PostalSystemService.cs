using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public interface IPostalSystemService
    {
        Task<List<PostalSystem>> Get();
        Task<PostalSystem> Get(int id);
        Task<PostalSystem> Add(PostalSystem toDo);
        Task<PostalSystem> Update(PostalSystem toDo);
        Task<PostalSystem> Delete(int id);
    }

    public class PostalSystemService : IPostalSystemService
    {
        private readonly ApplicationDbContext _context;

        public PostalSystemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PostalSystem>> Get()
        {
            return await _context.PostalSystem.
                AsNoTracking()
                .ToListAsync();
        }

        public async Task<PostalSystem> Get(int id)
        {
            var toDo = await _context.PostalSystem.FindAsync(id);
            return toDo;
        }

        public async Task<PostalSystem> Add(PostalSystem toDo)
        {
            try
            {
                _context.PostalSystem.Add(toDo);
                await _context.SaveChangesAsync();
                return toDo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PostalSystem> Update(PostalSystem toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<PostalSystem> Delete(int id)
        {
            var toDo = await _context.PostalSystem.FindAsync(id);
            _context.PostalSystem.Remove(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }
    }
}
