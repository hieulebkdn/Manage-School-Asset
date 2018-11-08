using BaiTapLon.DAL;
using BaiTapLon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.BLL
{
    public class QLTS_BLL
    {
        public QLTS_DAL dal { get; set; }

        public QLTS_BLL()
        {
            dal = new QLTS_DAL();
        }

        public string getTenPhong(string MaPhong)
        {
            return dal.getTenPhong(MaPhong);
        }

        public List<string> GetListPhong()
        {
            return dal.GetListPhong();
        }

        public List<string> GetListMaPhong()
        {
            return dal.GetListMaPhong();
        }


        // HANDLE TABCTG

        public int GetDonGia(string mats)
        {
            return dal.GetDonGia(mats);
        }

        public List<object> GetListCTG(string tenPhong)
        {
            return dal.GetListCTG(tenPhong);
        }

        public List<string> GetThongTinTaiSanCTG(string mctg)
        {
            return dal.GetThongTinTaiSanCTG(mctg);
        }

        public List<object> GetListTaiSan(string tenPhong)
        {
            return dal.GetListTaiSan(tenPhong);
        }

        public List<string> GetThongTinTaiSanTS(string mats)
        {
            return dal.GetThongTinTaiSanTS(mats);
        }

        public List<object> GetListCTT(string tenPhong)
        {
            return dal.GetListCTT(tenPhong);
        }
        public List<TAISAN> GetListTS()
        {
            return dal.GetListTS();
        }
        public List<string> GetThongTinTaiSanCTT(string mats)
        {
            return dal.GetThongTinTaiSanTS(mats);
        }

        public List<string> GetListMaTS()
        {
            return dal.GetListMaTS();
        }
        public int GetMaxSoLuong(string maTS)
        {
            return dal.GetMaxSoLuong(maTS);
        }

        public void AddCTG(CHUNGTUGIAM myCTG)
        {
            dal.AddCTG(myCTG);
        }
        public List<string> GetListMaCTG()
        {
            return dal.GetListMaCTG();
        }

        public List<string> GetThongTinCTG(string MaCTG)
        {
            return dal.GetThongTinCTG(MaCTG);
        }

        public List<CHUNGTUGIAM> GetThongTinCTGbyMaTS(string MaTS)
        {
            return dal.GetThongTinCTGbyMaTS(MaTS);
        }


        public void SuaCTG(CHUNGTUGIAM myCTG, int SoLuongCu)
        {
            dal.SuaCTG(myCTG, SoLuongCu);
        }

        public void XoaCTG(string id)
        {
            dal.XoaCTG(id);
        }


        //********************* FROM HERE WE FUCKING HANDLE TABTAISAN
        public List<string> GetListTenLoaiTS()
        {
            return dal.GetListTenLoaiTS();
        }
        public string GetMaLoaiTS(string tenLoaiTS)
        {
            return dal.GetMaLoaiTS(tenLoaiTS);
        }

        public string GetMaPhong(string tenPhong)
        {
            return dal.GetMaPhong(tenPhong);
        }

        public void AddTS(TAISAN myTS)
        {
            dal.AddTS(myTS);
        }

        public List<string> GetListMaCTT()
        {
            return dal.GetListMaCTT();
        }

        public List<string> GetThongTinTS(string maTS)
        {
            return dal.GetThongTinTS(maTS);
        }

        public void SuaTS(TAISAN newTS)
        {
            dal.SuaTS(newTS);
        }

        public void XoaTS(string id)
        {
            dal.XoaTS(id);
        }

        //** HANDLE CTT
        public List<string> GetThongTinCTT(string MaCTT)
        {
            return dal.GetThongTinCTT(MaCTT);
        }

        public int GetMaxSoLuongCTT(string MaCTT)
        {
            return dal.GetMaxSoLuongCTT(MaCTT);
        }

        public void SuaCTT(TAISAN newTS, int SoLuongCu)
        {
            dal.SuaCTT(newTS, SoLuongCu);
        }

        public void XoaCTT(string id)
        {
            dal.XoaCTT(id);
        }

        //SORT FUNCTION
        public List<object> SortListTaiSan(string tenPhong, string columnName, string querryName)
        {
            return dal.SortListTaiSan(tenPhong, columnName, querryName);
        }

        public List<object> SortListCTG(string tenPhong, string columnName, string querryName)
        {
            return dal.SortListCTG(tenPhong, columnName, querryName);
        }

        public List<object> SortListCTT(string tenPhong, string columnName, string querryName)
        {
            return dal.SortListCTT(tenPhong, columnName, querryName);
        }


        //SEARCH FUNCTION
        public List<object> SearchListTaiSan(string tenPhong, string querryName)
        {
            return dal.SearchListTaiSan(tenPhong, querryName);
        }
        public List<object> SearchListCTG(string tenPhong, string querryName)
        {
            return dal.SearchListCTG(tenPhong, querryName);
        }
        public List<object> SearchListCTT(string tenPhong, string querryName)
        {
            return dal.SearchListCTT(tenPhong, querryName);
        }
        public string getMaTaiSan(string MaLoaiTaiSan, string MaPhong)
        {
            return dal.getMaTaiSan(MaLoaiTaiSan, MaPhong);
        }
    }
}
