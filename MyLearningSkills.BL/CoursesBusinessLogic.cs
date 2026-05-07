using MyLearningSkills.BL.Interfaces;
using MyLearningSkills.BL.Mappers;
using MyLearningSkills.DL.Entities;
using MyLearningSkills.DL.Interfaces;
using MyLearningSkills.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace MyLearningSkills.BL
{
    public class CoursesBusinessLogic : ICoursesBusinessLogic
    {
        private readonly ICoursesRepository _coursesRepository;
        public CoursesBusinessLogic(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public CourseDto AddCourse(CourseDto courseDto)
        {
            CoursesEntity courseEntity = new();
            CoursesMapper.Map(courseDto, courseEntity);
            _coursesRepository.AddCourse(courseEntity);
            CoursesMapper.Map(courseEntity, courseDto);
            return courseDto;
        }

        public void DeleteCourse(int id)
        {
            var existingEntity = _coursesRepository.GetAllCourses().FirstOrDefault(x => x.Id == id);
            if (existingEntity is null)
            {
                throw new Exception($"Course with id {id} not found.");
            }

            _coursesRepository.DeleteCourse(existingEntity);
        }

        public List<CourseDto> GetAllCourses()
        {
            // Implementation for retrieving all courses
            var courses = _coursesRepository.GetAllCourses();

            var courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                CourseDto courseDto = new();
                CoursesMapper.Map(course, courseDto);
                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }

        public CourseDto UpdateCourse(int id, CourseDto course)
        {
            if (id != course.Id)
            {
                throw new Exception("Id passed in route param doesn't match with id contains in course object");
            }

            var existingEntity = _coursesRepository.GetAllCourses().FirstOrDefault(x => x.Id == course.Id);
            if (existingEntity is null)
            {
                throw new Exception($"Course with id {course.Id} not found.");
            }

            CoursesMapper.Map(course, existingEntity);
            _coursesRepository.UpdateCourse(existingEntity);
            CoursesMapper.Map(existingEntity, course);
            return course;
        }
    }
}
