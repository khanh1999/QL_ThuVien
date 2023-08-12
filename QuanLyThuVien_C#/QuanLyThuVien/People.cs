using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    class People
    {
        private string _ma;
        private string _ten;
        private string _diachi;
        private string _sdt;
        private string _maM;
        private string _maS;
        private DateTime _muon;
        private DateTime _tra;


        public People(string ma, string ten, string diachi, string sdt, string maS, string maM, DateTime muon, DateTime tra)
        {
            _ma = ma;
            _ten = ten;
            _diachi = diachi;
            _sdt = sdt;
            _maM = maM;
            _maS = maS;
            _muon = muon;
            _tra = tra;
            
        }

        public string Ma { get { return _ma; } set { _ma = value; } }
        public string Ten { get { return _ten; } set { _ten = value; } }
        public string Diachi { get { return _diachi; } set { _diachi = value; } }
        public string Sdt { get { return _sdt; } set { _sdt = value; } }
        public string MaM { get { return _maM; } set { _maM = value; } }
        public string MaS { get { return _maS; } set { _maS = value; } }
        public DateTime Muon { get { return _muon; } set { _muon = value; } }
        public DateTime Tra { get { return _tra; } set { _tra = value; } }
        
    }
}
