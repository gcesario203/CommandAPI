using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAPI.Data
{
    public class CommandAPIContext : DbContext
    {
        public CommandAPIContext(DbContextOptions<CommandAPIContext> options):base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
    }
}
