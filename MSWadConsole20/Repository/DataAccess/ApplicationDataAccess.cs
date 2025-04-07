﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request.ApplicationModel;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ApplicationDataAccess
    {
        private readonly string _connectionString;

        public ApplicationDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }


        public StoredResponse<WadApplicationData> GetApplication(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            AddErrorParameters(parameters);

            var response = new StoredResponse<WadApplicationData>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.Success)
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




        public StoredResponse<List<WadApplicationData>> GetApplications(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            parameters.Add("@CodiceWAD", request.CodiceWAD, DbType.String);
            parameters.Add("@CodiceDimensions", request.CodiceDimensions, DbType.String);
            parameters.Add("@DescrizioneApplicazione", request.DescrizioneApplicazione, DbType.String);
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Boolean);
            parameters.Add("@Contesto", request.Contesto, DbType.Int32);
            AddErrorParameters(parameters);

            var response = new StoredResponse<List<WadApplicationData>>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.Success)
                {
                    response.Data = responseStored.Read<WadApplicationData>().ToList();
                }
            }

            return response;
        }


        public StoredResponse<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            AddErrorParameters(parameters);

            var response = new StoredResponse<List<ReferenteData>>();



            using (var responseStored = connection.QueryMultiple("[dbo].[sp_AppRefSelect]",
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure
                                                       ))
            {
                response.SetErrorResponse(parameters);
                if (response.Success)
                {
                    response.Data = responseStored.Read<ReferenteData>().ToList();
                }
            }

            return response;
        }

        public StoredResponse<List<ApplicationTipologyData>> GetTipologieApplicazione()
        {
            using var connection = new SqlConnection(_connectionString);
            var response = new StoredResponse<List<ApplicationTipologyData>>();

            var responseStored = connection.Query<ApplicationTipologyData>("[dbo].[sp_GetTipologieApplicazione]", commandType: CommandType.StoredProcedure).AsList();
            
            response.Data = responseStored;
            return response;
        }

        public StoredResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione()
        {
            using var connection = new SqlConnection(_connectionString);
            var response = new StoredResponse<List<ApplicationVisibilityData>>();

            var responseStored = connection.Query<ApplicationVisibilityData>("[dbo].[sp_GetVisibilitaApplicazione]", commandType: CommandType.StoredProcedure).AsList();

            response.Data = responseStored;
            return response;
        }


        public StoredResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            AddErrorParameters(parameters);
            var response = new StoredResponse<ApplicationData>();

            using (var responseStored = connection.QueryMultiple("[dbo].[sp_ApplicazioniSelectReport]",
                                           parameters,
                                           commandType: CommandType.StoredProcedure
                                           ))
            {
                response.SetErrorResponse(parameters);
                if (response.Success)
                {
                    response.Data = responseStored.ReadFirstOrDefault<ApplicationData>() ?? new ApplicationData();

                    response.Data.LstReferenti = responseStored.Read<ReferenteData>().ToList();

                    response.Data.ParametroApplicazione = responseStored.Read<ApplicationParameterData>().ToList();

                    response.Data.EventoClientApplicazione = responseStored.Read<ClientEventApplicationData>().ToList();

                    response.Data.TracciamentoApplicazione = responseStored.Read<TrackingApplicationData>().ToList();
                }
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
