namespace BaiTapLon.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class QLTSContext : DbContext
    {
        // Your context has been configured to use a 'QLTSContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BaiTapLon.DTO.QLTSContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLTSContext' 
        // connection string in the application configuration file.
        public QLTSContext()
            : base("name=QLTSContext")
        {
            Database.SetInitializer<QLTSContext>(new DBInit());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<LOAITAISAN> LOAITAISANs { get; set; }
        public virtual DbSet<TAISAN> TAISANs { get; set; }
        public virtual DbSet<CHUNGTUGIAM> CHUNGTUGIAMs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class DBInit : CreateDatabaseIfNotExists<QLTSContext>
    {
        protected override void Seed(QLTSContext context)
        {
            context.PHONGs.Add(new PHONG { MaPhong = "001", TenPhong = "VP Khoa" });
            context.PHONGs.Add(new PHONG { MaPhong = "002", TenPhong = "P.Server" });
            context.PHONGs.Add(new PHONG { MaPhong = "003", TenPhong = "PTN Mang" });
            context.PHONGs.Add(new PHONG { MaPhong = "004", TenPhong = "P. FPT" });
            context.PHONGs.Add(new PHONG { MaPhong = "005", TenPhong = "P. Framgia" });
            context.PHONGs.Add(new PHONG { MaPhong = "006", TenPhong = "C206" });

            context.LOAITAISANs.Add(new LOAITAISAN { MaLoaiTS = "CNTT1", TenLoaiTS = "Vật tư" });
            context.LOAITAISANs.Add(new LOAITAISAN { MaLoaiTS = "CNTT2", TenLoaiTS = "Dụng cụ" });
            context.LOAITAISANs.Add(new LOAITAISAN { MaLoaiTS = "CNTT3", TenLoaiTS = "Máy móc" });

            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-001-1", MaChungTuTang = "1-VPKhoa", MaLoaiTS = "CNTT1", MaPhong = "001", NgayGhiTang = new DateTime(2015, 1, 1), SoLuong = 1, SoLuongCTT = 30, TenTS = "Bàn oval", ThanhTien = 100, ThongSoKyThuat = "Gỗ sồi", TyLeCL = 100, TyLeHM = 0, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 1" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-001-2", MaChungTuTang = "2-VPKhoa", MaLoaiTS = "CNTT1", MaPhong = "001", NgayGhiTang = new DateTime(2013, 3, 22), SoLuong = 10, SoLuongCTT = 10, TenTS = "Ghế xếp", ThanhTien = 250, ThongSoKyThuat = "Nhựa không thể gãy", TyLeCL = 90, TyLeHM = 10, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 2" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-002-3", MaChungTuTang = "1-Server", MaLoaiTS = "CNTT1", MaPhong = "002", NgayGhiTang = new DateTime(2014, 7, 21), SoLuong = 20, SoLuongCTT = 20, TenTS = "Quạt đứng", ThanhTien = 950, ThongSoKyThuat = "Treo tường", TyLeCL = 90, TyLeHM = 10, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 3" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT2-002-4", MaChungTuTang = "2-Server", MaLoaiTS = "CNTT2", MaPhong = "002", NgayGhiTang = new DateTime(2013, 12, 19), SoLuong = 25, SoLuongCTT = 25, TenTS = "Máy chủ", ThanhTien = 3050, ThongSoKyThuat = "Siêu nhanh", TyLeCL = 95, TyLeHM = 5, NoiDung = "Công ty tài trợ", GhiChu = "Ghi chú 4" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT3-003-5", MaChungTuTang = "1-PTN", MaLoaiTS = "CNTT3", MaPhong = "003", NgayGhiTang = new DateTime(2012, 3, 9), SoLuong = 10, SoLuongCTT = 10, TenTS = "Laptop Dell", ThanhTien = 10000, ThongSoKyThuat = "Siêu bền", TyLeCL = 80, TyLeHM = 20, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 5" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-003-6", MaChungTuTang = "2-PTN", MaLoaiTS = "CNTT1", MaPhong = "003", NgayGhiTang = new DateTime(2014, 3, 2), SoLuong = 30, SoLuongCTT = 30, TenTS = "Bàn làm việc", ThanhTien = 300, ThongSoKyThuat = "Gỗ giả", TyLeCL = 70, TyLeHM = 30, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 6" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT3-004-7", MaChungTuTang = "1-FPT", MaLoaiTS = "CNTT3", MaPhong = "004", NgayGhiTang = new DateTime(2009, 2, 4), SoLuong = 50, SoLuongCTT = 2, TenTS = "Máy photocopy", ThanhTien = 950, ThongSoKyThuat = "Toshibaaaaaa", TyLeCL = 100, TyLeHM = 0, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 7" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT3-004-8", MaChungTuTang = "2-FPT", MaLoaiTS = "CNTT3", MaPhong = "004", NgayGhiTang = new DateTime(2010, 1, 12), SoLuong = 40, SoLuongCTT = 40, TenTS = "Máy vi tính IBM", ThanhTien = 7500, ThongSoKyThuat = "Đồ 2nd", TyLeCL = 60, TyLeHM = 40, NoiDung = "Bổ sung vật tư", GhiChu = "Ghi chú 8" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-005-9", MaChungTuTang = "1-Framgia", MaLoaiTS = "CNTT1", MaPhong = "005", NgayGhiTang = new DateTime(2015, 8, 11), SoLuong = 50, SoLuongCTT = 50, TenTS = "Ghế học sinh", ThanhTien = 400, ThongSoKyThuat = "Đẹp", TyLeCL = 100, TyLeHM = 0, NoiDung = "Công ty tài trợ", GhiChu = "Ghi chú 9" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT1-005-10", MaChungTuTang = "2-Framgia", MaLoaiTS = "CNTT1", MaPhong = "005", NgayGhiTang = new DateTime(2015, 10, 17), SoLuong = 45, SoLuongCTT = 45, TenTS = "Bàn làm việc", ThanhTien = 250, ThongSoKyThuat = "2 người ngồi", TyLeCL = 97, TyLeHM = 3, NoiDung = "Công ty tài trợ", GhiChu = "Ghi chú 10" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT3-005-11", MaChungTuTang = "3-Framgia", MaLoaiTS = "CNTT3", MaPhong = "005", NgayGhiTang = new DateTime(2017, 2, 20), SoLuong = 28, SoLuongCTT = 28, TenTS = "Máy vi tính Dell", ThanhTien = 5000, ThongSoKyThuat = "i7-8700, Ram16GB", TyLeCL = 85, TyLeHM = 15, NoiDung = "Công ty tài trợ", GhiChu = "Ghi chú 11" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT3-006-12", MaChungTuTang = "1-C206", MaLoaiTS = "CNTT3", MaPhong = "006", NgayGhiTang = new DateTime(2016, 1, 29), SoLuong = 2, SoLuongCTT = 2, TenTS = "Máy in", ThanhTien = 1300, ThongSoKyThuat = "Thần tốc", TyLeCL = 90, TyLeHM = 10, NoiDung = "Nâng cấp thiết bị", GhiChu = "Ghi chú 12" });
            context.TAISANs.Add(new TAISAN { MaTS = "CNTT2-006-13", MaChungTuTang = "2-C206", MaLoaiTS = "CNTT2", MaPhong = "006", NgayGhiTang = new DateTime(2015, 4, 12), SoLuong = 45, SoLuongCTT = 1, TenTS = "Máy chiếu", ThanhTien = 800, ThongSoKyThuat = "Siêu nét", TyLeCL = 92, TyLeHM = 8, NoiDung = "Phục vụ học sinh", GhiChu = "Ghi chú 13" });

            context.CHUNGTUGIAMs.Add(new CHUNGTUGIAM { MaChungTuGiam = "CTG-01", MaTS = "CNTT1-002-3", NgayGhiGiam = new DateTime(2016, 2, 2), SoLuong = 1, ThanhTien = 20, NoiDung = "Hư hỏng", GhiChu = "Ghi chú giảm 1" });
            context.CHUNGTUGIAMs.Add(new CHUNGTUGIAM { MaChungTuGiam = "CTG-02", MaTS = "CNTT1-001-2", NgayGhiGiam = new DateTime(2016, 5, 12), SoLuong = 5, ThanhTien = 100, NoiDung = "Thay thế", GhiChu = "Ghi chú giảm 2" });

        }
    }

    public class PHONG
    {
        [Key]
        [Required]
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }

        public virtual ICollection<TAISAN> TAISANs { get; set; }
    }

    public class LOAITAISAN
    {
        [Key]
        [Required]
        public string MaLoaiTS { get; set; }
        public string TenLoaiTS { get; set; }

        public virtual ICollection<TAISAN> TAISANs { get; set; }
    }

    public class TAISAN
    {
        [Key]
        [Required]
        public string MaTS { get; set; }
        public string MaLoaiTS { get; set; }
        public string MaPhong { get; set; }
        public string TenTS { get; set; }
        public string MaChungTuTang { get; set; }
        public string ThongSoKyThuat { get; set; }
        public int ThanhTien { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongCTT { get; set; }
        public int TyLeHM { get; set; }
        public int TyLeCL { get; set; }
        public string GhiChu { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayGhiTang { get; set; }

        public string NoiDung { get; set; }


        [ForeignKey("MaPhong")]
        public virtual PHONG PHONG { get; set; }

        [ForeignKey("MaLoaiTS")]
        public virtual LOAITAISAN LOAITAISAN { get; set; }

        public virtual ICollection<CHUNGTUGIAM> CHUNGTUGIAMs { get; set; }
    }


    public class CHUNGTUGIAM
    {
        [Key]
        [Required]
        public string MaChungTuGiam { get; set; }
        public string MaTS { get; set; }

        public int SoLuong { get; set; }
        [Column(TypeName = "Date")]
        public DateTime NgayGhiGiam { get; set; }
        public int ThanhTien { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }

        [ForeignKey("MaTS")]
        public virtual TAISAN TAISAN { get; set; }
    }
}