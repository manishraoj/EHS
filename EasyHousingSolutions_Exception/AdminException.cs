using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_Exception
{
    public class AdminException : ApplicationException
    {
        public AdminException()
            : base()
        {
        }

        public AdminException(string message)
            : base(message)
        {
        }
        public AdminException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
