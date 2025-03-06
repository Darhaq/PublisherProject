using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherProjectData.DTOs.Cover;
using PublisherProjectData.Models;

namespace PublisherProjectData.Interfaces
{
    public interface ICoverRepository
    {
        Task<List<Cover>> GetAllAsync();
        Task<Cover?> GetByIdAsync(int id);
        Task<Cover> CreateAsync(Cover cover);
        Task<Cover?> UpdateAsync(int id, Cover cover);
        Task<Cover?> DeleteAsync(int id);
    }
}
