﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using CommandAPI.Data;

namespace CommandAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly MockCommanderRepo _mockContext = new MockCommanderRepo();

        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = _mockContext.GetAppCommands();

            return Ok(commands);
        }

        //GET api/commands/{id} || api/commands/5
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var command = _mockContext.GetCommandById(id);

            return Ok(command);
        }
    }
}
