using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//simple test

//Test 


namespace SimpleTest
{
    public static class MyTest
    {
        public static string CalculateTotal(string someInput)
        {
            if (someInput == null)
            {
                throw new DataMisalignedException("data not correct");
            }
            var log = new ConsoleLogger();
            log.Log("start CalculateTotal");
            if (someInput == "Go baby, go")
            {                
                return "baby Go go";
            }
            log.Log("end CalculateTotal");
            return someInput;            
        }

        private interface ILogger
        {
            void Log(string stuff);
        }

        internal class ConsoleLogger : ILogger
        {
            public void Log(string stuff)
            {
                Console.WriteLine(stuff);
            }
        }

    }
}
