using Dapper;
using System.Data;
using System.Data.SqlClient;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.Connection;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ApplicationDataAccess : BaseDataAccess
    {
        private readonly string _connectionString;

        public ApplicationDataAccess(IConnectionFactory connectionFactory) : base(connectionFactory) { }


        public StoredResponse<WadApplicationData> GetApplication(ApplicationModelRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            AddErrorParameters(parameters);

            var response = new StoredResponse<WadApplicationData>();



            using (var responseStored = Connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
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



            using (var responseStored = Connection.QueryMultiple("[dbo].[sp_ApplicazioniSelect]",
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
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            AddErrorParameters(parameters);

            var response = new StoredResponse<List<ReferenteData>>();



            using (var responseStored = Connection.QueryMultiple("[dbo].[sp_AppRefSelect]",
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
            var response = new StoredResponse<List<ApplicationTipologyData>>();

            var responseStored = Connection.Query<ApplicationTipologyData>("[dbo].[sp_GetTipologieApplicazione]", commandType: CommandType.StoredProcedure).AsList();
            
            response.Data = responseStored;
            return response;
        }

        public StoredResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione()
        {
            var response = new StoredResponse<List<ApplicationVisibilityData>>();

            var responseStored = Connection.Query<ApplicationVisibilityData>("[dbo].[sp_GetVisibilitaApplicazione]", commandType: CommandType.StoredProcedure).AsList();

            response.Data = responseStored;
            return response;
        }


        public StoredResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            AddErrorParameters(parameters);
            var response = new StoredResponse<ApplicationData>();

            using (var responseStored = Connection.QueryMultiple("[dbo].[sp_ApplicazioniSelectReport]",
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
