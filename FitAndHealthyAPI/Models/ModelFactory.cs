using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitAndHealthy;

namespace FitAndHealthyAPI.Models
{
    public class ModelFactory
    {
        private FandHContext ctx;

        public ModelFactory(FandHContext ctx)
        {
            this.ctx = ctx;
        }
        public RoleModel Create(Role role)
        {
            return new RoleModel
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public Role Parse(RoleModel role)
        {
            return new Role
            {
                Id = role.Id,
                Name = role.Name
            };
        }
        public CategoryModel Create(Category category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Trainings = category.Trainings.Select(x => Create(x)).ToList(),
                Programs = category.Programs.Select(x => Create(x)).ToList(),
                Exercises = category.Exercises.Select(x => Create(x)).ToList()
            };
        }

        public Category Parse(CategoryModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public TrainingModel Create(Training training)
        {
            return new TrainingModel
            {
                Id = training.Id,
                Name = training.Name,
                Description = training.Description,
                Rating = training.Rating,
                RatedByNo = training.RatedByNo,
                Categories = training.Categories.Select(x => Create(x)).ToList(),
                Programs = training.Programs.Select(x => Create(x)).ToList(),
                Exercises = training.Exercises.Select(x => Create(x)).ToList(),
                Comments = training.Comments.Select(x => Create(x)).ToList()
            };
        }
        public Training Parse(TrainingModel training) 
        {
            return new Training
            {
                Id = training.Id,
                Name = training.Name,
                Description = training.Description,
                Rating = training.Rating,
                RatedByNo = training.RatedByNo
            };
        }
        public ProgramModel Create(Program program)
        {
            return new ProgramModel
            {
                Id = program.Id,
                Name = program.Name,
                Description = program.Description,
                /*
                Duration = program.Duration,
                RatedByNo = program.RatedByNo,
                Rating = program.Rating,
                VideoLink = program.VideoLink,
                Author = program.Author.Username,
                AuthorId = program.Author.Id,
                Diet = program.Diet.Name,
                DietId = program.Diet.Id,
                Categories = new List<CategoryModel>(),
                Comments = new List<CommentModel>(),
                Trainings = new List<TrainingModel>(),
                Users = new List<UserModel>()
                */
                
                //Categories = program.Categories.Select(x => Create(x)).ToList(),
                //Comments = program.Comments.Select(x => Create(x)).ToList(),
                //Trainings = program.Trainings.Select(x => Create(x)).ToList(),
                //Users = program.Users.Select(x => Create(x)).ToList()
            };
        }
        public Program Parse(ProgramModel program)
        {
            using (FandHContext ctx = new FandHContext())
            {
                List<Training> trList = new List<Training>();
                foreach (Training tr in ctx.Trainings)
                {
                    trList.Add(tr);
                }

                return new Program
                {
                    Id = program.Id,
                    Name = program.Name,
                    Description = program.Description,
                    Duration = program.Duration,
                    RatedByNo = program.RatedByNo,
                    Rating = program.Rating,
                    VideoLink = program.VideoLink,
                    Author = ctx.Users.Find(program.AuthorId),
                    Diet = ctx.Diets.Find(program.DietId),
                    //Trainings = trList


                };
            }
        }

        public ExerciseModel Create(Exercise exercise)
        {
            return new ExerciseModel
            {
                Id = exercise.Id,
                Name = exercise.Name,
                RatedByNo = exercise.RatedByNo,
                Rating = exercise.Rating,
                Video = exercise.Video,
                Image = exercise.Image,
                Duration = exercise.Duration,
                Trainings = exercise.Trainings.Select(x => Create(x)).ToList(),
                Comments = exercise.Comments.Select(x => Create(x)).ToList(),
                Categories = exercise.Categories.Select(x => Create(x)).ToList()
            };
        }
        public Exercise Parse(ExerciseModel exercise)
        {
            return new Exercise
            {
                Id = exercise.Id,
                Name = exercise.Name,
                RatedByNo = exercise.RatedByNo,
                Rating = exercise.Rating,
                Video = exercise.Video,
                Image = exercise.Image
            };
        }
        public CommentModel Create(Comment comment)
        {
            return new CommentModel
            {
                Id = comment.Id,
                CommentText = comment.CommentText,
                RatedByNo = comment.RatedByNo,
                Rating = comment.Rating,
                User = comment.User.Username,
                UserId = comment.User.Id,
                Diet = comment.Diet.Name,
                DietId = comment.Diet.Id,
                Program = comment.Program.Name,
                ProgramId = comment.Program.Id,
                Training = comment.Training.Name,
                TrainingId = comment.Training.Id,
                Exercise = comment.Exercise.Name,
                ExerciseId = comment.Exercise.Id
            };
        }
        public Comment Parse(CommentModel comment)
        {
            return new Comment{
                Id = comment.Id,
                CommentText = comment.CommentText,
                RatedByNo = comment.RatedByNo,
                Rating = comment.Rating,
                User = ctx.Users.Find(comment.UserId),
                Diet = ctx.Diets.Find(comment.DietId),
                Program = ctx.Programs.Find(comment.ProgramId),
                Training = ctx.Trainings.Find(comment.TrainingId),
                Exercise = ctx.Exercises.Find(comment.ExerciseId)
            };
        }
        public UserModel Create(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Banned = user.Banned,
                Roles = user.Roles.Select(x => Create(x)).ToList(),
                Comments = user.Comments.Select(x => Create(x)).ToList(),
                Programs = user.Programs.Select(x => Create(x)).ToList(),
                UserPrograms = user.UserPrograms.Select(x => Create(x)).ToList()
            };
        }
        public User Parse(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Banned = user.Banned
            };
        }
        public DietModel Create(Diet diet)
        {
            return new DietModel
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                RatedByNo = diet.RatedByNo,
                Rating = diet.Rating,
                Comments = diet.Comments.Select(x => Create(x)).ToList(),
                Programs = diet.Programs.Select(x => Create(x)).ToList()
            };
        }
        public Diet Parse(DietModel diet)
        {
            return new Diet
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                RatedByNo = diet.RatedByNo,
                Rating = diet.Rating
            };
        }
    }
}