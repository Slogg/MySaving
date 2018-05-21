using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySaving.ExecuteReport.Other
{
    //АЛГОРИТМ ТУПОЙ И НЕОБДУМАННЫЙ, НО РАБОТАЕТ
    //определение оператора по номеру
    public class NumberOperator
    {
        //массив с названиями операторов
        public string[] operatorName = new string[] { "Other", "Beeline", "MTC", "Megafon", "Tele2" };
        //строка будет содержать первый три символа номера
        string codeOperatorFromNumber;
        public string operatorStr;
        CodeOperator codeOperator = new CodeOperator();
        public NumberOperator()
        {

        }
        public string DefineOperator(string number)
        {
            operatorStr = operatorName[0];
            if (number.Length > 3)
                codeOperatorFromNumber = number.Remove(3);

            for (int i = 0; i < codeOperator.beelineCodeArray.Length; i++)
            {
                if (codeOperatorFromNumber == codeOperator.beelineCodeArray[i].ToString())
                {
                    operatorStr = operatorName[1];
                }

            }
            for (int i = 0; i < codeOperator.mtsCodeArray.Length; i++)
            {
                if (codeOperatorFromNumber == codeOperator.mtsCodeArray[i].ToString())
                {
                    operatorStr = operatorName[2];
                }
            }
            for (int i = 0; i < codeOperator.megafonCodeArray.Length; i++)
            {
                if (codeOperatorFromNumber == codeOperator.megafonCodeArray[i].ToString())
                {
                    operatorStr = operatorName[3];
                }
            }
            for (int i = 0; i < codeOperator.tele2CodeArray.Length; i++)
            {
                if (codeOperatorFromNumber == codeOperator.tele2CodeArray[i].ToString())
                {
                    operatorStr = operatorName[4];
                }
            }
            return operatorStr;
        }
    }
}