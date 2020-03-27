using System;

namespace AfricasTalking.USSD
{
    public class Handler: USSD
    {

        /// <summary>
        /// Returns int array, takes the Text request and returns a basic int array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int[] ReqHandler(string text)
        {
            // Splits the text to a string array

            string[] strSplit = text.Split('*');


            // Convert String array to Int array

            int[] ussdArr = Array.ConvertAll<String, Int32>(strSplit, s => Int32.Parse(s));


            return ussdArr;
        }

        /// <summary>
        /// Returns a Back handled menu int array, 
        /// 0  - 1 Step
        /// 00 - 2 Step
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override int[] BackHandler(string text)
        {
            // Splits the text to a string array

            string[] strSplit = text.Split('*');

            int arr_Length = strSplit.Length;
            

            // Check last Item if it's O

            if (strSplit[arr_Length - 1] == "0"  && arr_Length >= 2)
            {
                // Resize the Array to 1 Step

                Array.Resize(ref strSplit, arr_Length - 1);
            }

            else if (strSplit[arr_Length - 1] == "00" && arr_Length >= 3)
            {
                // Resize the Array to 2 Step 

                Array.Resize(ref strSplit, arr_Length - 2);
            }

            // Convert String array to Int array

            int[] ussdArr = Array.ConvertAll<String, Int32>(strSplit, s => Int32.Parse(s));


            return ussdArr;
        }
    }
}
