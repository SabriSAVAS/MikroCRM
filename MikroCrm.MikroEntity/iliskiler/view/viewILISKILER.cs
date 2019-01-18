using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroEntity.iliskiler.view
{
  public  class viewILISKILER
    {
        public int Id { get; set; }
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public string YetkiliAdSoyad { get; set; }
        public string PersonelKod { get; set; }
        public string PersonelAdSoyad { get; set; }

        public DateTime BasTarih { get; set; }
        public string BasSaat { get; set; }
        public DateTime BitTarih { get; set; }
        public string BitSaat { get; set; }
        public int Sure { get; set; }
        public string Tip { get; set; }
        public string Yer { get; set; }
        public string Konu { get; set; }
        public string Oncelik { get; set; }
    }
}
