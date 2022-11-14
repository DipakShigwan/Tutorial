using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Data;
using Tutorial.DataAccessLayer.Infrastructure.IRepository;

namespace Tutorial.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
       
        public ICategoryRepository Category {get;private set;}
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
