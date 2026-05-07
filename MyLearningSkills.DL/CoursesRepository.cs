using MyLearningSkills.DL.Entities;
using MyLearningSkills.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.DL
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly MyLearningSkillsDbContext _dbContext;
        public CoursesRepository(MyLearningSkillsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCourse(CoursesEntity course)
        {
            _dbContext.CoursesEntities.Add(course);
            _dbContext.SaveChanges();
        }

        public void DeleteCourse(CoursesEntity course)
        {
            _dbContext.CoursesEntities.Remove(course);
            _dbContext.SaveChanges();
        }

        public IQueryable<CoursesEntity> GetAllCourses()
        {
            return _dbContext.CoursesEntities;
        }

        public void UpdateCourse(CoursesEntity course)
        {
            _dbContext.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.Entry(course).CurrentValues.SetValues(course);
            _dbContext.SaveChanges();

        }
    }
}
