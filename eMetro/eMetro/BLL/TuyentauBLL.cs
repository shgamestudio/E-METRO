using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class TuyentauBLL
    {
        DAL.TuyentauDAL dalTT;
        public TuyentauBLL()
        {
            dalTT = new DAL.TuyentauDAL();
        }

        public string Search_TengabyMAGA(string str)
        {
            return dalTT.Search_TengabyMAGA(str);
        }
    }
}
