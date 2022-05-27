namespace Server_v0._0.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;

    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                        .HasOne(p => p.Worker)
                        .WithMany(p => p.Transactions);
            modelBuilder.Entity<Transaction>()
                        .HasOne(p => p.Work)
                        .WithMany(p => p.Transactions);
            modelBuilder.Entity<Transaction>()
                        .HasOne(p => p.WorkType)
                        .WithMany(p => p.Transactions);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            List<StreamReader> procedures = new List<StreamReader>();
            List<StreamReader> triggers = new List<StreamReader>();
            procedures.Add(new StreamReader(@"Procedures/Procedure_all_delete.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_EmailGen.txt"));

            foreach (StreamReader reader in procedures)
            {
                try
                {
                    Database.ExecuteSqlCommand(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом запуске
                }
            }
            foreach (StreamReader reader in triggers)
            {
                try
                {
                    Database.ExecuteSqlCommand(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом запуске
                }
            }
        }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Work> Work { get; set; }
        public DbSet<WorkType> WorkType { get; set; }
    }
}