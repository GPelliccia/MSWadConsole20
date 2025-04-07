using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.Connection;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ConfigurationDataAccess : BaseDataAccess
    {
        public ConfigurationDataAccess(IConnectionFactory connectionFactory) : base(connectionFactory){}

        public List<AmbienteData>? GetAmbiente()
        {
            return Connection.Query<AmbienteData>("EXEC [dbo].[sp_GetAmbiente]").AsList();
        }

        public LibraryData? GetLibrary(LibraryRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@ConDisabilitati", request.FlagDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);

            return Connection.QueryFirstOrDefault<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public List<LibraryData>? GetLibraries(LibraryRequest request)
        {            
            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@ConDisabilitati", request.FlagDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);

            var data = Connection.Query<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();

            Dispose();
            return data;
        }

        public StoredResponse<int> InsertLibrary(LibraryRequest request)
        {
            var response = new StoredResponse<int>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LibreriaApplicazioneID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
                parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
                parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
                parameters.Add("@DataFineAttivazione", request.DataFineAttivazione, DbType.DateTime);
                parameters.Add("@NoteLibreria", request.NoteLibreria, DbType.String);
                parameters.Add("@FlagOffline", request.FlagOffline, DbType.Boolean);
                parameters.Add("@Contesto", request.Contesto, DbType.Int32);
                AddErrorParameters(parameters);

                var x = Connection.Execute(
                    "[dbo].[sp_Library_Insert]",
                    parameters,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                );

                response.SetErrorResponse(parameters);

                if (response.Success)
                {
                    response.Data = parameters.Get<int>("@LibreriaApplicazioneID");
                    Commit();
                }
                else
                    Rollback();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
            return response;
        }

        public StoredResponse UpdateLibrary(LibraryRequest request)
        {
            var response = new StoredResponse();

            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneLibreria", request.DescrizioneLibreria, DbType.String);
            parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
            parameters.Add("@DataFineAttivazione", request.DataFineAttivazione, DbType.DateTime);
            parameters.Add("@NoteLibreria", request.NoteLibreria, DbType.String);
            parameters.Add("@FlagOffline", request.FlagOffline, DbType.Boolean);
            AddErrorParameters(parameters);

            try
            {
                var x = Connection.Execute(
                    "[dbo].[sp_Library_Update]",
                    parameters,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                );

                response.SetErrorResponse(parameters);
                if (response.Success)
                    Commit();
                else
                    Rollback();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
            
            return response;
        }


        public StoredResponse DeleteLibrary(LibraryRequest request)
        {
            var response = new StoredResponse();

            var parameters = new DynamicParameters();
            parameters.Add("@LibreriaApplicazioneID", request.LibreriaApplicazioneID, DbType.Int32);
            AddErrorParameters(parameters);

            try
            {
                var x = Connection.Execute(
                    "[dbo].[sp_Library_Delete]",
                    parameters,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                );

                response.SetErrorResponse(parameters);
                if (response.Success)
                    Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
            
            return response;
        }
        private void AddErrorParameters(DynamicParameters parameters)
        {
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
        }
    }
}
