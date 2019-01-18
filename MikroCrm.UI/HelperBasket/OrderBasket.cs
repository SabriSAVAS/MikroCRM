using MikroCrm.MikroEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.HelperBasket
{
    public class StockItem
    {
        public StockItem()
        {
            Quantity = 1;
        }

        public double BirimFiyat { get; internal set; }
        public int Quantity { get; set; }
        public STOKLAR stoklar { get; set; }
    }

    public class OrderBasket
    {
        public static OrderBasket ActiveOrder
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context.Session["ActiveOrder"] == null)
                    context.Session["ActiveOrder"] = new OrderBasket();
                return (OrderBasket)context.Session["ActiveOrder"];
            }
        }

        private List<StockItem> _stoklar = new List<StockItem>();

        public List<StockItem> _Items { get { return _stoklar; } }

        public void OrderAdd(StockItem item)
        {
            if (_stoklar.Any(x=>x.stoklar.sto_kod==item.stoklar.sto_kod))
            {
                StockItem pro = _stoklar.SingleOrDefault(x => x.stoklar.sto_kod == item.stoklar.sto_kod);
                pro.Quantity = item.Quantity;
            }
            else
            {
                _stoklar.Add(item);
            }
        }
        public void OrderRemove(StockItem Item)
        {
            if (_stoklar.Any(x => x.stoklar.sto_kod == Item.stoklar.sto_kod))
            {
                StockItem pro = _stoklar.SingleOrDefault(x => x.stoklar.sto_kod == Item.stoklar.sto_kod);
                _stoklar.Remove(pro);
            }

        }
    }
}