using edusys.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Universidade> Universidade { get; set; }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplina { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                 .HasOne(a => a.Endereco)
                 .WithMany()
                 .HasForeignKey(a => a.EnderecoId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Universidade>()
                 .HasOne(a => a.Endereco)
                 .WithMany()
                 .HasForeignKey(a => a.EnderecoId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Estado)
                .WithMany()
                .HasForeignKey(e => e.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany()
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany()
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany()
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Matricula)
                .WithMany()
                .HasForeignKey(n => n.MatriculaId)
                .OnDelete(DeleteBehavior.Cascade);
           

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Disciplina)
                .WithMany()
                .HasForeignKey(n => n.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Estado>()
                .HasIndex(e => e.UF)
                .IsUnique();

            modelBuilder.Entity<CursoDisciplina>()
               .HasOne(p => p.Curso)
               .WithMany()
               .HasForeignKey(p => p.CursoId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CursoDisciplina>()
               .HasOne(p => p.Disciplina)
               .WithMany()
               .HasForeignKey(p => p.DisciplinaId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
