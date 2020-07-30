using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using CommandAPI.Data;
using CommandAPI.Profiles;
using AutoMapper;
using CommandAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace CommandAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _context;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _context = repository;
            _mapper = mapper;
        }

        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = _context.GetAppAllCommands();

            return Ok(commands);
        }

        //GET api/commands/{id} || api/commands/5
        [HttpGet("{id}",Name = "GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var command = _context.GetCommandById(id);

            if(command != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(command));
            }

            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreateDTO pCommand)
        {
            var commandModel = _mapper.Map<Command>(pCommand);
            _context.CreateCommand(commandModel);

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);  
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO pCommand)
        {
            var commandModel = _context.GetCommandById(id);
            if (commandModel == null)
            {
                return NotFound();
            }

            _mapper.Map(pCommand, commandModel);

            _context.UpdateCommand(commandModel);

            _context.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> pathDoc)
        {
            var commandModelFromRepo = _context.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);

            pathDoc.ApplyTo(commandToPatch,ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _context.UpdateCommand(commandModelFromRepo);
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int id)
        {
            var commandToDelete = _context.GetCommandById(id);
            if(commandToDelete == null)
            {
                return NotFound();
            }

            _context.DeleteCommandById(commandToDelete);

            return Ok($"Deleted command with Id {commandToDelete.Id}");
        }
    }
}
