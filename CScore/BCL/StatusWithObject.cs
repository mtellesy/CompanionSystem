using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
    public class StatusWithObject<T>
    {
        public Status status;
        public T statusObject;
        public int statusCode;

        public static implicit operator StatusWithObject<T>(List<Course> v)
        {
            throw new NotImplementedException();
        }
    }
}
