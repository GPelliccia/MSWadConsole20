using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataAccess.DataModel.Data
{
    public class ApplicationParameterData : ParameterData
    {
        public int ParametroApplicazioneId { get; set; }
        public int ApplicazioneId { get; set; }
    }
}
