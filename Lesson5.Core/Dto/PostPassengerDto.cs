using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Core.Dto
{
    //DTO שייך לשכבת ה-API / השירותים — משקף את מה שאנחנו רוצים לשלוח או לקבל.

    //    למה חשוב להפריד בין DTO ל-Entity?
    //הגנה על הדומיין – אנחנו לא רוצים לחשוף את המבנה הפנימי של המערכת.
    //שליטה מלאה על הנתונים שיוצאים ונכנסים – כולל ולידציות.
    //שכבות עצמאיות – כל שכבה יודעת רק את מה שהיא צריכה לדעת.
    //ביצועים – DTO שולח רק את המידע שצריך, בלי ניפוחים מיותרים
    //גמישות לפיתוח עתידי – אפשר לשנות Entity בלי לשבור את ה-API.


    public class PostPassengerDto
    {
        public string FullName { get; set; }
        public string PassportNumber { get; set; }
    }
}
