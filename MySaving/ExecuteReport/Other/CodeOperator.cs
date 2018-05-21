using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySaving.ExecuteReport.Other
{
    //коды операторов. МОЖЕТ ОБЪЕДЕНИТЬ В ОДИН МАССИВ?
    public class CodeOperator
    {
        public int[] megafonCodeArray;
        public int[] beelineCodeArray;
        public int[] mtsCodeArray;
        public int[] tele2CodeArray;
        public CodeOperator()
        {
            megafonCodeArray = new int[]{997, 999, 920, 921, 922, 923, 924, 925, 926,
                927, 928, 929, 930, 931, 932, 933, 934, 936, 937, 938, 939};
            mtsCodeArray = new int[]{910, 911, 912, 913, 914, 915, 916,  917, 918, 919,
                978, 980, 981, 982, 983, 984, 985, 986, 987,  989, 988};
            beelineCodeArray = new int[]{960, 961, 962, 963, 964, 965, 966, 967,
                968, 969, 908, 909, 951, 903, 902, 900, 905, 906, 904};
            tele2CodeArray = new int[] { 953, 950, 951, 904, 900, 908, 952, 902 };
        }
    }
}