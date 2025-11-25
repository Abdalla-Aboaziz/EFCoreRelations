using EFCoreRelations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelations.DataBaseContext
{
    internal class AirLineDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AirLineData01;Integrated Security=True;TrustServerCertificate=True");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relation Between Aircraft And Crew 1:1 (Total)
		
            modelBuilder.Entity<AirCraft>().HasOne(A => A.ACrew).WithOne(C => C.CAirCraft).HasForeignKey<Crew>(C => C.CrewId);//One to One Relation between AirCraft and Crew 
                                                                                                                              // Ican Delete Navigation Properties from Crew And put [Owned] on table Crew and use Ownsone in fluent


            #endregion

            #region Relation Between AirCraft And AirLine  M:1 (M Total)

            modelBuilder.Entity<AirCraft>().HasOne(A => A.AirLine).WithMany(L => L.airCrafts).HasForeignKey(A => A.AirLineId);

            #endregion

            #region Relation Between AirCraft And Transaction  1:M (M Total)

            modelBuilder.Entity<Transaction>().HasOne(T => T.TAirLine).WithMany(A => A.transactions).HasForeignKey(T => T.AirLineId);

            #endregion


            #region Relation Between Employee And AirLine  M:1 (M Total)
            modelBuilder.Entity<Employee>().HasOne(E => E.EAirline).WithMany(A => A.employees).HasForeignKey(E => E.AirLineId);

            #endregion


            modelBuilder.Entity<RouteAircraft>()
    .HasKey(ra => new { ra.AirCraftId, ra.RouteId });

            modelBuilder.Entity<RouteAircraft>()
                .HasOne(ra => ra.NAirCraft)
                .WithMany(ac => ac.ArouteAircraft)
                .HasForeignKey(ra => ra.AirCraftId);

            modelBuilder.Entity<RouteAircraft>()
                .HasOne(ra => ra.NRoute)
                .WithMany(r => r.RrouteAircraft)
                .HasForeignKey(ra => ra.RouteId);





        }





        public  DbSet<AirCraft>AirCrafts { get; set; }
        public DbSet<Crew> Crews { get; set; }  
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AirLine>AirLines { get; set; }

        public DbSet<Employee> Employees { get; set; }


        }
}
