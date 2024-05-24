using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class FileContentTypeException:Exception
    {
        public string PropertyName { get; set; }
        public FileContentTypeException(string proprtyName, string? message) : base(message)
        {
            PropertyName = proprtyName;
        }
    }
}
