using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.HelperBasket
{
    public class HizmetItem
    {
        public string Special { get; set; }
        public string HizmetTip { get; set; }
        public string HizmetAd { get; set; }
        public string HizmetKod { get; set; }

    }
    public class HizmetOrderBasket
    {
        public static HizmetOrderBasket ActiveOrder
        {
            get
            {
                HttpContext current = HttpContext.Current;
                if (current.Session["ProformaOrder"] == null)
                    current.Session["ProformaOrder"] = new HizmetOrderBasket();
                return (HizmetOrderBasket)current.Session["ProformaOrder"];
            }
        }

        private List<HizmetItem> _hizmetList = new List<HizmetItem>();

        public List<HizmetItem> items
        {
            get
            {

                return _hizmetList;
            }
        }

        public void OrderAdd(HizmetItem item)
        {
            if (_hizmetList.Any(x => x.HizmetKod == item.HizmetKod)==false)
            {
                _hizmetList.Add(item);
            }
        }
        public void OrderRemove(HizmetItem item)
        {
            if (_hizmetList.Any(x => x.HizmetKod == item.HizmetKod))
            {
                HizmetItem hiz = _hizmetList.FirstOrDefault(x => x.HizmetKod == item.HizmetKod);
                _hizmetList.Remove(hiz);
            }

        }

    }
}