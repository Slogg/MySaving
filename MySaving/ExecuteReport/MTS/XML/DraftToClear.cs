using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySaving.Models;
using MySaving.ExecuteReport.Other;


namespace MySaving.ExecuteReport.MTS.XML
{
    //очищаем список со всеми объектами от различных ненужных данный. 
    //преобразучем в чистый список
    public class DraftToClear
    {
        //экземлпяр класса, в котором XML преобразуется в List
        XmlToDraft draftClass = new XmlToDraft();
        NumberOperator numberOperator = new NumberOperator();
        //экземпляр класса, в котором время из List  переводится в секунды
        TransformationData transformationListDate = new TransformationData();
        TransformationNumber transformationNumber = new TransformationNumber();
        int[] date, time;
        string number;
        public List<SpecificationModel> clearList = new List<SpecificationModel>();
        public void TransformListInClearList()
        {
            transformationListDate.DraftListInTransformListMethod();
            //из List для редактирования в результатирующий List 
            for (int i = 0; i < transformationListDate.transformList.Count; i++)
            {
                //получить возвращаемый массив DraftDateInTransformDate и присвоить массиву data
                date = transformationListDate.DraftDateInTransformDate(transformationListDate.transformList[i].Date);
                //получить "отшлифованный" номер
                number = transformationNumber.RemoveExcessSymbol(transformationListDate.transformList[i].Number);
                //получиь возвращаемый массив времени из DraftDateInTransformTime
                time = transformationListDate.DraftDateInTransformTime(transformationListDate.transformList[i].Date);
                clearList.Add(new SpecificationModel()
                {
                    Number = number,
                    //получаем оператора
                    Operator = numberOperator.DefineOperator(number),
                    Date = new DateTime(date[2], date[1], date[0]),
                    Time = new TimeSpan(time[0], time[1], time[2]),
                    Service = transformationListDate.DetermineService(transformationListDate.transformList[i].Service),
                    //переводим в double результат метода DurationSecondResult, который выдаёт в виде строки количество времени разговора
                    // с двумя цифрами после запятой
                    Duration = double.Parse(transformationListDate.DurationResult(transformationListDate.transformList[i].Duration,
                    transformationListDate.transformList[i].Service)),
                    Type = transformationListDate.DetermineType(transformationListDate.transformList[i].Number)
                });
            }
        }
    }
}