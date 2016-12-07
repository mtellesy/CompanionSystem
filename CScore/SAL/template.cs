using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
   public abstract class Template
    {
        private List<String> response;

        public List<String> getResponse()
        {
            return response;
        }

        public void setResponse(List<String> newResponse)
        {
           this.response = newResponse;
        }
    }
}
