using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCRTask.IServices
{
     public interface INCRlog
    {

        void log(Exception e);
        void log(string message);
       
    }
}
