﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConnector.DAO.Entity;
using DatabaseConnector.DAO.FormData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnector.DAO
{
    public class LabContext : DbContext
    {
        public LabContext(DbContextOptions<LabContext> options)
            : base(options)
        { }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<NotificationMessage> NotificationMessages { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<DeclarationForm> DeclarationForms { get; set; }
        public DbSet<ClaimForm> ClaimForms { get; set; }
        public DbSet<ClaimFormChemical> ClaimFormChemicalMap { get; set; }
        public DbSet<FinancialForm> FinancialForms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoleRelation { get; set; }
        public DbSet<StatusChangeMessage> WorkFlowStatusChangeMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chemical>(options =>
            {
                options.HasIndex(c => c.LabId);
                options.HasIndex(c => c.WorkFlowId);
            });
            modelBuilder.Entity<Budget>()
                .HasIndex(b => b.LabId);
            modelBuilder.Entity<NotificationMessage>(options=>
            {
                options.HasIndex(u => u.RoleId);
                options.HasIndex(u => u.FormType);
            });
            modelBuilder.Entity<StatusChangeMessage>(options =>
            {
                options.HasIndex(u => u.UserId);
                options.HasIndex(u => u.RelatedType);
            });
            modelBuilder.Entity<ClaimForm>(options=>
            {
                options.HasIndex(c => c.LabId);
            });
            modelBuilder.Entity<DeclarationForm>(options =>
            {
                options.HasIndex(c => c.LabId);
                options.HasIndex(c => c.WorkFlowId);
            });
            modelBuilder.Entity<FinancialForm>(options =>
            {
                options.HasIndex(c => c.LabId);
                options.HasIndex(c => c.WorkFlowId);
            });
            modelBuilder.Entity<WorkFlow>()
                .HasMany(w => w.Chemicals)
                .WithOne();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }
    }
}
