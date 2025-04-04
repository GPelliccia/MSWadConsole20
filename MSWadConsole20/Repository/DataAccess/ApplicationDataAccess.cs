using Dapper;
using MSWadConsole20.Repository.DataModel.Request;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MSWadConsole20.Repository.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ApplicationDataAccess
    {
        private readonly string _connectionString;

        public ApplicationDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }


        public StoredData<WadApplicationData> GetApplication(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            AddErrorParameters(parameters);

            var response = new StoredData<WadApplicationData>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.ThereIsNotError())
                {
                    response.Data = responseStored.ReadFirstOrDefault<WadApplicationData>() ?? new WadApplicationData();

                    response.Data.ParametroApplicazione = responseStored.Read<ApplicationParameterData>().ToList();

                    response.Data.EventoClientApplicazione = responseStored.Read<ClientEventApplicationData>().ToList();

                    response.Data.TracciamentoApplicazione = responseStored.Read<TrackingApplicationData>().ToList();

                    response.Data.LstRuoli = responseStored.Read<RoleData>().ToList();
                }
            }

            return response;
        }




        public StoredData<List<WadApplicationData>> GetApplications(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneApplicazione", request.DescrizioneApplicazione, DbType.String);
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.Int32);
            AddErrorParameters(parameters);

            var response = new StoredData<List<WadApplicationData>>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.ThereIsNotError())
                {
                    response.Data = responseStored.Read<WadApplicationData>().ToList();
                }
            }

            return response;
        }


        public StoredData<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            AddErrorParameters(parameters);

            var response = new StoredData<List<ReferenteData>>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_AppRefSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.ThereIsNotError())
                {
                    response.Data = responseStored.Read<ReferenteData>().ToList();
                }
            }

            return response;
        }

        public StoredData<List<ApplicationTipologyData>> GetTipologieApplicazione()
        {
            using var connection = new SqlConnection(_connectionString);
            var response = new StoredData<List<ApplicationTipologyData>>();

            var responseStored = connection.Query<ApplicationTipologyData>("[dbo].[sp_GetTipologieApplicazione]", commandType: CommandType.StoredProcedure).AsList();
            
            response.Data = responseStored;
            return response;
        }

        public StoredData<List<ApplicationVisibilityData>> GetVisibilitaApplicazione()
        {
            using var connection = new SqlConnection(_connectionString);
            var response = new StoredData<List<ApplicationVisibilityData>>();

            var responseStored = connection.Query<ApplicationVisibilityData>("[dbo].[sp_GetVisibilitaApplicazione]", commandType: CommandType.StoredProcedure).AsList();

            response.Data = responseStored;
            return response;
        }

        private void AddErrorParameters(DynamicParameters parameters)
        {
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
        }



    }
}
