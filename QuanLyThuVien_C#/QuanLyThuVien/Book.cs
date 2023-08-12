using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    class Book
    {
        private string _ma;
        private string _ten;
        private string _loai;
        private int _num;
        private string _tenTgia;
        private int _gia;

        public Book(string ma, string ten, string loai, int num, string tenTgia, int gia)
        {
            _ma = ma;
            _ten = ten;
            _loai = loai;
            _num = num;
            _tenTgia = tenTgia;
            _gia = gia;
        }

        public string Ma { get { return _ma; } set { _ma = value; } }
        public string Ten { get { return _ten; } set { _ten = value; } }
        public string Loai { get { return _loai; } set { _loai = value; } }
        public int Num { get { return _num; } set { _num = value; } }
        public string TenTgia { get { return _tenTgia; } set { _tenTgia = value; } }
        public int Gia { get { return _gia; } set { _gia = value; } }
    }
}
