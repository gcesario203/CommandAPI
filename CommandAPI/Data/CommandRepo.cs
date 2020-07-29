using CommandAPI.Models;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Command> GetAppAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }
    }
}
