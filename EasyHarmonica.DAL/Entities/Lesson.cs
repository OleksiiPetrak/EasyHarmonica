﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHarmonica.DAL.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(65)]
        [Index("IX_key", 1, IsUnique = true)]
        public string Name { get; set; }

        public string Info { get; set; }
        public string Tuner { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<User> Users { get; set; }

        [ForeignKey("Chapter")]
        public int ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
