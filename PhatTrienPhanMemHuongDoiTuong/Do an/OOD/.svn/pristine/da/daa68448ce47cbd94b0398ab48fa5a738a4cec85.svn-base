using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLCHMT.Funtion
{
    class Global
    {
        public static string IncreateID(string str1)
        {
            string str2 = "";
            foreach (char ch in str1)
            {
                if (ch >= 48 && ch <= 57)
                    str2 = str2 + ch.ToString();
            }
            int i = int.Parse(str2);
            i++;
            return str1.Substring(0, str1.Length - i.ToString().Length) + i.ToString();
        }

        public static bool Compare(List<String> list_a, List<String> list_b)
        {
            if (list_a.Count != list_b.Count)
                return false;
            for (int i = 0; i < list_a.Count; i++)
                if (!list_a.ElementAt(i).ToString().Equals(list_b.ElementAt(i).ToString()))
                    return false;
            return true;
        }
    }
}
