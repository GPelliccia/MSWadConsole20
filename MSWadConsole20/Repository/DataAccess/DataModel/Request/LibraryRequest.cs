namespace MSWadConsole20.Repository.DataAccess.DataModel.Request
{
    public class LibraryRequest
    {
        public int LibreriaApplicazioneID { get; set; }

        public string? CodiceWAD { get; set; }

        public string? CodiceDimensions { get; set; }

        public string? DescrizioneLibreria { get; set; }

        public string? NoteLibreria { get; set; }

        public bool? FlagDisabilitati { get; set; }

        public bool? FlagOffline { get; set; }

        public DateTime? DataInizioAttivazione { get; set; }

        public DateTime? DataFineAttivazione { get; set; }

        public int? Contesto { get; set; }

        public string? CodiceFiscale { get; set; }

    }
}
