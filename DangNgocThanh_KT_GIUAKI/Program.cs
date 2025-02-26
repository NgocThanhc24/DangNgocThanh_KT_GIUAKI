using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangNgocThanh_KT_GIUAKI
{
    class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public GiangVien()
        {

        }
        public GiangVien(string maso, string hoten, int namsinh)
        {
            MaSo = maso;
            HoTen = hoten;
            NamSinh = namsinh;
        }
        public virtual void Nhap()
        {
            Console.WriteLine("Nhập mã số: ");
            MaSo = Console.ReadLine();
            Console.WriteLine("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
        }
        public virtual int TinhLuong()
        {
            return 0;
        }
        public void xuat()
        {
            Console.WriteLine($"MaSo :{MaSo} - HoTen :{HoTen} - NamSinh :{NamSinh} - Luong :{TinhLuong()}");
        }
        class GiangVienCH : GiangVien
        {
            public float HeSoLuong { get; set; }
            public GiangVienCH()
            { }
            public GiangVienCH(string maso, string hoten, int namsinh, float hesoluong) : base(maso, hoten, namsinh)
            {
                HeSoLuong = hesoluong;
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.WriteLine("Nhập vào hệ số lương: ");
                HeSoLuong = float.Parse(Console.ReadLine());
            }
            public override int TinhLuong()
            {
                return (int)(HeSoLuong * 2340000);
            }
        }
        class GiangVienTG : GiangVien
        {
            public int SoTietDay { get; set; }
            public GiangVienTG()
            {
            }
            public GiangVienTG(string maso, string hoten, int namsinh, int sotietday) : base(maso, hoten, namsinh)
            {
                SoTietDay = sotietday;
            }
            public override int TinhLuong()
            {
                return SoTietDay * 120000;
            }
            class QuanLyGV
            {
                public List<GiangVien> DSGV;
                public QuanLyGV()
                {
                    DSGV = new List<GiangVien>();
                }
                public void NhapDS()
                {
                    Console.WriteLine("Nhập số lương giảng viên: ");
                    int SoLuong = int.Parse(Console.ReadLine());
                    for (int i = 0; i < SoLuong; i++)
                    {
                        Console.WriteLine("\n Nhập tin giảng viên thứ{i + 1}: ");
                        Console.WriteLine("Chọn loại giảng viên (1 - hữu cơ, 2 - thỉnh giảng): ");
                        int Loai = int.Parse(Console.ReadLine());
                        GiangVien gv;
                        if (Loai == 1)
                        {
                            gv = new GiangVienCH();
                        }
                        else
                        {
                            gv = new GiangVienTG();
                        }
                        gv.Nhap();
                        DSGV.Add(gv);
                    }
                }
                public void XuatDSGV()
                {
                    Console.WriteLine("Danh sách giảng viên: ");
                    foreach (var gv in DSGV)
                    {
                        gv.xuat();
                    }
                }
                public int TinhTongLuong()
                {
                    int TongLuong = 0;
                    foreach (var gv in DSGV)
                    {
                        TongLuong += gv.TinhLuong();

                    }
                    return TongLuong;
                }

                class Program
                {

                }
            }

            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.Unicode;
                Console.WriteLine(" Nhập thông tin giảng viên cơ hữu: ");
                GiangVienCH gvch = new GiangVienCH();
                gvch.Nhap();
                Console.WriteLine("\n Nhập thông tin giảng viên thỉnh giảng: ");
                GiangVienTG gvtg = new GiangVienTG();
                gvtg.Nhap();
                Console.WriteLine("\n Thông tin giảng viên: ");
                gvch.xuat();
                gvtg.xuat();
                QuanLyGV qlgv = new QuanLyGV();
                int Chon;
                do
                {
                    Console.WriteLine("1. Nhập danh sách giảng viên: ");
                    Console.WriteLine("2. Xuất danh sách giảng viên: ");
                    Console.WriteLine("3. Tính tổng lương giảng viên: ");
                    Console.WriteLine("0. Thoát");
                    Console.WriteLine("Chọn chức năng: ");
                    Chon = int.Parse(Console.ReadLine());
                    switch (Chon)
                    {
                        case 1:
                            qlgv.NhapDS();
                            break;
                        case 2:
                            qlgv.XuatDSGV();
                            break;
                        case 3:
                            Console.WriteLine($"Tổng Lương của giảng viên: {qlgv.TinhTongLuong():No} VND ");
                            break;
                        case 0:
                            Console.WriteLine("Thoát chương trình");
                            break;
                        default:
                            Console.WriteLine("Chọn sai, xin hãy chọn lại!");
                            break;
                    }
                } while (Chon != 0);
            }
        }
    }
}
