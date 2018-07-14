using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_Exception
{
    public class UserException : ApplicationException
    {
        public UserException()
            : base()
        {
        }

        public UserException(string message)
            : base(message)
        {
        }
        public UserException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
