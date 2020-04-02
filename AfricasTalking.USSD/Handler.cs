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
        public int[] ReqHandler(string text)
        {
            // Splits the text to a string array

            string[] strSplit = text.Split('*');


            // Convert String array to Int array

            if(!String.IsNullOrEmpty(strSplit[0]))
            {
                int[] ussdArr = Array.ConvertAll<String, Int32>(strSplit, s => Int32.Parse(s));


                return ussdArr;
            }
            return new int[] { };
        }

        /// <summary>
        /// Returns a Back handled menu int array, 
        /// 0  - 1 Step
        /// 00 - Home
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override int[] BackHandler(string text)
        {
            // Splits the text to a string array

            string[] strSplit = text.Split('*');

            int arr_Length = strSplit.Length;
            

            // Check last Item if it's O

            if ((strSplit[arr_Length - 1] == "0" ||  String.IsNullOrEmpty(strSplit[arr_Length -1])) && arr_Length >= 2)
            {


                // Resize the Array to 1 Step

                Array.Resize(ref strSplit, arr_Length - 2);
            }

            else if ((strSplit[arr_Length - 1] == "00" || String.IsNullOrEmpty(strSplit[arr_Length - 1])) && arr_Length >= 2)
            {
                // Resize the Array to Home

                Array.Resize(ref strSplit, 0);
            }

            // Convert String array to Int array

            if(strSplit != null)
            {
                int[] ussdArr = Array.ConvertAll<String, Int32>(strSplit, s => Int32.Parse(s));


                return ussdArr;
            }

            return new int[] { };
            
        }
    }
}
