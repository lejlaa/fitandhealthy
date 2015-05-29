using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FitAndHealthy
{
    class FandHContext : DbContext
    {
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Program> Programs { get; set; }         
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public FandHContext() : base () {

            Database.SetInitializer<FandHContext>(new CreateDatabaseIfNotExists<FandHContext>());
            //Database.SetInitializer<FandHContext>(new DropCreateDatabaseIfModelChanges<FandHContext>());
            //Database.SetInitializer<FandHContext>(new DropCreateDatabaseAlways<FandHContext>());
            //Database.SetInitializer<FandHContext>(new FandHDbInitializer());
            //Database.SetInitializer<FandHContext>(null);
        }
    }
}
