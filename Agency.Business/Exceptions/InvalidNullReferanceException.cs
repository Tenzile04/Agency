using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Exceptions
{
    public class InvalidNullReferanceException : Exception
    {
        public string PropertyName { get; set; }

        public InvalidNullReferanceException()
        {

        }
        public InvalidNullReferanceException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
