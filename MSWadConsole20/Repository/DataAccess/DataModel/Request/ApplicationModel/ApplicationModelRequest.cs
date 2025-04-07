namespace MSWadConsole20.Repository.DataAccess.DataModel.Request.ApplicationModel
{
    public class ApplicationModelRequest
    {
        public int ApplicationId { get; set; }
        public string CodiceFiscaleUtente { get; set; }
        public string CodiceWAD { get; set; }
        public string CodiceDimensions { get; set; }
        public string DescrizioneApplicazione { get; set; }
        public int Contesto { get; set; }
        public bool ConDisabilitati { get; set; }
    }
}
