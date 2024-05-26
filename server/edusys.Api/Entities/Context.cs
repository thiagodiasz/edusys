using edusys.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Professor> Professor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
        }
    }
}
