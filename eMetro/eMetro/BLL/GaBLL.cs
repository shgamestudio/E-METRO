using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.BLL
{
    class GaBLL
    {
        DAL.GaDAL dalGA;
        public GaBLL()
        {
            dalGA = new DAL.GaDAL();
        }

        public DataTable getAllGa()
        {
            return dalGA.getAllGa();
        }
        public bool InsertGa(DTO.Ga ga)
        {
            return dalGA.InsertGa(ga);
        }
        public bool UpdateGa(DTO.Ga ga)
        {
            return dalGA.UpdateGa(ga);
        }
        public DataTable FindGa(string ct, string field_search)
        {
            return dalGA.FindGa(ct, field_search);
        }
        public string GetSLGa()
        {
            return dalGA.GetSLGa();
        }
    }
}
