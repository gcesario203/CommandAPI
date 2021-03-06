﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command pCommand);
        void DeleteCommandById(Command pCommand);
        void UpdateCommand(Command pCommand);
        bool SaveChanges();
    }
}
