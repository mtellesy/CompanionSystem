using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.ResponseObjects
{
  public  class ResultsObject
    {   
        public String course_id { set; get; }
        public List<float> midMark { set; get; }
        public float finalMark { set; get; }
    }
}
