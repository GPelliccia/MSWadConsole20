using Dapper;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ConfigurationDataAccess
    {
        private readonly string _connectionString;

        public ConfigurationDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<AmbienteData>? GetAmbiente()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<AmbienteData>("EXEC [dbo].[sp_GetAmbiente]").AsList();
        }

        public LibraryData? GetLibrary(LibraryRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);

            return connection.QueryFirstOrDefault<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public List<LibraryData>? GetLibraries(LibraryRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);

            return connection.Query<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();
        }
    }
}
