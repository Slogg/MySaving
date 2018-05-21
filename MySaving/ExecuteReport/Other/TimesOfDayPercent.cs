using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySaving.ExecuteReport.Other;
using MySaving.Models;

namespace MySaving.ExecuteReport.Other
{
    public class TimesOfDayPercent
    {
        //интервалы времени
        TimeSpan morning = new TimeSpan(6, 0, 0);
        TimeSpan daytime = new TimeSpan(12, 0, 0);
        TimeSpan evening = new TimeSpan(18, 0, 0);
        TimeSpan night = new TimeSpan(24, 0, 0);
        //задаем массив, где будет хранится продолжительность операций по времени суток
        //первое значение - сервис, второй - время суток
        public double[,] durationService= new double[3,4];
        public double[,] percentDurationService=new double[3,4];
        //результат подсчёта по времени
        List<SpecificationList> resultTime;
        //общее время
        double summaryTime = 0;
        int count;
        List<SpecificationList> resultPercentOpertor = new List<SpecificationList>();
        NumberOperator operatorNameClass = new NumberOperator();
        public TimesOfDayPercent(List<SpecificationList> resultTime)
        {
            this.resultTime = resultTime;
            foreach (var result in resultTime)
            {
                summaryTime += result.Duration;
            }
        }


        public void DetermineTimesOfDay()
        {
            
            for (int i = 0; i < resultTime.Count; i++)
            {
                if (resultTime[i].Time < daytime)
                {
                    if (resultTime[i].Service == "Вызов")
                    {
                        durationService[0, 0] += resultTime[i].Duration;
                    }
                    else if (resultTime[i].Service == "СМС")
                    {
                        durationService[1, 0] += resultTime[i].Duration;
                    }
                    else
                    {
                        durationService[2, 0] += resultTime[i].Duration;
                    }
                }
                else if (resultTime[i].Time < evening)
                {
                    if (resultTime[i].Service == "Вызов")
                    {
                        durationService[0, 1] += resultTime[i].Duration;
                    }
                    else if (resultTime[i].Service == "СМС")
                    {
                        durationService[1, 1] += resultTime[i].Duration;
                    }
                    else
                    {
                        durationService[2, 1] += resultTime[i].Duration;
                    }
                }
                else if (resultTime[i].Time < night)
                {
                    if (resultTime[i].Service == "Вызов")
                    {
                        durationService[0, 2] += resultTime[i].Duration;
                    }
                    else if (resultTime[i].Service == "СМС")
                    {
                        durationService[1, 2] += resultTime[i].Duration;
                    }
                    else
                    {
                        durationService[2, 2] += resultTime[i].Duration;
                    }
                }
                else if (resultTime[i].Time < morning)
                {
                    if (resultTime[i].Service == "Вызов")
                    {
                        durationService[0, 3] += resultTime[i].Duration;
                    }
                    else if (resultTime[i].Service == "СМС")
                    {
                        durationService[1, 3] += resultTime[i].Duration;
                    }
                    else
                    {
                        durationService[2, 3] += resultTime[i].Duration;
                    }
                }

            }

        }
        public void DetermineProcentTimesOfDay()
        {
            DetermineTimesOfDay();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    percentDurationService[i, j] = durationService[i, j] * 100 / summaryTime;
                }
                
            }
        }
    }
}