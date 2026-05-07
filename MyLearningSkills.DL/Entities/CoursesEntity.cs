using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLearningSkills.DL.Entities
{
    [Table("Courses")]
    public class CoursesEntity : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Description { get; set; }

        public decimal Duration { get; set; }

        public decimal Rating { get; set; }
    }
}
