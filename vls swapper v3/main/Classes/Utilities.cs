using Newtonsoft.Json.Linq;
using System;

namespace vls_swapper_v3.Classes
{
    class Utilities
    {
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
            {
                try
                {
                    JToken obj = JToken.Parse(strInput);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
