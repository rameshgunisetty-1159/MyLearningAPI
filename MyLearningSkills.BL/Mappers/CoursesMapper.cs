using MyLearningSkills.DL.Entities;
using MyLearningSkills.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.BL.Mappers
{
    public class CoursesMapper
    {
        public static CourseDto Map(CoursesEntity from, CourseDto to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Created = from.CreatedDate;
            to.Updated = from.ModifiedDate;
            to.Duration = from.Duration;
            to.Rating = from.Rating;
            return to;
        }

        public static CoursesEntity Map(CourseDto from, CoursesEntity to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
            to.CreatedDate = from.Created;
            to.ModifiedDate = from.Updated;
            to.Duration = from.Duration;
            to.Rating = from.Rating;
            return to;
        }
    }
}
