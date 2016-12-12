using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.SAL
{
   public abstract class Template
    {
        private String response;
        private int statusCode;

        public int getStatusCode()
        {
            return statusCode;
        }

        public void setStatusCode(int newStatusCode)
        {
            this.statusCode = newStatusCode;
        }

        public String getResponse()
        {
            return response;
        }

        public void setResponse(String newResponse)
        {
           this.response = newResponse;
        }
    }
}
