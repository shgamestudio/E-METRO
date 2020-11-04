using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class CongtyBLL
    {
        DAL.CongtyDAL dalCT;
        public CongtyBLL()
        {
            dalCT = new DAL.CongtyDAL();
        }

        public DataTable getAllCongty()
        {
            return dalCT.getAllCongty();
        }
        public bool InsertCongty(DTO.Congty ct)
        {
            return dalCT.InsertCongty(ct);
        }
        public bool UpdateCongty(DTO.Congty ct)
        {
            return dalCT.UpdateCongty(ct);
        }
    }
}
