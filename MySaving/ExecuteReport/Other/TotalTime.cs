using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySaving.ExecuteReport.Other;
using MySaving.Models;

namespace MySaving.Models
{
    public class TotalTime
    {
        //задаем массив, где будет хранится продолжительность каждого оператора 
        //0 - прочие, 1 - билайн, 2 -  мтс, 3 - мегафон, 4 - теле2
        public double[] durationEachOperatorCall=new double[5];
        public double[] percentDurationEachOperatorCall = new double[5];
        public double[] durationEachOperatorSms = new double[5];
        public double[] percentDurationEachOperatorSms = new double[5];
        //результат подсчёта по времени
        List<SpecificationList> resultTimeOperator;
        //общее время
        double summaryTimeCall=0;
        double summaryTimeSms = 0;
        List<SpecificationList> resultPercentOpertor = new List<SpecificationList>();
        NumberOperator operatorNameClass = new NumberOperator();
        public TotalTime(List<SpecificationList> resultTimeOperator)
        {
            this.resultTimeOperator = resultTimeOperator;
            foreach (var result in resultTimeOperator)
            {
                if (result.Service == "Вызов")
                {
                    summaryTimeCall += result.Duration;
                }
                else if (result.Service == "СМС")
                {
                    summaryTimeSms += result.Duration;
                }
                
            }
        }
        public void SummarizeDurationOperator()
        {

            for (int i = 0; i < resultTimeOperator.Count; i++)
            {
                if (resultTimeOperator[i].Service == "Вызов")
                {
                    if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[0])
                        durationEachOperatorCall[0] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[1])
                        durationEachOperatorCall[1] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[2])
                        durationEachOperatorCall[2] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[3])
                        durationEachOperatorCall[3] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[4])
                        durationEachOperatorCall[4] += resultTimeOperator[i].Duration;
                }
                else if (resultTimeOperator[i].Service=="СМС")
                {
                    if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[0])
                        durationEachOperatorSms[0] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[1])
                        durationEachOperatorSms[1] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[2])
                        durationEachOperatorSms[2] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[3])
                        durationEachOperatorSms[3] += resultTimeOperator[i].Duration;
                    else if (resultTimeOperator[i].Operator == operatorNameClass.operatorName[4])
                        durationEachOperatorSms[4] += resultTimeOperator[i].Duration;
                }
            }
        }
        public void SummarizeDurationPercentOperator()
        {
            SummarizeDurationOperator();
            for (int i = 0; i < 5; i++)
            {
                percentDurationEachOperatorCall[i] = durationEachOperatorCall[i] * 100 / summaryTimeCall;
                percentDurationEachOperatorSms[i] = durationEachOperatorSms[i] * 100 / summaryTimeSms;
            }
        }
    }
}