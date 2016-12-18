using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        {
            Database.SetInitializer<DataContext>(new DbInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Login).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();

            modelBuilder.Entity<MeetingRoom>().Property(p => p.RoomNumber).HasMaxLength(10).IsRequired();
    
            base.OnModelCreating(modelBuilder);
        }
    }
}
