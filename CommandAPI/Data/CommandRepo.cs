using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Data
{
    public class CommandRepo : ICommanderRepo
    {

        private readonly CommandAPIContext _context;

        public CommandRepo(CommandAPIContext DbContext)
        {
            _context = DbContext;
        }

        public void CreateCommand(Command pCommand)
        {
            if(pCommand == null)
            {
                throw new ArgumentException(nameof(pCommand));
            }
            _context.Commands.Add(pCommand);
            SaveChanges();
        }

        public void DeleteCommandById(Command pCommand)
        {
            if (_context.Commands.Any(x => x.Id == pCommand.Id))
            {
                _context.Commands.Remove(pCommand);
                SaveChanges();
            }
            else
            {
                throw new ApplicationException("Command not found");
            }
        }

        public IEnumerable<Command> GetAppAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCommand(Command pCommand)
        {
            //Nada!
        }
    }
}
