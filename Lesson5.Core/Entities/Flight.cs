using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Entities
{
    public class Flight
    {
        //כאן ניצור מחלקה שמתארת טיסה
        //כאשר נשתמש ב EF
        //הטבלאות יווצרו ע"פ המבנה הבא
        //המחלקות בתקיית הEntities מייצגות את המבנה האמיתי של הפרויקט
        //כלומר איך זה ממש שמור בdata ומהם הקשרים בין המחלקות
        public int Id { get; set; }
        public int Price { get; set; }
        public int Terminal { get; set; }
        public string? Gate { get; set; }
        public int NumHours { get; set; }
        public string Destination { get; set; }
        public int PilotId { get; set; }
        public List<Passenger>? Passengers { get; set; } = new();

        //תכנון המערכתת
        //טיסות לנוסעים -רבים לרבים
        //טייס לטיסות יחיד לרבים לכל טייס יש ליסט של טיסות
    }
}
