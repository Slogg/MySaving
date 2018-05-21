using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySaving.ExecuteReport.Other;
using MySaving.Models;


//определяет процентное соотношение на стиль общения. Выходные, часы и пр...


namespace MySaving.ExecuteReport.Other
{
    public class StyleCommunicationPercent
    {
        //задаем массив, где будет хранится продолжительность операций по выходным/будням
        //первое значение - сервис, второй - время суток
        public double[,] durationService = new double[3, 2];
        public double[,] percentDurationService = new double[3, 2];
        //результат подсчёта по времени
        List<SpecificationList> resultTime;
        //общее время
        double summaryTime = 0;
        int count;
        List<SpecificationList> resultPercentOpertor = new List<SpecificationList>();
        NumberOperator operatorNameClass = new NumberOperator();
        public StyleCommunicationPercent(List<SpecificationList> resultTime)
        {
            this.resultTime = resultTime;
            foreach (var result in resultTime)
            {
                summaryTime += result.Duration;
            }
        }


        public void DetermineOperationsWeekTime()
        {
            for (int i = 0; i < resultTime.Count; i++)
            {
                if (resultTime[i].Date.DayOfWeek.ToString() == "Monday" ||
                    resultTime[i].Date.DayOfWeek.ToString() == "Tuesday" ||
                    resultTime[i].Date.DayOfWeek.ToString() == "Wednesday" ||
                    resultTime[i].Date.DayOfWeek.ToString() == "Thursday" ||
                    resultTime[i].Date.DayOfWeek.ToString() == "Friday")
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
                else
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
            }

        }
        public void SummarizeDurationPercentOperator()
        {
            DetermineOperationsWeekTime();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    percentDurationService[i, j] = durationService[i, j] * 100 / summaryTime;
                }

            }
        }
    }
}