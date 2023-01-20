using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Services.Weather
{
    public class WeatherConversions
    {
        public static int CtoF(int degreesC) => 32 + (int)(degreesC / 0.5556);

        public static int FtoC(int degreesF) => (int)((degreesF - 32) * 0.5556);
    }
}
