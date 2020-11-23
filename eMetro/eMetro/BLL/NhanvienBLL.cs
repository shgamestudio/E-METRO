using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class NhanvienBLL
    {
        DAL.NhanvienDAL dalNV;
        public NhanvienBLL()
        {
            dalNV = new DAL.NhanvienDAL();
        }

        public bool Login(string userName, string passWord)
        {
            return dalNV.Login(userName, passWord);
        }
    }
}
