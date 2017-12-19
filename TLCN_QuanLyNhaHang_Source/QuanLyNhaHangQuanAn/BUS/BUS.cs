using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUSNV
    {
        //DALNV db = new DALNV();
        DALNV db = null;
        public BUSNV()
        {
            db = new DALNV();
        }


        //bang NhanVien
        public DataTable LayBangNhanVien()
        {
            return db.ExecuteQueryDataSet("select * from NhanVien", CommandType.Text, null);
        }
        public DataTable LayDuLieuTenNhanVien()
        {
            return db.ExecuteQueryDataSet("select MaNV, TenNV from NhanVien", CommandType.Text, null);
        }
        public bool ThemNhanVien(ref string err, string TenNV, DateTime NgaySinh, string DiaChi,
            string GioiTinh, string SDT, int Luong)
        {
            return db.MyExecuteNonQuery("spThemNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@sdt", SDT),
                //new SqlParameter("@NgayVaoLam", NgayVaoLam),
                new SqlParameter("@Luong", Luong));
        }

        public bool SuaNhanVien(ref string err, string MaNV, string TenNV, DateTime NgaySinh, string DiaChi,
            string GioiTinh, string SDT, int Luong)
        {
            return db.MyExecuteNonQuery("spSuaNhanVien",
                CommandType.StoredProcedure, ref err,
                 new SqlParameter("@MaNV", MaNV),
                 new SqlParameter("@TenNV", TenNV),
                 new SqlParameter("@NgaySinh", NgaySinh),
                 new SqlParameter("@DiaChi", DiaChi),
                 new SqlParameter("@GioiTinh", GioiTinh),
                 new SqlParameter("@sdt", SDT),
                //new SqlParameter("@NgayVaoLam", NgayVaoLam),
                 new SqlParameter("@Luong", Luong));

        }
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            return db.MyExecuteNonQuery("spXoaNhanVien",
                CommandType.StoredProcedure, ref err, new SqlParameter("@MaNV", MaNV));
        }

        //bang NguoiDung
        public DataTable LayBangNguoiDung()
        {
            return db.ExecuteQueryDataSet("select nd.TenDangNhap, nd.MatKhau, nv.TenNV from NguoiDung nd, NhanVien nv where nd.MaNV = nv.MaNV", CommandType.Text, null);
        }
        public bool ThemTaiKhoan(ref string err, string TenDN, string MatKhau, string MaNV)
        {
            return db.MyExecuteNonQuery("spThemTaiKhoan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenDangNhap", TenDN),
                new SqlParameter("@MatKhau", MatKhau),

                new SqlParameter("@MaNV", MaNV)
                );
        }
        public DataTable LayDuLieuBangNguoiDung(string username, string pass)
        {
            return db.ExecuteQueryDataSet("select nv.MaNV, nv.TenNV from NguoiDung nd, NhanVien nv where nd.MaNV = nv.MaNV and nd.TenDangNhap = N'" + username + "' and nd.MatKhau = N'" + pass + "'", CommandType.Text, null);
        }

        //bang KhoNguyenLieu
        public DataTable LayBangNguyenLieu()
        {
            return db.ExecuteQueryDataSet("select * from NguyenLieu", CommandType.Text, null);
        }
        public bool ThemNguyenLieu(ref string err, string TenNL, string DonViTinh)
        {
            return db.MyExecuteNonQuery("spThemNguyenLieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenNguyenLieu", TenNL),
                new SqlParameter("@DonViTinh", DonViTinh));
        }
        public bool SuaNguyenLieu(ref string err, string MaNL, string TenNL, string DonViTinh, int SoLuongTon)
        {
            return db.MyExecuteNonQuery("spSuaNguyenLieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNguyenLieu", MaNL),
                new SqlParameter("@TenNguyenLieu", TenNL),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@SoLuongTonKho", SoLuongTon));
        }
        public bool XoaNguyenLieu(ref string err, string MaNL)
        {
            return db.MyExecuteNonQuery("spXoaNguyenLieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNguyenLieu", MaNL));
        }


        //form PhieuNhap
        public DataTable LayDSPhieuNhap()
        {
            return db.ExecuteQueryDataSet("select * from V_PhieuNhapKho", CommandType.Text, null);
        }
        public DataTable LayMaPNK()
        {
            return db.ExecuteQueryDataSet("exec spLayMaPNK", CommandType.Text, null);
        }
        public bool ThemPhieuNhap(ref string err, string TenNV, DateTime NgayLap)
        {
            return db.MyExecuteNonQuery("spThemPhieuNhapKho", CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@NgayNhap", NgayLap));
        }
        public DataTable LayDSPN_Ma(string MaPNK)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayDSPN_Ma('" + MaPNK + "')", CommandType.Text, null);
        }
        public DataTable LayDSPN_NV(string TenNV)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayDSPN_NV(N'" + TenNV + "')", CommandType.Text, null);
        }
        public DataTable LayDSPN_Thang(string thang, string nam)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayDSPN_Thang('" + thang + "','" + nam + "')", CommandType.Text, null);
        }
        public DataTable BaoCaoPN(string tennv, string thang, string nam)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_DSPN_All(N'" + tennv + "','" + thang + "','" + nam + "')", CommandType.Text, null);
        }


        //form CTPN
        public DataTable LayBangCTPN(string MaPNK)
        {
            return db.ExecuteQueryDataSet("exec spLayCTPN " + MaPNK + " ", CommandType.Text, null);
        }
        public bool ThemCTPN(ref string err, string MaPNK, string TenNguyenLieu, int DonGiaNhap, int SoLuongNhap)
        {
            return db.MyExecuteNonQuery("spThemCTPN", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPNK", MaPNK),
                new SqlParameter("@TenNguyenLieu", TenNguyenLieu),
                new SqlParameter("@DonGiaNhap", DonGiaNhap),
                new SqlParameter("@SoLuongNhap", SoLuongNhap));
        }
        public bool SuaCTPN(ref string err, string MaCTPN, string MaPNK, string TenNguyenLieu, int DonGiaNhap, int SoLuongNhap)
        {
            return db.MyExecuteNonQuery("spSuaCTPN", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCTPN", MaCTPN),
                new SqlParameter("@MaPNK", MaPNK),
                new SqlParameter("@TenNguyenLieu", TenNguyenLieu),
                new SqlParameter("@DonGiaNhap", DonGiaNhap),
                new SqlParameter("@SoLuongNhap", SoLuongNhap));
        }
        public bool XoaCTPN(ref string err, string maCTPN, string MaPNK)
        {
            return db.MyExecuteNonQuery("spXoaCTPN", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCTPN", maCTPN),
                new SqlParameter("@MaPNK", MaPNK));
        }


        //Ban
        public DataTable LayDuLieuTable_Ban()
        {
            return db.ExecuteQueryDataSet("select * from Ban", CommandType.Text, null);
        }
        public bool CapNhatMoBan(ref string err, string MaBan)
        {
            return db.MyExecuteNonQuery("spMoBan",
                CommandType.StoredProcedure, ref err,
                 new SqlParameter("@MaBan", MaBan));

        }
        public bool CapNhatHuyBan(ref string err, string MaBan)
        {
            return db.MyExecuteNonQuery("spHuyBan",
                CommandType.StoredProcedure, ref err,
                 new SqlParameter("@MaBan", MaBan));
        }
        public DataTable LayDuLieuBan()
        {
            return db.ExecuteQueryDataSet("select MaBan, KhuVuc from Ban where TrangThai = N'Trống'", CommandType.Text, null);
        }
        public bool ChuyenBan(ref string err, string MaHD, string MaBanChuyenToi)
        {
            return db.MyExecuteNonQuery("spChuyenBan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHoaDon", MaHD),
                new SqlParameter("@MaBan", MaBanChuyenToi));
        }
        public bool CapNhatTrangThaiBan(ref string err, string MaBan, string TrangThaiBan)
        {
            return db.MyExecuteNonQuery("spCapNhatTrangThaiBan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaBan", MaBan),

                new SqlParameter("@TrangThaiBan", TrangThaiBan));
        }
        public DataTable LayDuLieuMaOrder()
        {
            return db.ExecuteQueryDataSet("select top 1 * from PhieuOrder order by MaPhieuOrder desc", CommandType.Text, null);
        }
        //goi mon
        public DataTable LayDuLieu_LoaiMonAn()
        {
            return db.ExecuteQueryDataSet("select * from LoaiMonAn" , CommandType.Text, null);
        }
        public DataTable LayDuLieu_MonAn(int MaLoai)
        {
            //return db.ExecuteQueryDataSet("select MaMon,TenMon,DonViTinh from MonAn", CommandType.Text, null);
            return db.ExecuteQueryDataSet("select MaMon,TenMon,DonViTinh,DonGiaHienTai from MonAn where MaLoai =" + MaLoai, CommandType.Text, null);
        }
        public bool ThemPhieuOrder(ref string err, string MaBan, string MaNV)
        {
            return db.MyExecuteNonQuery("spThemPhieuOrder",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaBan", MaBan),
                new SqlParameter("@MaNhanVien", MaNV));
        }
        public bool ThemHoaDon(ref string err, string MaBan, string MaNV, DateTime Ngay)
        {
            return db.MyExecuteNonQuery("spThemHoaDon",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaBan", MaBan),
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@Ngay", Ngay));
        }
        public DataTable LayDuLieu_MaPhieuOrder_TheoMaBan(string maban)
        {
            return db.ExecuteQueryDataSet("select top 1 o.MaPhieuOrder from Ban b, PhieuOrder o where b.MaBan = o.MaBan and b.TrangThai = N'Đang gọi món' and b.MaBan = N'" + maban + "' order by MaPhieuOrder desc", CommandType.Text, null);
        }
        public bool ThemChiTietPhieuOrder(ref string err, int MaPhieuOrder, int MaMon, int DonGiaHienTai, int SoLuong)
        {
            return db.MyExecuteNonQuery("spThemChiTietPhieuOrder",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPhieuOrder", MaPhieuOrder),
                new SqlParameter("@MaMon", MaMon),
                new SqlParameter("@DonGiaHienTai", DonGiaHienTai),
                new SqlParameter("@SoLuong", SoLuong)
                );
        }
        public DataTable LayDuLieuDanhSachMonGoi(string mactod)
        {
            return db.ExecuteQueryDataSet("select co.MaCTO, ma.TenMon, ma.DonViTinh, ma.DonGiaHienTai, co.SoLuong, ma.DonGiaHienTai*co.SoLuong as ThanhTien from ChiTietOrder co, PhieuOrder po, MonAn ma where co.MaPhieuOrder = po.MaPhieuOrder and ma.MaMon = co.MaMon and po.MaPhieuOrder = N'" + mactod + "'", CommandType.Text, null);
        }
        public bool AddDuLieu_CTO(ref string err, int strMaMon)
        {
            //them order moi ung vs ban do
            //them cto theo ma order do
            return db.MyExecuteNonQuery("spThemCTO",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaMon", strMaMon)
                );
        }

        public DataTable LayDuLieu_MonAnTheoLoai(int MaLoai)
        {
            return db.ExecuteQueryDataSet("spLayDuLieuMonTheoLoai",
                CommandType.StoredProcedure,
                new SqlParameter("@MaLoai", MaLoai));
        }
        //HOADON
        public DataTable LayDuLieu_MaHoaDon_TheoMaBan(string maban)
        {
            return db.ExecuteQueryDataSet("select top 1 hd.MaHD from Ban b, HoaDon hd where b.MaBan = hd.MaBan and b.TrangThai = N'Trống' and b.MaBan = N'" + maban + "' order by MaHD desc", CommandType.Text, null);
        }

        // HoaDon
        public DataTable LayDSHD_Thang(string thang, string nam)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayDSHD_Thang('" + thang + "','" + nam + "')", CommandType.Text, null);
        }
        public DataTable BaoCaoHD_TenNV(string tennv)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayHD_TenNV(N'" + tennv + "')", CommandType.Text, null);
        }
        public DataTable BaoCaoHD_Thang(string thang, string nam)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayHD_Thang('" + thang + "','" + nam + "')", CommandType.Text, null);
        }
        public DataTable BaoCaoHD(string tennv, string thang, string nam)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_LayHD_All(N'" + tennv + "','" + thang + "','" + nam + "')", CommandType.Text, null);
        }

        // ChiTietHoaDon
        public DataTable BaoCaoCTHD(string mahd)
        {
            return db.ExecuteQueryDataSet("select * from dbo.ft_CTHD('" + mahd + "')", CommandType.Text, null);
        }

        //form DoanhThu
        public DataTable LayDSNV_DoanhThu()
        {
            return db.ExecuteQueryDataSet("select * from V_NhanVien", CommandType.Text, null);
        }
    }
    
}
