﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.OrderModel
{
    public class OrderListViewModel
    {
        public int KayitNo { get; set; }
        public string EvrakSeri { get; set; }
        public int EvrakNo { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public string Tipi { get; set; }
        public string SiparisCinsi { get; set; }
        public string CariKodu { get; set; }
        public string CariIsmi { get; set; }
        public double Miktar { get; set; }
        public double Tutar { get; set; }
        public double KalanMiktar { get; set; }
        public int SatirSayisi { get; set; }
    }
}