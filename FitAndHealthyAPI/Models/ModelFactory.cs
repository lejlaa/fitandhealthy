using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitAndHealthy;

namespace FitAndHealthyAPI.Models
{
    public class ModelFactory
    {
        public ActionModel Create(FitAndHealthy.Action action)
        {
            return new ActionModel
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description,
                Roles = action.Roles.Select(x => Create(x,false)).ToList()
            };
        }
        public FitAndHealthy.Action Parse(ActionModel action)
        {
            return new FitAndHealthy.Action
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description
            };
        }
        public RoleModel Create(Role role, bool withActions)
        {
            return new RoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Actions = (withActions) ? role.Actions.Select(x => Create(x)).ToList() : null
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
                Duration = program.Duration,
                RatedByNo = program.RatedByNo,
                Rating = program.Rating,
                VideoLink = program.VideoLink,
                Author = program.Author.Username,
                AuthorId = program.Author.Id,
                Diet = program.Diet.Name,
                DietId = program.Diet.Id,
                Categories = program.Categories.Select(x => Create(x)).ToList(),
                Comments = program.Comments.Select(x => Create(x)).ToList(),
                Trainings = program.Trainings.Select(x => Create(x)).ToList(),
                Users = program.Users.Select(x => Create(x)).ToList()
            };
        }
        public Program Parse(ProgramModel program)
        {
            using (FandHContext ctx = new FandHContext())
            {

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
                    Diet = ctx.Diets.Find(program.DietId)
                };
            }
        }
    }
}