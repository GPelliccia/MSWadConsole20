namespace MSWadConsole20.Contract.BusinessModel
{
    public class LibraryModel
    {
        public int Id { get; set; }

        public string? CodiceWAD { get; set; }

        public string? CodiceDimensions { get; set; }

        public string? Descrizione { get; set; }

        public string? Note { get; set; }

        public bool IsOffline { get; set; }

        public DateTime? DataInizioAttivazione { get; set; }

        public DateTime? DataFineAttivazione { get; set; }
    }
}
