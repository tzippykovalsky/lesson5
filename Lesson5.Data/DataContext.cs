using Lesson5.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lesson5.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lesson5_DB")
                .LogTo(Console.WriteLine, LogLevel.Information);
            //הוספת הדפסה בכל שאילתה-
            //מדפיס את משפט ה sql שקרה מאחורי הקלעים

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Passenger> Passes { get; set; }

        //Migration זו הדרך שבה Entity Framework Core
        //יוצרת את הטבלאות במסד הנתונים לפי המחלקות (Entities) 
        //המבנה יקבע לפי המחלקה שנמצאת ב<> של הdbset
        //(כמובן גם אם המחלקה קיימת בפרויקט אחר)
        //בשביל ליצור את המיגרציה יש להוסיף קודם רפרנס בין הפרויקטים
        //כלומר שפרויקט הדטה שבו נריץ את המיגרציה יקושר לפרויקט הstartApp

    }
}
