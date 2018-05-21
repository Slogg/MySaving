using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySaving.ExecuteReport.MTS.XML
{
    //Трансформация номера. Работа только со свойством Number из списка
   public class TransformationNumber
    {
        //строка с номером без символа входящего вызова
        string numberWithoutSymbolIncomingCall;
        //обозначение входящего вызова. ПОКА НЕ ТРЕБУЕТСЯ
        const string incomingСallSymbol = "<--";
        TransformationData transformationDate = new TransformationData();

        //удалить символ входящего вызова для более понятного
        //визуального представления
        public string RemoveSymbolAnIncomingCall(string number)
        {
            if (number[0] == '<')
            {
                numberWithoutSymbolIncomingCall = number.Remove(0, 3);
            }
            else
            {
                numberWithoutSymbolIncomingCall = number;
            }
            return numberWithoutSymbolIncomingCall;
        }
        //удаляем лишние символы с номера, оставляя только стандарт
        public string RemoveExcessSymbol(string number)
        {
            //избавляем любой номер входящий от "<--"
            number = RemoveSymbolAnIncomingCall(number);
            //если в строке больше 10 символов, то обрезаем до кода всё
            if (number.Length > 10)
            {
                number = new string(number.Reverse().ToArray());
                number = number.Remove(10);
                number = new string(number.Reverse().ToArray());
            }
            return number;
        }
    }
}
