﻿using System;
using System.Collections.Generic;

namespace EasyHarmonica.BLL.DTO
{
    public class AchievementDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
        public double PromotionPercentage { get; set; }
        public bool Timeliness { get; set; }

        public int LessonId { get; set; }
        public virtual LessonDTO Lesson { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
