using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class rule
    {
        /// <summary>
        /// check number  
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckNumber(string number)
        {


            // check number

            for (int i = 0; i < number.Length; i++)
            {
                try
                {
                    int a = int.Parse(number[i].ToString());
                }
                catch (Exception e)
                {
                    return false;
                }
            }
                
           

            return true;
        }
        /// <summary>
        /// check lengh
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CheckLengh(string text)
        {
            return text.Length;
            
        }
        /// <summary>
        /// check phone
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckPhone(string number)
        {
            if (CheckNumber(number) == true && CheckLengh(number) > 9 && CheckLengh(number) <12)
            {
                if(int.Parse(number[0].ToString())==0)
                     return true;
            }
               
            return false;
        }
        public bool CheckNumberID(string numberId)
        {
            if (CheckNumber(numberId) == true && CheckLengh(numberId) > 8 && CheckLengh(numberId) < 13)
            {
                 
                    return true;
            }

            return false;
        }

    }

   
}
