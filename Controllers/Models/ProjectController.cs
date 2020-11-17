using System.Collections.Generic;
using AutoMapper;
using FirstProject.Data;
using FirstProject.Dtos;
using FirstProject.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{

[Route("api/commands")]
[ApiController]
public class ProjectController : ControllerBase
{
  private readonly IRepo _repository;
  private readonly IMapper _Mappper;

  public ProjectController(IRepo repository, IMapper Mapper)
   {
       _repository=repository;
       _Mappper=Mapper;
       
   }

  //private readonly MockRepo _repository = new MockRepo();
       
    [HttpGet]
    public ActionResult <IEnumerable<ReadDto>> GetAllCommands()
    {
     var commands=_repository.GetAllCommands();
     return Ok(_Mappper.Map<IEnumerable<ReadDto>>(commands));
    }

    [HttpGet("{id}",Name="GetCommandById")]
    public ActionResult <ReadDto> GetCommandById(int Id)
    {
      var commands=_repository.GetProjectById(Id);
      if(commands!=null ){
       return Ok(_Mappper.Map<ReadDto>(commands));
      }
      return NotFound();
    }

    [HttpPost]
    public ActionResult <ReadDto> CreateCommand(CreateDto com)
    {
     var commands=_Mappper.Map<Project>(com);
     _repository.CreateCommand(commands);
     _repository.SaveChanges();
     var createdto=_Mappper.Map<ReadDto>(commands);
     return Ok(createdto);
    }
   
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, UpdateDto Updatedto)
    {
      var commandfromRepo=_repository.GetProjectById(id);
      if(commandfromRepo==null)
      {
        return NotFound();
      }
      _Mappper.Map(Updatedto,commandfromRepo);
      _repository.UpdateCommand(commandfromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialUpdate(int id, JsonPatchDocument<UpdateDto> patchDocument )
    {
     var commandfromRepo=_repository.GetProjectById(id);
      if(commandfromRepo==null)
      {
        return NotFound();
      }
      var commandtopatch=_Mappper.Map<UpdateDto>(commandfromRepo);
      patchDocument.ApplyTo(commandtopatch,ModelState);

      if(!TryValidateModel(commandtopatch))
      {
        return ValidationProblem(ModelState);
      }
      _Mappper.Map(commandtopatch,commandfromRepo);
      _repository.UpdateCommand(commandfromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    [HttpDelete("id")]
    public ActionResult Delete(int id)
    {
      var commandfromRepo=_repository.GetProjectById(id);
      if(commandfromRepo==null)
      {
        return NotFound();
      }
      _repository.DeleteCommand(commandfromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

}

}