using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private Lazy<IProjectRepository> _projectRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            _projectRepository =
                new Lazy<IProjectRepository>(() => new ProjectRepository(_context));

            _employeeRepository =
                new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
        }

        public IProjectRepository Project => _projectRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
