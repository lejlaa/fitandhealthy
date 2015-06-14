using FitAndHealthy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FandHSeed
{
    class Program
    {                              
        static string sourceData = @"C:\Users\Layla\Documents\GitHub\fitandhealthy\FitandHealthyData.xlsx";
        static void Main(string[] args)
        {
            getData();

            //getUsers();
            //getRoles();
            //getActions();
            //getDiets();
            //getCategories();
            //getExercises();
            //getTrainings();
            //getComments();
            //getPrograms();

            Console.ReadLine();

        }


        static void getData()
        {
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                Role r1 = new Role();
                r1.Name = "Admin";
                ctx.Roles.Add(r1);
                

                Role r2 = new Role();
                r2.Name = "User";
                ctx.Roles.Add(r2);


                User user1 = new User();
                user1.Username = "lejla";
                user1.Password = "lejla";
                user1.Roles.Add(r1);
                user1.Roles.Add(r2);
                user1.Banned = "false";
                user1.ConfirmationToken = "";
                user1.ConfirmedUser = "";
                user1.Comments = new List<Comment>();
                user1.Email = "lela@hghgh.com";
                ctx.Users.Add(user1);

                User user3 = new User();
                user3.Username = "berina";
                user3.Password = "berina";
                user3.Roles.Add(r2);
                user3.Banned = "false";
                user3.ConfirmationToken = "";
                user3.ConfirmedUser = "";
                user3.Comments = new List<Comment>();
                user3
                    
                    
                    .Email = "berka@hghgh.com";
                ctx.Users.Add(user3);

                Diet someDiet = new Diet();
                someDiet.Name = "SomeDiet";
                someDiet.Description = "fakifakfhadhfsdjfh";
                someDiet.Comments = new List<Comment>();
                someDiet.Programs = new List<FitAndHealthy.Program>();
                someDiet.RatedByNo = 4;
                someDiet.Rating = 20;
                ctx.Diets.Add(someDiet);

                FitAndHealthy.Program pr1 = new FitAndHealthy.Program();
                pr1.Name = "Program 1";
                pr1.Description = "blabla";
                pr1.Author = user1;
                pr1.Diet = someDiet;
                pr1.Categories = new List<Category>();
                pr1.Comments = new List<Comment>();
                pr1.Duration = 60;
                pr1.RatedByNo = 4;
                pr1.Rating = 20;
                pr1.Trainings = new List<Training>();
                pr1.Users = new List<User>();
                pr1.VideoLink = "http//:";
                ctx.Programs.Add(pr1);

                FitAndHealthy.Program pr2 = new FitAndHealthy.Program();
                pr2.Name = "Program 2";
                pr2.Description = "blablabla";
                pr2.Author = user3;
                pr2.Diet = someDiet;
                pr2.Categories = new List<Category>();
                pr2.Comments = new List<Comment>();
                pr2.Duration = 60;
                pr2.RatedByNo = 4;
                pr2.Rating = 20;
                pr2.Trainings = new List<Training>();
                pr2.Users = new List<User>();
                pr2.VideoLink = "http//:";
                ctx.Programs.Add(pr2);

                ctx.SaveChanges();
            }
        }


        /*
        static void getRoles()
        {
            DataTable rawData = OpenExcel(sourceData, "Roles");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Role role = new Role();
                    role.Name = row.ItemArray.GetValue(1).ToString();
                    ctx.Roles.Add(role);
                }
                ctx.SaveChanges();
            }
        }

        static void getPrograms()
        {
            DataTable rawData = OpenExcel(sourceData, "Programs");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;

                ctx.Configuration.ValidateOnSaveEnabled = false;   

                
                foreach (DataRow row in rawData.Rows)
                {
                    FitAndHealthy.Program program = new FitAndHealthy.Program();
                    program.Name = row.ItemArray.GetValue(1).ToString();
                    program.Description = row.ItemArray.GetValue(2).ToString();
                    ctx.Programs.Add(program);
                }
                ctx.SaveChanges();
            }
        }

        static void getUsers()
        {
            DataTable rawData = OpenExcel(sourceData, "Users");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    User user = new User();
                    user.Username = row.ItemArray.GetValue(1).ToString();
                    user.Password = row.ItemArray.GetValue(2).ToString();
                    user.Banned = row.ItemArray.GetValue(3).ToString();
                    ctx.Users.Add(user);
                }
                ctx.SaveChanges();
            }
        }

        static void getActions()
        {
            DataTable rawData = OpenExcel(sourceData, "Actions");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    FitAndHealthy.Action action = new FitAndHealthy.Action();
                    action.Name = row.ItemArray.GetValue(1).ToString();
                    action.Description = row.ItemArray.GetValue(2).ToString();
                    ctx.Actions.Add(action);
                }
                ctx.SaveChanges();
            }
        }

        static void getDiets()
        {
            DataTable rawData = OpenExcel(sourceData, "Diets");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Diet diet = new Diet();
                    diet.Name = row.ItemArray.GetValue(1).ToString();
                    diet.Description = row.ItemArray.GetValue(2).ToString();
                    ctx.Diets.Add(diet);
                }
                ctx.SaveChanges();
            }
        }

        static void getCategories()
        {
            DataTable rawData = OpenExcel(sourceData, "Categories");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Category category = new Category();
                    category.Name = row.ItemArray.GetValue(1).ToString();
                    ctx.Categories.Add(category);
                }
                ctx.SaveChanges();
            }
        }

        static void getExercises()
        {
            DataTable rawData = OpenExcel(sourceData, "Exercises");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Exercise exercise = new Exercise();
                    exercise.Name = row.ItemArray.GetValue(1).ToString();
                    ctx.Exercises.Add(exercise);
                }
                ctx.SaveChanges();
            }
        }

        static void getTrainings()
        {
            DataTable rawData = OpenExcel(sourceData, "Trainings");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Training training = new Training();
                    training.Name = row.ItemArray.GetValue(1).ToString();
                    training.Description = row.ItemArray.GetValue(2).ToString();
                    ctx.Trainings.Add(training);
                }
                ctx.SaveChanges();
            }
        }

        static void getComments()
        {
            DataTable rawData = OpenExcel(sourceData, "Comments");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (DataRow row in rawData.Rows)
                {
                    Comment comment = new Comment();
                    comment.CommentText = row.ItemArray.GetValue(1).ToString();
                    ctx.Comments.Add(comment);
                }
                ctx.SaveChanges();
            }
        }

        static DataTable OpenExcel(string path, string sheet)
        {
            var cs = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0;", path);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
         */
    }
}
