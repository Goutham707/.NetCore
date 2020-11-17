using System.Collections.Generic;
using FirstProject.Models;

namespace FirstProject.Data
{

public class MockRepo: IRepo
{
        public void CreateCommand(Project P)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Project P)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Project> GetAllCommands(){
   var info= new List<Project>{
        new Project{Id=0,HowTo="Piece of bread",Line="cut sides",Platform="Oven"},
        new Project{Id=1,HowTo="Cup of tea",Line="bring cups",Platform="boil"},
        new Project{Id=2,HowTo="Boil egg",Line="Steamer",Platform="egg omelette"}
   };
   return info;
}

public Project GetProjectById(int Id){

    return new Project{Id=0,HowTo="Piece of bread",Line="cut sides",Platform="Oven"};
}

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Project P)
        {
            //throw new System.NotImplementedException();
        }
    }

}
