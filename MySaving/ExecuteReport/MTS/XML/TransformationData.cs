using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySaving.Models;

namespace MySaving.ExecuteReport.MTS.XML
{
    //Трансформация LIST из XML в "Стандартный" LIST
    public class TransformationData
    {
        //строка для хранения типа Вызова/смс
        public string type;
        //строка для хранения правильного представления вызова
        public string serviceValid;
        //тип вызова. Как будет предоставлен в список
        const string inbox = "Входящий";
        const string outbox = "Исходящий";
        //услуга. вызов или смс
        const string call = "Вызов";
        const string sms = "СМС";
        const string traff = "Интернет";
        int[] resultDateArray;
        XmlToDraft draftClass = new XmlToDraft();
        //transformList для операций внутри класса clearList - для конечного результата
        public List<SpecificationString> transformList = new List<SpecificationString>();
        //загоняем все данные списка из класса XmlToListDraft в новый список для обработки
        public void DraftListInTransformListMethod()
        {
            foreach (var item in draftClass.ResultXmlToList())
            {
                transformList.Add(new SpecificationString()
                {
                    Number = item.Number,
                    Date = item.Date,
                    Service = item.Service,
                    Duration = item.Duration
                });
            }
        }
        //Дату из XML разбираем по полям. 
        public int[] DraftDateInTransformDate(string dateStr)
        {
            //удаляем время
            dateStr = dateStr.Remove(dateStr.IndexOf(' '));
            // загоняем в массив числа из даты пропуская "." при помощи linq
            resultDateArray = dateStr.
                Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).
                Select(n => int.Parse(n)).ToArray();
            return resultDateArray;
        }
        //Время из XML разбираем по полям
        public int[] DraftDateInTransformTime(string timeStr)
        {
            //будут храниться значения каждого поля времени
            int[] resultTimeArray;
            //удаляем дату
            int i = timeStr.IndexOf(' ');
            timeStr = timeStr.Remove(0, i + 1);
            resultTimeArray = timeStr.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).
                Select(n => int.Parse(n)).ToArray();
            return resultTimeArray;

        }
        //переводим первичную строку из DraftList в секунды
        public string DurationResult(string primaryString, string service) 
        {
            if (service=="Телеф.")
            {
                TimeSpan timeHMS;
                //при помощи Linq записываем в массив значения времени, разделяя ячейки при помощи Split(':')
                int[] arrayTime = primaryString.
                    Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(n => int.Parse(n)).ToArray();
                if (arrayTime.Length == 2)
                {
                    timeHMS = new TimeSpan(0, arrayTime[0], arrayTime[1]);
                }
                else if (arrayTime.Length == 3)
                {
                    timeHMS = new TimeSpan(arrayTime[0], arrayTime[1], arrayTime[2]);
                }
                else
                {
                    timeHMS = new TimeSpan(0, 0, arrayTime[0]);
                }
                //полученное время преобразовываем в минуты/секунды/часы
                double time= timeHMS.TotalMinutes;
                return time.ToString("#.##");
            }
            else if(service=="sms i")
            {
                return "1";
            }
            else
            {
                return primaryString.Remove(primaryString.IndexOf('K'));
            }
            
           
        }
        //определяем тип вызова. Для входящих вызовов - первый символ всгеда = '<'
        //возвращает строку типа вызова и принимает строку(номер)
        public string DetermineType(string number)
        {

            if (number[0] == '<')
            {
                type = inbox;
            }
            else
            {
                type = outbox;
            }
            return type;
        }
        //определяем тип сервиса(смс или вызов)
        public string DetermineService(string service)
        {
            if(service=="Телеф.")
            {
                serviceValid = call;
            }
            else if(service=="sms i")
            {
                serviceValid = sms;
            }
            else
            {
                serviceValid = traff;
            }
            return serviceValid;
        }

    }
}
