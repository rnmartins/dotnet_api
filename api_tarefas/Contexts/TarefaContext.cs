using api_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace api_tarefas.Contexts
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
        }

        public DbSet<TarefaItem> Tarefas { get; set; } = null;
    }
}
