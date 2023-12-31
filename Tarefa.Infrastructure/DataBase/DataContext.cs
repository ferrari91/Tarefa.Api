﻿using Microsoft.EntityFrameworkCore;
using Tarefa.Application.Interface.DataBase;
using Tarefa.Domain.Entities;

namespace Tarefa.Infrastructure.DataBase
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<TaskEntity> DbTask { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataConfiguration<TaskEntity>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<TaskEntity>().ToTable("Tarefa");
        }

        public async Task<bool> CreateDataBaseAsync() => await Database.EnsureCreatedAsync();
    }
}
