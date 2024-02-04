using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompanyAPI.Data.Relational.Exceptions
{
    public class EnvironmentVariableNotFoundException : Exception
    {
        public EnvironmentVariableNotFoundException(string message)
            : base(message)
        {
        }

        public EnvironmentVariableNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
