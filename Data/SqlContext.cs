using System;
using System.Collections.Generic;
using System.Linq;
using FirstProject.Models;

namespace FirstProject.Data
{

    public class SqlContext : IRepo
    {
        private readonly DatabaseContext _context;

        public SqlContext(DatabaseContext context)
       {
           _context =context;
       }

        public void CreateCommand(Project p)
        {
            if(p==null){
                throw new ArgumentNullException(nameof(p));
            }
           _context.Commands.Add(p);
        }

        public void DeleteCommand(Project p)
        {
           if(p==null){
                throw new ArgumentNullException(nameof(p));
            }
             _context.Commands.Remove(p);
        }

        public IEnumerable<Project> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Project GetProjectById(int Id)
        {
           return _context.Commands.FirstOrDefault(z=>z.Id==Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCommand(Project P)
        {
            //throw new NotImplementedException();
        }
    }

}