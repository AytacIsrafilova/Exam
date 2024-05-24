using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class NotNullException : Exception
    { 
        public string PropertyName { get; set; }
        public NotNullException(string proprtyName,string? message) : base(message)
        {
            PropertyName = proprtyName;
        }
    }
}
