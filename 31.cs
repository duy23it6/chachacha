using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class Program
{
    static List<SinhVien> danhSachSinhVien = new List<SinhVien>();
    static int soLuongSinhVien;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Bài tập quản lý điểm học tập của sinh viên");

        NhapSoLuongSinhVien();
        NhapThongTinSinhVien();
        HienThiThongTinSinhVien();
        HienThiSinhVienDiemTrungBinhCaoNhat();
        DemSoSinhVienDiemTrungBinhLon5();
        SapXepDanhSachTheoDiemTrungBinh();
        SapXepDanhSachTheoHoTen();
        GhiThongTinSinhVienVaoFile();
        DocThongTinSinhVienTuFile();
    }

    static void NhapSoLuongSinhVien()
    {
        try
        {
            Console.Write("Nhập số lượng sinh viên: ");
            soLuongSinhVien = int.Parse(Console.ReadLine());
            if (soLuongSinhVien <= 0)
            {
                throw new Exception("Số lượng sinh viên phải lớn hơn 0.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void NhapThongTinSinhVien()
    {
        try
        {
            for (int i = 0; i < soLuongSinhVien; i++)
            {
                SinhVien sv = new SinhVien();
                Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");
                Console.Write("Mã số sinh viên: ");
                sv.MSSV = Console.ReadLine();
                Console.Write("Họ và tên: ");
                sv.HoTen = Console.ReadLine();
                Console.Write("Điểm Toán: ");
                sv.DiemToan = double.Parse(Console.ReadLine());
                Console.Write("Điểm Lý: ");
                sv.DiemLy = double.Parse(Console.ReadLine());
                Console.Write("Điểm Hóa: ");
                sv.DiemHoa = double.Parse(Console.ReadLine());
                danhSachSinhVien.Add(sv);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void HienThiThongTinSinhVien()
    {
        try
        {
            foreach (var sv in danhSachSinhVien)
            {
                Console.WriteLine($"Mã số sinh viên: {sv.MSSV}, Họ và tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void HienThiSinhVienDiemTrungBinhCaoNhat()
    {
        try
        {
            bool found = false;
            foreach (var sv in danhSachSinhVien)
            {
                if (sv.DiemTrungBinh > 9.5)
                {
                    Console.WriteLine($"Sinh viên đầu tiên có điểm trung bình trên 9.5 là: Mã số: {sv.MSSV}, Họ và tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Không có sinh viên nào có điểm trung bình trên 9.5.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void DemSoSinhVienDiemTrungBinhLon5()
    {
        try
        {
            int count = 0;
            foreach (var sv in danhSachSinhVien)
            {
                if (sv.DiemTrungBinh > 5.0)
                {
                    count++;
                }
            }
            Console.WriteLine($"Có {count} sinh viên có điểm trung bình lớn hơn 5.0.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void SapXepDanhSachTheoDiemTrungBinh()
    {
        try
        {
            danhSachSinhVien.Sort((a, b) => a.DiemTrungBinh.CompareTo(b.DiemTrungBinh));
            Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo điểm trung bình từ thấp đến cao:");
            HienThiThongTinSinhVien();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void SapXepDanhSachTheoHoTen()
    {
        try
        {
            danhSachSinhVien.Sort((a, b) => a.HoTen.CompareTo(b.HoTen));
            Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo họ tên theo thứ tự alphabet:");
            HienThiThongTinSinhVien();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void GhiThongTinSinhVienVaoFile()
    {
        try
        {
            Console.Write("Nhập tên file để ghi thông tin sinh viên: ");
            string fileName = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var sv in danhSachSinhVien)
                {
                    writer.WriteLine($"{sv.MSSV},{sv.HoTen},{sv.DiemToan},{sv.DiemLy},{sv.DiemHoa},{sv.DiemTrungBinh}");
                }
            }
            Console.WriteLine("Ghi thông tin sinh viên vào file thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    static void DocThongTinSinhVienTuFile()
    {
        try
        {
            Console.Write("Nhập tên file để đọc thông tin sinh viên: ");
            string fileName = Console.ReadLine();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    SinhVien sv = new SinhVien
                    {
                        MSSV = parts[0],
                        HoTen = parts[1],
                        DiemToan = double.Parse(parts[2]),
                        DiemLy = double.Parse(parts[3]),
                        DiemHoa = double.Parse(parts[4])
                    };
                    danhSachSinhVien.Add(sv);
                }
            }
            Console.WriteLine("Đọc thông tin sinh viên từ file thành công.");
            HienThiThongTinSinhVien();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }
}
