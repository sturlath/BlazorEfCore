using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public interface ISettingsService
    {
        Task<List<MySettings>> Get();
        Task<MySettings> Get(int id);
        Task<MySettings> Add(MySettings toDo);
        Task<MySettings> Update(MySettings toDo);
        Task<MySettings> Delete(int id);
    }

    public class SettingsService : ISettingsService
    {
        private readonly ApplicationDbContext _context;

        public SettingsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MySettings>> Get()
        {
            return await _context.Settings.
                AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<MySettings> Get(int id)
        {
            var toDo = await _context.Settings.FindAsync(id);
            return toDo;
        }

        public async Task<MySettings> Add(MySettings toDo)
        {
            try
            {
                //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                _context.Settings.Add(toDo);
                await _context.SaveChangesAsync();
                return toDo;
            }
            catch (Exception ex)
            {
                // The error:
                // "The instance of entity type 'PostalSystem' cannot be tracked because another instance with the key value '{PostalSystemId: 1}' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached."
                throw;
            }
        }

        public async Task<MySettings> Update(MySettings toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<MySettings> Delete(int id)
        {
            var toDo = await _context.Settings.FindAsync(id);
            _context.Settings.Remove(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }
    }
}
