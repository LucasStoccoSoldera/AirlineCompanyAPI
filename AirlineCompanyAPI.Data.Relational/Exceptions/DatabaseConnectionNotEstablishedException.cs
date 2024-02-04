using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompanyAPI.Data.Relational.Exceptions
{
    public class DatabaseConnectionNotEstablishedException : Exception
    {

        public DatabaseConnectionNotEstablishedException(string message)
            : base(message)
        {
        }

        public DatabaseConnectionNotEstablishedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
