using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScore.BCL
{
   public class AllResult
    {
        //              *** Properties ***
         String cou_id { get; set; }
         String cou_nameAR { get; set; }
         String cou_nameEN { get; set; }
         int ter_id { get; set; }
         String ter_nameAR { get; set; }
         String ter_nameEN { get; set; }
         String year { get; set; }
         int cou_credits { get; set; }
         float res_total { get; set; }

        //              *** setters and getters ***

        //        cou_id
        public String Cou_id
        {
            set
            {
                cou_id = value;
            }
            get
            {
                return cou_id;
            }
        }
        //        cou_nameAR
        public String Cou_nameAR
        {
            set
            {
                cou_nameAR = value;
            }
            get
            {
                return cou_nameAR;
            }
        }
        //        cou_nameEN
        public String Cou_nameEN
        {
            set
            {
                cou_nameEN = value;
            }
            get
            {
                return cou_nameEN;
            }
        }
        //        ter_id
        public int Ter_id
        {
            set
            {
                ter_id = value;
            }
            get
            {
                return ter_id;
            }
        }
        //        ter_nameAR
        public String Ter_nameAR
        {
            set
            {
                ter_nameAR = value;
            }
            get
            {
                return ter_nameAR;
            }
        }        
        //        cou_id
        public String Ter_nameEN
        {
            set
            {
                ter_nameEN = value;
            }
            get
            {
                return ter_nameEN;
            }
        }
        //        year
        public String Year
        {
            set
            {
                year = value;
            }
            get
            {
                return year;
            }
        }
        //        cou_credits
        public int Cou_credits
        {
            set
            {
                cou_credits = value;
            }
            get
            {
                return cou_credits;
            }
        }
        //        res_total
        public float Res_total
        {
            set
            {
                res_total = value;
            }
            get
            {
                return res_total;
            }
        }

        //              *** Methods ***

        public static async Task<StatusWithObject<List<AllResult>>> getAllResults(int ter_id)
        {
            List<AllResult>  result= new List<AllResult>();
            StatusWithObject<List<AllResult>> returnedValue = new StatusWithObject<List<AllResult>>();
        
            if (await UpdateBox.CheckForInternetConnection())
            {
                returnedValue = await SAL.ResultS.getAllResult(ter_id);
                if (returnedValue.status.status == true)
                {
                    foreach (AllResult x in returnedValue.statusObject)
                    {
                        await DAL.ResultD.saveAllResult(x);
                    }

                }
            }
            result =await DAL.ResultD.getAllResult();
            returnedValue.statusObject = result;
            return returnedValue;
        }

        
   

    }
}
