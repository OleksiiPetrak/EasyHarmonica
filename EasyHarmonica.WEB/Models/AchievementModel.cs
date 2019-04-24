using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHarmonica.WEB.Models
{
    public class AchievementModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
        public double PromotionPercentage { get; set; }
        public bool Timeliness { get; set; }

        public int LessonId { get; set; }
        public virtual LessonModel Lesson { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
    }
}