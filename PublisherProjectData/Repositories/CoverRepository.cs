using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublisherProjectData.Data;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Models;

namespace PublisherProjectData.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private readonly PublisherContext _context;

        public CoverRepository(PublisherContext context)
        {
            this._context = context;
        }

        public async Task<List<Cover>> GetAllAsync()
        {
            return await _context.Covers.ToListAsync();
        }

        public async Task<Cover?> GetByIdAsync(int id)
        {
            return await _context.Covers.FindAsync(id);
        }

        public async Task<Cover> CreateAsync(Cover cover)
        {
            await _context.Covers.AddAsync(cover);
            await _context.SaveChangesAsync();
            return cover;
        }

        public async Task<Cover?> UpdateAsync(int id, Cover cover)
        {
            var existingCover = await _context.Covers.FindAsync(id);
            if (existingCover == null)
            {
                return null;
            }

            existingCover.DesignIdeas = cover.DesignIdeas;
            existingCover.DigitalOnly = cover.DigitalOnly;

            await _context.SaveChangesAsync();
            return existingCover;
        }

        public async Task<Cover?> DeleteAsync(int id)
        {
            var cover = await _context.Covers.FindAsync(id);
            if (cover == null)
            {
                return null;
            }

            _context.Covers.Remove(cover);
            await _context.SaveChangesAsync();
            return cover;

        }
    }
}
