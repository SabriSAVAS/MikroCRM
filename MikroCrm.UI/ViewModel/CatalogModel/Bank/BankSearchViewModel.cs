using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.CatalogModel.Bank
{
    public class BankSearchViewModel
    {
        public BankSearchViewModel()
        {
            BankaKod = "";
            Bankaismi = "";
        }
        public string BankaKod { get; set; }
        public string Bankaismi { get; set; }
        public int? Page { get; set; }
        public IPagedList<BankListViewModel> BankList { get; set; }
    }
}