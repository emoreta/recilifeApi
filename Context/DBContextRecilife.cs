using Microsoft.EntityFrameworkCore;
using recilife_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace recilife_api.Context
{
    public class DBContextRecilife : DbContext
    {
        public DBContextRecilife(DbContextOptions<DBContextRecilife> options) : base(options)
        {
        }
        public DbSet<Calification> Calification { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<Locationuser> Locationuser { get; set; }
        public DbSet<Recyclablematerial> Recyclablematerial { get; set; }
        public DbSet<Request> Request { get; set; }

        public DbSet<Requestrecyclablematerial> Requestrecyclablematerial { get; set; }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Templateemail> Templateemail { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Userlocation> Userlocation { get; set; }
        public DbSet<Userschedule> Userschedule { get; set; }
        public DbSet<Usertype> Usertype { get; set; }
    }
}
