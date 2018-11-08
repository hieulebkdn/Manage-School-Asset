using BaiTapLon.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.DAL
{
    public class QLTS_DAL
    {
        public QLTSContext db { get; set; }

        public QLTS_DAL()
        {
            db = new QLTSContext();
        }

        public List<string> GetListPhong()
        {
            var s = db.PHONGs.Select(p => new { p.TenPhong, p.MaPhong }).Distinct().OrderBy(p => p.MaPhong);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenPhong);
            }
            list.Add("Tất cả");
            return list;
        }

        public string getTenPhong(string MaPhong)
        {
            PHONG ph = db.PHONGs.Where(p => p.MaPhong.Equals(MaPhong)).Select(p => p).Single();
            return ph.TenPhong;
        }

        public List<string> GetListMaPhong()
        {
            var s = db.PHONGs.Select(p => new { p.TenPhong, p.MaPhong }).Distinct().OrderBy(p => p.MaPhong);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.MaPhong);
            }
            list.Add("Tất cả");
            return list;
        }

        public List<string> GetListMaCTT()
        {
            var s = db.TAISANs.Distinct().OrderBy(p => p.MaTS).Select(p => p.MaChungTuTang);
            return s.ToList<string>();
        }

        // tab taisan
        public List<object> GetListTaiSan(string tenPhong)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => p.MaPhong.Contains(maPhong)).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL });
            return s.ToList<object>();
        }

        //tab ctt
        public List<object> GetListCTT(string tenPhong)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => p.MaPhong.Contains(maPhong)).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung });

            return s.ToList<object>();
        }

        // tab ctg
        public List<object> GetListCTG(string tenPhong)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => p.MaPhong.Contains(maPhong)).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu });
            return s.ToList<object>();
        }

        public List<string> GetThongTinTaiSanTS(string mats)
        {
            var s = db.TAISANs.Select(p => new { p.MaTS, p.TenTS, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.ThanhTien, p.TyLeHM, p.TyLeCL }).Where(p => p.MaTS == mats);

            List<string> data = new List<string>();
            data.Add(s.First().MaTS);
            data.Add(s.First().TenTS);
            data.Add(s.First().TenLoaiTS);
            data.Add(s.First().ThongSoKyThuat);
            data.Add(s.First().ThanhTien.ToString());
            data.Add(s.First().TyLeHM.ToString());
            data.Add(s.First().TyLeCL.ToString());
            return data;
        }

        public List<TAISAN> GetListTS()
        {
            List<TAISAN> li = db.TAISANs.Select(p => p).ToList<TAISAN>();
            return li;
        }

        public List<string> GetThongTinTaiSanCTG(string mctg)
        {
            string id = db.CHUNGTUGIAMs.Where(p => p.MaChungTuGiam.Equals(mctg)).Select(p => p.MaTS).First();
            var s = db.TAISANs.Select(p => new { p.MaTS, p.TenTS, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.ThanhTien, p.TyLeHM, p.TyLeCL }).Where(p => p.MaTS == id);

            List<string> data = new List<string>();
            data.Add(s.First().MaTS);
            data.Add(s.First().TenTS);
            data.Add(s.First().TenLoaiTS);
            data.Add(s.First().ThongSoKyThuat);
            data.Add(s.First().ThanhTien.ToString());
            data.Add(s.First().TyLeHM.ToString());
            data.Add(s.First().TyLeCL.ToString());
            return data;
        }

        //Form2 AddCTG

        public int GetDonGia(string mats)
        {
            var s = db.TAISANs.Where(p => p.MaTS == mats).Select(p => new { p.SoLuong, p.ThanhTien }).Single();
            if (s.SoLuong == 0) return 0;
            else
                return s.ThanhTien / s.SoLuong;
            //Neu da ghi giam tat ca (so luong bang 0) thi bi loi divide by zero
            //Fixed
        }

        public List<string> GetListMaTS()
        {
            var s = db.TAISANs.Select(p => new { p.MaTS }).OrderBy(p => p.MaTS);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.MaTS);
            }
            return list;
        }

        public int GetMaxSoLuong(string maTS)
        {
            return db.TAISANs.Where(p => p.MaTS == maTS).Select(p => new { p.SoLuong }).First().SoLuong;
        }

        public void AddCTG(CHUNGTUGIAM myCTG)
        {
            db.CHUNGTUGIAMs.Add(myCTG);
            var s = db.TAISANs.Single(p => p.MaTS == myCTG.MaTS);
            TAISAN myTS = s;
            myTS.SoLuong = myTS.SoLuong - myCTG.SoLuong;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }

        //Form Sua CTG
        public List<string> GetListMaCTG()
        {
            var s = db.CHUNGTUGIAMs.Select(p => p.MaChungTuGiam);
            return s.ToList<string>();
        }

        public List<string> GetThongTinCTG(string MaCTG)
        {
            var s = db.CHUNGTUGIAMs.Where(p => p.MaChungTuGiam == MaCTG).Select(p => new { p.MaTS, p.SoLuong, p.NgayGhiGiam, p.NoiDung, p.GhiChu, p.ThanhTien });
            List<string> data = new List<string>();
            data.Add(s.First().MaTS);
            data.Add(s.First().SoLuong.ToString());
            data.Add(s.First().NgayGhiGiam.ToShortDateString());
            data.Add(s.First().NoiDung);
            data.Add(s.First().GhiChu);
            data.Add(s.First().ThanhTien.ToString());
            return data;
        }

        public List<CHUNGTUGIAM> GetThongTinCTGbyMaTS(string MaTS)
        {
            List<CHUNGTUGIAM> s = db.CHUNGTUGIAMs.Where(p => p.MaTS.Equals(MaTS)).Select(p => p).ToList<CHUNGTUGIAM>();

            return s;
        }

        public void SuaCTG(CHUNGTUGIAM newCTG, int SoLuongCu)
        {
            var s = db.CHUNGTUGIAMs.Single(p => p.MaChungTuGiam == newCTG.MaChungTuGiam);
            CHUNGTUGIAM myCTG = s;
            myCTG.SoLuong = newCTG.SoLuong;
            myCTG.NgayGhiGiam = newCTG.NgayGhiGiam;
            myCTG.NoiDung = newCTG.NoiDung;
            myCTG.GhiChu = newCTG.GhiChu;
            myCTG.ThanhTien = newCTG.ThanhTien;

            var x = db.TAISANs.Single(p => p.MaTS == newCTG.MaTS);
            TAISAN myTS = x;
            myTS.SoLuong = myTS.SoLuong + SoLuongCu - myCTG.SoLuong;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }

        // Chuc nang delete chung tu giam
        public void XoaCTG(string id)
        {
            var s = db.CHUNGTUGIAMs.Single(p => p.MaChungTuGiam == id);
            int SoLuong = s.SoLuong;
            var x = db.TAISANs.Single(p => p.MaTS == s.MaTS);
            x.SoLuong += SoLuong;
            CHUNGTUGIAM myCTG = s;
            db.CHUNGTUGIAMs.Remove(myCTG);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }

        }

        //********************* FROM HERE WE FUCKING HANDLE TABTAISAN

        public List<string> GetListTenLoaiTS()
        {
            var s = db.LOAITAISANs.Select(p => new { p.TenLoaiTS, p.MaLoaiTS }).Distinct().OrderBy(p => p.MaLoaiTS);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenLoaiTS);
            }
            return list;
        }

        public string GetMaPhong(string tenPhong)
        {
            return db.PHONGs.Where(p => p.TenPhong.Equals(tenPhong)).Select(p => p.MaPhong).Single();
        }

        public string GetMaLoaiTS(string tenLoaiTS)
        {
            return db.LOAITAISANs.Where(p => p.TenLoaiTS.Equals(tenLoaiTS)).Select(p => p.MaLoaiTS).Single();
        }

        public void AddTS(TAISAN myTS)
        {
            db.TAISANs.Add(myTS);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }

        public List<string> GetThongTinTS(string MaTS)
        {
            var s = db.TAISANs.Where(p => p.MaTS == MaTS).Select(p => new { p.MaTS, p.MaChungTuTang, p.TenTS, p.LOAITAISAN.TenLoaiTS, p.PHONG.TenPhong, p.ThongSoKyThuat, p.TyLeHM, p.TyLeCL, p.GhiChu });
            List<string> data = new List<string>();
            data.Add(s.First().MaChungTuTang);
            data.Add(s.First().TenLoaiTS);
            data.Add(s.First().TenPhong);
            data.Add(s.First().TenTS);
            data.Add(s.First().GhiChu);
            data.Add(s.First().ThongSoKyThuat);
            data.Add(s.First().TyLeHM.ToString());
            data.Add(s.First().TyLeCL.ToString());
            return data;
        }

        public void SuaTS(TAISAN newTS)
        {
            var s = db.TAISANs.Single(p => p.MaTS == newTS.MaTS);
            TAISAN myTS = s;
            myTS.MaLoaiTS = newTS.MaLoaiTS;
            myTS.MaPhong = newTS.MaPhong;
            myTS.ThongSoKyThuat = newTS.ThongSoKyThuat;
            myTS.SoLuong = newTS.SoLuong;
            myTS.GhiChu = newTS.GhiChu;
            myTS.TenTS = newTS.TenTS;
            myTS.TyLeHM = newTS.TyLeHM;
            myTS.TyLeCL = newTS.TyLeCL;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }
        public void XoaTS(string id)
        {
            var s = db.TAISANs.Single(p => p.MaTS == id);
            TAISAN myTS = s;
            db.TAISANs.Remove(myTS);
            var ha = db.CHUNGTUGIAMs.Where(p => p.MaTS == id);
            foreach (CHUNGTUGIAM ob in ha)
            {
                db.CHUNGTUGIAMs.Remove(ob);
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }


        //******** FORM SUA CTT
        public List<string> GetThongTinCTT(string MaCTT)
        {
            var s = db.TAISANs.Where(p => p.MaChungTuTang == MaCTT).Select(p => new { p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung });
            List<string> data = new List<string>();
            data.Add(s.First().MaTS);
            data.Add(s.First().TenTS);
            data.Add(s.First().NgayGhiTang.ToShortDateString());
            data.Add(s.First().SoLuongCTT.ToString());
            data.Add(s.First().ThanhTien.ToString());
            data.Add(s.First().NoiDung);
            return data;
        }

        public int GetMaxSoLuongCTT(string MaCTT)
        {
            return db.TAISANs.Where(p => p.MaChungTuTang == MaCTT).Select(p => new { p.SoLuongCTT }).First().SoLuongCTT;
        }

        public void SuaCTT(TAISAN newTS, int SoLuongCu)
        {
            var s = db.TAISANs.Single(p => p.MaChungTuTang == newTS.MaChungTuTang);
            TAISAN myTS = s;
            myTS.NgayGhiTang = newTS.NgayGhiTang;
            myTS.SoLuongCTT = newTS.SoLuongCTT;
            myTS.ThanhTien = newTS.ThanhTien;
            myTS.NoiDung = newTS.NoiDung;
            myTS.SoLuong = myTS.SoLuong + newTS.SoLuongCTT - SoLuongCu;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }

        public void XoaCTT(string id)
        {
            var s = db.TAISANs.Single(p => p.MaChungTuTang == id);
            TAISAN myTS = s;
            db.TAISANs.Remove(myTS);
            var ha = db.CHUNGTUGIAMs.Where(p => p.MaTS == id);
            foreach (CHUNGTUGIAM ob in ha)
            {
                db.CHUNGTUGIAMs.Remove(ob);
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
            }
        }


        //SORT FUNCTION CHO LIST TAI SAN

        public List<object> SortListTaiSan(string tenPhong, string columnName, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            if (columnName == "Loại tài sản")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL }).OrderBy(p => p.TenLoaiTS);
                return s.ToList<object>();
            }
            else if (columnName == "Số lượng")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL }).OrderBy(p => p.SoLuong);
                return s.ToList<object>();
            }
            else if (columnName == "Tỷ lệ hao mòn")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL }).OrderBy(p => p.TyLeHM);
                return s.ToList<object>();
            }
            else if (columnName == "Tỷ lệ còn lại")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL }).OrderBy(p => p.TyLeCL);
                return s.ToList<object>();
            }
            else
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL }).OrderBy(p => p.TenTS);
                return s.ToList<object>();
            }

        }

        //SORT FUNCTION CHO LIST CTG

        public List<object> SortListCTG(string tenPhong, string columnName, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }
            if (columnName == "Mã chứng từ")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu }).OrderBy(k => k.MaChungTuGiam);
                return s.ToList<object>();
            }
            else if (columnName == "Ngày ghi giảm")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu }).OrderBy(k => k.NgayGhiGiam);
                return s.ToList<object>();
            }
            else if (columnName == "Số lượng")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu }).OrderBy(k => k.SoLuong);
                return s.ToList<object>();
            }
            else if (columnName == "Thành tiền")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu }).OrderBy(k => k.ThanhTien);
                return s.ToList<object>();
            }
            else
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu }).OrderBy(k => k.TenTS);
                return s.ToList<object>();
            }

        }

        //SORT FUNCTION CHO LIST CTG
        public List<object> SortListCTT(string tenPhong, string columnName, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }
            if (columnName == "Mã chứng từ")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung }).OrderBy(p => p.MaChungTuTang);
                return s.ToList<object>();
            }
            else if (columnName == "Ngày ghi tăng")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung }).OrderBy(p => p.NgayGhiTang);
                return s.ToList<object>();
            }
            else if (columnName == "Số lượng CTT")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung }).OrderBy(p => p.SoLuongCTT);
                return s.ToList<object>();
            }
            else if (columnName == "Thành tiền")
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung }).OrderBy(p => p.ThanhTien);
                return s.ToList<object>();
            }
            else
            {
                var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung }).OrderBy(p => p.TenTS);
                return s.ToList<object>();
            }

        }


        //Search FUNCTION CHO LIST TS
        // Search theo tên TS
        public List<object> SearchListTaiSan(string tenPhong, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaTS, p.TenTS, p.SoLuong, p.LOAITAISAN.TenLoaiTS, p.ThongSoKyThuat, p.GhiChu, p.TyLeHM, p.TyLeCL });
            return s.ToList<object>();
        }

        //Search FUNCTION CHO LIST CTT
        public List<object> SearchListCTT(string tenPhong, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Select(p => new { p.MaChungTuTang, p.MaTS, p.TenTS, p.NgayGhiTang, p.SoLuongCTT, p.ThanhTien, p.NoiDung });

            return s.ToList<object>();
        }

        //Search FUNCTION CHO LIST CTG
        public List<object> SearchListCTG(string tenPhong, string querryName)
        {
            string maPhong;
            if (tenPhong == "Tất cả")
            {
                maPhong = "";
            }
            else
            {
                var x = db.PHONGs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenPhong);
                maPhong = x.First().MaPhong;
            }

            var s = db.TAISANs.Where(p => (p.MaPhong.Contains(maPhong) && p.TenTS.Contains(querryName))).Join(db.CHUNGTUGIAMs, p => p.MaTS, k => k.MaTS, (p, k) => new { k.MaChungTuGiam, p.TenTS, k.NgayGhiGiam, k.SoLuong, k.NoiDung, k.ThanhTien, k.GhiChu });
            return s.ToList<object>();
        }


        public string getMaTaiSan(string MaLoaiTaiSan, string MaPhong)
        {
            int maxx = 0;
            List<string> li = this.GetListMaTS();
            foreach (string s in li)
            {
                string[] lii = s.Split('-');
                maxx = Math.Max(maxx, int.Parse(lii[2]));
            }
            string ret = "";
            ret += MaLoaiTaiSan + "-" + MaPhong + "-" + (maxx + 1).ToString();

            return ret;
        }
    }
}
