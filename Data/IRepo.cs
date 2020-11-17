using System.Collections.Generic;
using FirstProject.Models;

namespace FirstProject.Data{

public interface IRepo{

bool SaveChanges();
IEnumerable<Project> GetAllCommands();
Project GetProjectById(int Id);
void CreateCommand(Project P);

void UpdateCommand(Project P);
void DeleteCommand(Project P);

}

}