using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.ViewModel.ProformaOrderModel
{
    public class ProformaOrderViewModel:ModelEntity
    {
        public ProformaOrderViewModel()
        {
            ProformaOrderList = new List<ProformaOrderBasketListViewModel>();
            TekniksyenList = new List<SelectListItem>();
            Tarih = Convert.ToDateTime(DateTime.Now.ToString("yyyy.MM.dd"));
            //TekniksyenList.Add(new SelectListItem { Text = "Sabri", Value = "SS" });
            Aciklama1 = "";
            Aciklama2 = "";
            Aciklama3 = "";
            Aciklama4 = "";
            Aciklama5 = "";
        }
        public string EvrakSeri { get; set; }
        [Required]
        public int EvrakSira { get; set; }
        [Required]
        public string CariKod { get; set; }
        public string CariUnvan { get; set; }
        [Required]
        public string BasSaati { get; set; }
        [Required]
        public string BitSaati { get; set; }
        [Required]
        public string TekniksyenKod { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        [Required]
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string Aciklama4 { get; set; }
        public string Aciklama5 { get; set; }
        public List<SelectListItem> TekniksyenList { get; set; }
        public List<ProformaOrderBasketListViewModel> ProformaOrderList { get; set; }
    }
}