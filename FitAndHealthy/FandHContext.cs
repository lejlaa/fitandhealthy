using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FitAndHealthy.Mappers;

namespace FitAndHealthy
{
    public class FandHContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Diet> Diets { get; set; }
        //public DbSet<Action> Actions { get; set; }
        public DbSet<Program> Programs { get; set; }         
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public FandHContext() : base()
        {

            Database.SetInitializer<FandHContext>(new CreateDatabaseIfNotExists<FandHContext>());
            //Database.SetInitializer<FandHContext>(new DropCreateDatabaseIfModelChanges<FandHContext>());
            //Database.SetInitializer<FandHContext>(new DropCreateDatabaseAlways<FandHContext>());
            //Database.SetInitializer<FandHContext>(new FandHDbInitializer());
            //Database.SetInitializer<FandHContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExerciseMap()); 
            modelBuilder.Configurations.Add(new DietMap()); 
            modelBuilder.Configurations.Add(new ProgramMap()); 
            modelBuilder.Configurations.Add(new RoleMap()); 
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TrainingMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CategoryMap());


            //modelBuilder.Entity<Program>().HasRequired(x => x.Diet).WithMany(p => p.Programs).Map(m => m.MapKey("Diet")).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Program>().HasRequired(x => x.Author).WithMany(p => p.Programs).Map(m => m.MapKey("Author")).WillCascadeOnDelete(false);


           // modelBuilder.Entity<Program>().HasMany<Training>(x => x.Trainings).WithMany(p => p.Programs).Map(m => m.ToTable("ProgramTraining").MapLeftKey("ProgramId").MapRightKey("TrainingId"));
           // modelBuilder.Entity<Program>().HasMany<Category>(x => x.Categories).WithMany(p => p.Programs).Map(m => m.ToTable("ProgramCategory").MapLeftKey("ProgramId").MapRightKey("CategotyId"));
           //// modelBuilder.Entity<Program>().HasMany<User>(x => x.Users).WithMany(p => p.Programs).Map(m => m.ToTable("UserCategory").MapLeftKey("ProgramId").MapRightKey("UserId"));
            //modelBuilder.Entity<Program>().HasMany<User>(x => x.Users).WithMany(p => p.UserPrograms).Map(m => m.ToTable("UserCategory").MapLeftKey("ProgramId").MapRightKey("UserId"));


            //modelBuilder.Entity<Training>().HasMany<Category>(x => x.Categories).WithMany(p => p.Trainings).Map(m => m.ToTable("TraingCategory").MapLeftKey("TrainingId").MapRightKey("CategotyId"));
            //modelBuilder.Entity<Training>().HasMany<Exercise>(x => x.Exercises).WithMany(p => p.Trainings).Map(m => m.ToTable("TraingExercise").MapLeftKey("TrainingId").MapRightKey("ExerciseId"));

            //modelBuilder.Entity<Exercise>().HasMany<Category>(x => x.Categories).WithMany(p => p.Exercises).Map(m => m.ToTable("ExerciseCategory").MapLeftKey("ExerciseId").MapRightKey("CategotyId"));

            //modelBuilder.Entity<Comment>().HasRequired(x => x.Exercise).WithMany(p => p.Comments).Map(m => m.MapKey("Exercise"));
            //modelBuilder.Entity<Comment>().HasRequired(x => x.Training).WithMany(p => p.Comments).Map(m => m.MapKey("Training"));
            //modelBuilder.Entity<Comment>().HasRequired(x => x.Diet).WithMany(p => p.Comments).Map(m => m.MapKey("Diet"));
            //modelBuilder.Entity<Comment>().HasRequired(x => x.Program).WithMany(p => p.Comments).Map(m => m.MapKey("Program"));
            //modelBuilder.Entity<Comment>().HasRequired(x => x.User).WithMany(p => p.Comments).Map(m => m.MapKey("User"));


            //modelBuilder.Entity<User>().HasMany<Role>(x => x.Roles).WithMany(p => p.Users ).Map(m => m.ToTable("UserRole").MapLeftKey("UserId").MapRightKey("RoleId"));
            //modelBuilder.Entity<Role>().HasMany<Action>(x => x.Actions).WithMany(p => p.Roles).Map(m => m.ToTable("RoleAtion").MapLeftKey("RoleId").MapRightKey("ActionId"));

            //modelBuilder.Entity<Day>().HasRequired(x => x.Person).WithMany(p => p.Days).Map(m => m.MapKey("Person")); 
            //modelBuilder.Entity<Detail>().HasRequired(x => x.Day).WithMany(p => p.Details).Map(m => m.MapKey("Day")); 
            //modelBuilder.Entity<Detail>().HasRequired(x => x.Project).WithMany(p => p.Details).Map(m => m.MapKey("Project"));
            
            base.OnModelCreating(modelBuilder);
        } 
    }
}
