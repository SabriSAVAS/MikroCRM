using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ProformaOrderModel.PrintModel
{
    public class PrintListViewModel
    {
        public PrintListViewModel()
        {
            PrintList = new List<PrintModel.PrintList>();
        }
        public string MusteriKod { get; set; }
        public string MusteriAd { get; set; }
        public string Adres { get; set; }
        public string il{ get; set; }
        public string ilce { get; set; }
        public DateTime? Tarih { get; set; }
        public string Saat { get; set; }
        public List<PrintList> PrintList { get; set; }
        public string EvrakNo { get; internal set; }
        public string BasBitSaat { get; internal set; }
    }

    public class PrintList
    {
        public string Id { get; set; }
        public string HizmetTip { get; set; }
        public string HizmetKod { get; set; }
        public string HizmetAd { get; set; }
        public string Aciklama { get; set; }
    }
}