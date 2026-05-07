using MyLearningSkills.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.BL.Interfaces
{
    public interface ICoursesBusinessLogic
    {
        List<CourseDto> GetAllCourses();

        CourseDto AddCourse(CourseDto course);

        CourseDto UpdateCourse(int id, CourseDto course);

        void DeleteCourse(int id);
    }
}
