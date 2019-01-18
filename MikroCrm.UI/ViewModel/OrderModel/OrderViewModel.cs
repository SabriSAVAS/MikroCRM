using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.OrderModel
{
    public class OrderViewModel:ModelEntity
    {
        public OrderViewModel()
        {
            OrderBasketList = new List<OrderBasketListViewModel>();
            Tarih = DateTime.Now.ToString("yyyy.MM.dd");
        }
        [Required]
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        public string Tarih { get; set; }
        [Required]
        public List<OrderBasketListViewModel> OrderBasketList { get; set; }
    }
}