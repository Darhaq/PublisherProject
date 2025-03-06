using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherProjectData.Data;
using PublisherProjectData.Interfaces;

namespace PublisherProjectData.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private readonly PublisherContext _context;

        public CoverRepository(PublisherContext context)
        {
            this._context = context;
        }


    }
}
