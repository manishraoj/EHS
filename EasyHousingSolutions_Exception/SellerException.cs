using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHousingSolutions_Exception
{
    public class SellerException : Exception
    {
        public SellerException()
            : base()
        {
        }

        public SellerException(string message)
            : base(message)
        {
        }
        public SellerException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
