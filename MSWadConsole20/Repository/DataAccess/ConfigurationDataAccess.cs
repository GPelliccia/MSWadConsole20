using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ConfigurationDataAccess : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDataAccess"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ConfigurationDataAccess([NotNull] DbContextOptions options) : base(options) { }

        //private DataTable CreateDataTable(IEnumerable<ParameterData> parameters)
        //{
        //    var dt = new DataTable();
        //    dt.Columns.AddRange([new DataColumn("CHIAVE"), new DataColumn("VALORE")]);
        //    if (parameters != null) { foreach (var param in parameters) { dt.Rows.Add(param.CHIAVE, param.VALORE ?? string.Empty); } }
        //    return dt;
        //}
        public virtual List<AmbienteData>? GetAmbiente()
        {
            var res = Database.SqlQuery<AmbienteData>($"EXEC [dbo].[sp_GetAmbiente]")?.ToList();

            return res;
        }

        public virtual LibraryData? GetLibrary(LibraryRequest request)
        {
            var res = Database.SqlQuery<LibraryData>($"EXEC [dbo].[sp_Library_Select] @LibreriaApplicazioneID, @CodiceDimensions, @CodiceWAD, @DescrizioneLibreria, @ConDisabilitati, @Contesto, @CodiceFiscale")?.FirstOrDefault();

            return res;
        }

        public virtual List<LibraryData>? GetLibraries(LibraryRequest request)
        {
            var response = Database.SqlQuery<LibraryData>($"EXEC [dbo].[sp_Library_Select] @LibreriaApplicazioneID, @CodiceDimensions, @CodiceWAD, @DescrizioneLibreria, @ConDisabilitati, @Contesto, @CodiceFiscale")?.ToList();

            return response;
        }
    }
}
