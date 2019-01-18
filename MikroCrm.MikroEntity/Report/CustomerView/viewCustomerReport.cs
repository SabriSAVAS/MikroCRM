using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity.Report.CustomerView
{
   public class viewCustomerReport
    {
        public int Id { get; set; }
        public int EvrakCinsId { get; set; }
        public DateTime Tarih { get; set; }
        public string EvrakSeri { get; set; }
        public int EvrakSira { get; set; }
        public string EvrakTip { get; set; }
        public string EvrakCinsi { get; set; }
        public DateTime VadeTarih { get; set; }
        public double Miktar { get; set; }
        public string BA { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public string KarsiHesapIsmi { get; set; }
    }
}
