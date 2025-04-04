using System.Runtime.Serialization;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Repository.DataModel
{
    public class ApplicationParameterData : ParameterData
    {
        public int ParametroApplicazioneId { get; set; }
        public int ApplicazioneId { get; set; }
    }
}
