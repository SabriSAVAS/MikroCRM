using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MikroCrm.MikroEntity;

namespace MikroCrm.MikroORM
{
  public  class CariHesaplarORM:OrmBase<CARI_HESAPLAR>
    {
        public bool carihesapvarmı(string carikod)
        {
            CariHesaplarORM cari = new CariHesaplarORM();
            var cariresult = cari.GetList("select * from CARI_HESAPLAR where cari_kod='" + carikod + "'");
            if (cariresult.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
