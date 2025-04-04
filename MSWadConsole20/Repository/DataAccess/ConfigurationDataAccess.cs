using Dapper;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel;
using System.Data;
using MSWadConsole20.Repository.DataModel.Data;
using Microsoft.Data.SqlClient;

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
            parameters.Add("@ConDisabilitati", request.FlagDisabilitati, DbType.Boolean);
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
            parameters.Add("@ConDisabilitati", request.FlagDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);

            return connection.Query<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();
        }

        public StoredData<int> InsertLibrary(LibraryRequest request)
        {
            var response = new StoredData<int>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
            parameters.Add("@DataFineAttivazione", request.DataFineAttivazione, DbType.DateTime);
            parameters.Add("@NoteLibreria", request.NoteLibreria, DbType.String);
            parameters.Add("@FlagOffline", request.FlagOffline, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.Int32);
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            var x = connection.Execute(
                "[dbo].[sp_Library_Insert]",
                parameters,
                transaction : transaction,
                commandType: CommandType.StoredProcedure
            );


            response.ErrorCode = parameters.Get<int>("@ErrorCode");
            response.ErrorMessage = parameters.Get<string>("@ErrorMsg");

            if (response.ErrorCode == 0)
            {
                transaction.Commit();
                response.Data = parameters.Get<int>("@LibreriaApplicazioneID");
            }
            else
            {
                transaction.Rollback();
            }

            return response;
        }

        public StoredData UpdateLibrary(LibraryRequest request)
        {
            var response = new StoredData();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
            parameters.Add("@DataFineAttivazione", request.DataFineAttivazione, DbType.DateTime);
            parameters.Add("@NoteLibreria", request.NoteLibreria, DbType.String);
            parameters.Add("@FlagOffline", request.FlagOffline, DbType.Boolean);
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
            try
            {
                var x = connection.Execute(
                    "[dbo].[sp_Library_Update]",
                    parameters,
                    transaction : transaction,
                    commandType: CommandType.StoredProcedure
                );

                response.ErrorCode = parameters.Get<int>("@ErrorCode");
                response.ErrorMessage = parameters.Get<string>("@ErrorMsg");
                if (response.ErrorCode == 0)
                {
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
           
            return response;
        }


        public StoredData DeleteLibrary(LibraryRequest request)
        {
            var response = new StoredData();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
            try
            {
                var x = connection.Execute(
                   "[dbo].[sp_Library_Delete]",
                   parameters,
                   transaction : transaction,
                   commandType: CommandType.StoredProcedure
                );

                response.ErrorCode = parameters.Get<int>("@ErrorCode");
                response.ErrorMessage = parameters.Get<string>("@ErrorMsg");
                if (response.ErrorCode == 0)
                {
                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            
            return response;
        }
    }
}
