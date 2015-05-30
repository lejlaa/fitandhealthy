using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FitAndHealthy.Mappers;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DietMap()); 
            modelBuilder.Configurations.Add(new ExerciseMap()); 
            modelBuilder.Configurations.Add(new ActionMap()); 
            modelBuilder.Configurations.Add(new ProgramMap()); 
            modelBuilder.Configurations.Add(new RoleMap()); 
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TrainingMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            modelBuilder.Entity<Program>().HasMany(u => u.Comments).WithMany();


 

            modelBuilder.Entity<Program>().HasMany<Training>(x => x.Trainings).WithMany(p => p.Programs).Map(m => m.ToTable("ProgramTraining").MapLeftKey("ProgramId").MapRightKey("TrainingId")); 
            
            
            //modelBuilder.Entity<Day>().HasRequired(x => x.Person).WithMany(p => p.Days).Map(m => m.MapKey("Person")); 
            //modelBuilder.Entity<Detail>().HasRequired(x => x.Day).WithMany(p => p.Details).Map(m => m.MapKey("Day")); 
            //modelBuilder.Entity<Detail>().HasRequired(x => x.Project).WithMany(p => p.Details).Map(m => m.MapKey("Project"));
            
            base.OnModelCreating(modelBuilder);
        } 
    }
}
