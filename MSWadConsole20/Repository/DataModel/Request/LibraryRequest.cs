namespace MSWadConsole20.Repository.DataModel.Request
{
    public class LibraryRequest
    {
        public int LibreriaApplicazioneID { get; set; }

        public string? CodiceWAD { get; set; }

        public string? CodiceDimensions { get; set; }

        public string? DescrizioneLibreria { get; set; }

        public bool? @ConDisabilitati { get; set; }

        public int? Contesto { get; set; }

        public string? CodiceFiscale { get; set; }

    }
}
