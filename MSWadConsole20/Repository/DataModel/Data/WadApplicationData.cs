﻿using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel.Data
{
    public class WadApplicationData : ApplicationData
    {
        public int? TipologiaId { get; set; }
        public string TipologiaApplicazione { get; set; }
        public int? VisibilitaId { get; set; }
        public string VisibilitaApplicazione { get; set; }
        public RoleData[] LstRuoli { get; set; }
        public string TitoloApplicazione { get; set; }
        public bool FlagGeneraCodWad { get; set; }
    }
}
