using NCRTask.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCRTask.Implementaion
{
    public class NCRLog : INCRlog
    {
        public void log(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public void log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
