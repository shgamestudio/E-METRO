using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class VeBLL
    {
        DAL.VeDAL dalVE;
        public VeBLL()
        {
            dalVE = new DAL.VeDAL();
        }

        public bool InsertVe(DTO.Ve ve)
        {
            return dalVE.InsertVe(ve);
        }

        public DataTable Getdoanhthu()
        {
            return dalVE.Getdoanhthu();
        }

        public DataTable Gettansuattt()
        {
            return dalVE.Gettansuattt();
        }

        public DataTable Getdoanhthu_thang()
        {
            return dalVE.Getdoanhthu_thang();
        }
        public string GetSLVe()
        {
            return dalVE.GetSLVe();
        }
        public DataTable GetBaoCao(int thang, int nam)
        {
            return dalVE.GetBaoCao(thang, nam);
        }
        public string GetTongDoanhSo(int thang, int nam)
        {
            return dalVE.GetTongDoanhSo(thang, nam);
        }
    }
}
