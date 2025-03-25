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
    public class ArtistRepository : IArtistRepository
    {
        private readonly PublisherContext _context;

        public ArtistRepository(PublisherContext context)
        {
            this._context = context;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<Artist> CreateAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist?> UpdateAsync(int id, Artist artist)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            if (existingArtist == null)
            {
                return null;
            }

            existingArtist.FirstName = artist.FirstName;
            existingArtist.LastName = artist.LastName;

            await _context.SaveChangesAsync();
            return existingArtist;
        }

        public async Task<Artist?> DeleteAsync(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return null;
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
