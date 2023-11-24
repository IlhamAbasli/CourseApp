using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string msj) : base(msj)
        {
            
        }
    }
}
