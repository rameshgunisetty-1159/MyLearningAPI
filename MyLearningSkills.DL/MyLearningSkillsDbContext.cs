using Microsoft.EntityFrameworkCore;
using MyLearningSkills.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.DL
{
    public class MyLearningSkillsDbContext : DbContext
    {
        public MyLearningSkillsDbContext(DbContextOptions<MyLearningSkillsDbContext> options) : base(options)
        {
        }
        public DbSet<CoursesEntity> CoursesEntities { get; set; }
    }
}
