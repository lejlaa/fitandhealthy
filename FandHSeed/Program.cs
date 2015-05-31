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
        static string sourceData = @"C:\Users\Layla\Documents\GitHub\fitandhealthy\FitandHealthyData.xls";
        static void Main(string[] args)
        {
            getPrograms();
            //getTrainings();
            Console.ReadLine();

        }
        static void getPrograms()
        {
            //DataTable rawData = OpenExcel(sourceData, "Programs");
            using (var ctx = new FandHContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;

                ctx.Configuration.ValidateOnSaveEnabled = false;

                Role r = new Role();
                r.Name = "role";
                ctx.Roles.Add(r);

                User author = new User();
                author.Username = "Emir";
                author.Password = "fs";
                ctx.Users.Add(author);


                //ctx.SaveChanges();


                FitAndHealthy.Action action = new FitAndHealthy.Action();
                action.Name = "This is my action";
                action.Description = "Description";
                ctx.Actions.Add(action);


                Diet someDiet = new Diet();
                someDiet.Name = "SomeDiet";
                someDiet.Description = "fakifakfhadhfsdjfh";
                ctx.Diets.Add(someDiet);


                FitAndHealthy.Program pr1 = new FitAndHealthy.Program();
                pr1.Name = "Program 1";
                pr1.Description = "blabla";
                pr1.Author = author;
                pr1.Diet = someDiet;
                ctx.Programs.Add(pr1);

                FitAndHealthy.Program pr2 = new FitAndHealthy.Program();
                pr2.Name = "Program 2";
                pr2.Description = "blablabla";
                pr2.Author = author;
                pr2.Diet = someDiet;
                ctx.Programs.Add(pr2);

                /*
                foreach (DataRow row in rawData.Rows)
                {
                    FitAndHealthy.Program program = new FitAndHealthy.Program();
                    program.Name = row.ItemArray.GetValue(1).ToString();
                    ctx.Programs.Add(program);
                }*/
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
    }
}
