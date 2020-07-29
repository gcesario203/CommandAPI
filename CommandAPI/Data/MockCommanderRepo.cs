using CommandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 1, HowTo = "UIUi", Line = "Ola mundo", Plataform = "Gostosa" },
                new Command { Id = 2, HowTo = "Mock dos cria", Line = "VOu ficar bom nisso", Plataform = "Podepa" },
                new Command { Id = 3, HowTo = "Tragedy", Line = "BeeGees mto foda", Plataform = "Gostosakkkk" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "UIUi", Line = "Ola mundo", Plataform = "Gostosa" };
        }
    }
}
