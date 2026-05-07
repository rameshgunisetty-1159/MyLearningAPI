using MyLearningSkills.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.DL.Interfaces
{
    public interface ICoursesRepository
    {
        IQueryable<CoursesEntity> GetAllCourses();

        void AddCourse(CoursesEntity course);

        void UpdateCourse(CoursesEntity course);

        void DeleteCourse(CoursesEntity course);
    }
}
