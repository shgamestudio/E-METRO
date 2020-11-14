using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class CTTuyentauBLL
    {
        DAL.CTTuyentauDAL dalCTTT;
        public CTTuyentauBLL()
        {
            dalCTTT = new DAL.CTTuyentauDAL();
        }

        public DataTable getAllCTTuyentau(string matt)
        {
            return dalCTTT.getAllCTTuyentau(matt);
        }

        public bool Edit_CTTT(DTO.CTTuyentau cttt)
        {
            return dalCTTT.Edit_CTTT(cttt);
        }
        public bool Delete_CTTT(string cttt)
        {
            return dalCTTT.Delete_CTTT(cttt);
        }
    }
}
