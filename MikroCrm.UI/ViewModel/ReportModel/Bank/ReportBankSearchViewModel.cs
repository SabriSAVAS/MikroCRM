using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.ReportModel.Bank
{
    public class ReportBankSearchViewModel
    {
        public ReportBankSearchViewModel()
        {
            string sdate = DateTime.Now.Year + "-01-01";

            string edate = DateTime.Now.Year + "-12-31";
            string DDate = DateTime.Now.Year-1 + "-12-31";
            startDate = sdate;
            endDate = edate;
            DevirDate = DDate;
            BankaKod = "";

        }
        [Required]
        public string BankaKod { get; set; }
        public string Bankaismi { get; set; }
        [Required]
        public string startDate { get; set; }
        [Required]
        public string endDate { get; set; }
        public string DevirDate { get; set; }
        public int? Page { get; set; }
        public IPagedList<ReportBankListViewModel> ReportBankList { get; set; }
    }
}