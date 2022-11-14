using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Data;
using Tutorial.DataAccessLayer.Infrastructure.IRepository;
using Tutorial.Models;

namespace Tutorial.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context; 
        }

        public void update(Category category)
        {
            _context.Update(category);
        }
    }
}
