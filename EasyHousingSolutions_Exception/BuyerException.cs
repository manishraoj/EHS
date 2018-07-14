using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_Exception
{
    public class BuyerException : ApplicationException
    {
        public BuyerException()
            : base()
        {
        }

        public BuyerException(string message)
            : base(message)
        {
        }
        public BuyerException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
