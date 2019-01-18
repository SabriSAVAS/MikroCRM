using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ProformaOrderModel
{
    public class ProformaOrderBasketListViewModel:ModelEntity
    {
        public string Special { get; set; }
        public string HizmetTip { get; set; }
        public string HizmetAd { get; set; }
        public string HizmetKod { get; set; }
    }
}