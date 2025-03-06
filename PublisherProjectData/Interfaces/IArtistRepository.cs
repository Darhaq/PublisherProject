using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherProjectData.Models;

namespace PublisherProjectData.Interfaces
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync();
        Task<Artist?> GetByIdAsync(int id);
        Task<Artist> CreateAsync(Artist cover);
        Task<Artist?> UpdateAsync(int id, Artist cover);
        Task<Artist?> DeleteAsync(int id);
    }
}
