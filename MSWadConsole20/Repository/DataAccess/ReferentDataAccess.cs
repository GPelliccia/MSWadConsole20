using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.Connection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ReferentDataAccess : BaseDataAccess
    {

        public ReferentDataAccess(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        public StoredResponse<ReferenteData>? GetReferent(ReferentRequest request)
        {
            StoredResponse<ReferenteData> response = new StoredResponse<ReferenteData>();

            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteID", request.ReferenteId, DbType.Int32);           
            AddErrorParameters(parameters);

            var referente = Connection.QueryFirstOrDefault<ReferenteData>(
                "[dbo].[sp_ReferentiSelect]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            response.SetErrorResponse(parameters);
            if (response.Success)
                response.Data = referente;

            return response;
        }

        public StoredResponse<List<ReferenteData>>? GetReferents(ReferentRequest request)
        {
            StoredResponse<List<ReferenteData>> response = new StoredResponse<List<ReferenteData>>();

            var parameters = new DynamicParameters();            
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Int32);
            AddErrorParameters(parameters);

            var listaReferenti = Connection.Query<ReferenteData>(
                "[dbo].[sp_ReferentiSelect]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();

            response.SetErrorResponse(parameters);
            if (response.Success)
                response.Data = listaReferenti;

            return response;
        }

        public StoredResponse<List<TipoReferenteData>>? GetTypeReferents(TipiReferentiRequest request)
        {
            StoredResponse<List<TipoReferenteData>> response = new StoredResponse<List<TipoReferenteData>>();

            var parameters = new DynamicParameters();
            parameters.Add("@TipoReferenteID", request.TipoReferenteID, DbType.Int32);
            parameters.Add("@Nome", request.Nome, DbType.String);
            parameters.Add("@Abbreviazione", request.Abbreviazione, DbType.String);
            AddErrorParameters(parameters);

            var tipiReferenti = Connection.Query<TipoReferenteData>(
                "[dbo].[sp_ReferentTypeSelect]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();

            response.SetErrorResponse(parameters);
            if (response.Success)
                response.Data = tipiReferenti;

            return response;
        }

        public StoredResponse<int> InsertReferent(ReferentRequest request)
        {
            var response = new StoredResponse<int>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReferenteId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Cognome", request.Cognome, DbType.String);
                parameters.Add("@Nome", request.Nome, DbType.String);
                parameters.Add("@Matricola", request.Matricola, DbType.String);
                parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);
                parameters.Add("@Email", request.Email, DbType.String);
                parameters.Add("@Telefono", request.Telefono, DbType.String);
                parameters.Add("@Tipo", request.Tipo, DbType.String);
                parameters.Add("@Utenza", request.Utenza, DbType.String);
                parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
                AddErrorParameters(parameters);

                var x = Connection.Execute(
                    "[dbo].[sp_ReferentiInsert]",
                    parameters,
                    transaction: Transaction,
                    commandType: CommandType.StoredProcedure
                );


                response.SetErrorResponse(parameters);
                if (response.Success)
                {
                    response.Data = parameters.Get<int>("@ReferenteId");
                    Commit();
                }
                else
                {
                    Rollback();
                }
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

        public StoredResponse UpdateReferent(ReferentRequest request)
        {
            var response = new StoredResponse();
            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteId",request.ReferenteId, DbType.Int32);
            parameters.Add("@Cognome", request.Cognome, DbType.String);
            parameters.Add("@Nome", request.Nome, DbType.String);
            parameters.Add("@Matricola", request.Matricola, DbType.String);
            parameters.Add("@CodiceFiscale", request.CodiceFiscale, DbType.String);
            parameters.Add("@Email", request.Email, DbType.String);
            parameters.Add("@Telefono", request.Telefono, DbType.String);
            parameters.Add("@Tipo", request.Tipo, DbType.String);
            parameters.Add("@Utenza", request.Utenza, DbType.String);
            parameters.Add("@DataInizioAttivazione", request.DataInizioAttivazione, DbType.DateTime);
            AddErrorParameters(parameters);
            try
            {
                var x = Connection.Execute(
                    "[dbo].[sp_ReferentiUpdate]",
                    parameters,
                    transaction : Transaction,
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

        public StoredResponse ChiudiReferente(ReferentRequest request)
        {
            var response = new StoredResponse();
            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteID", request.ReferenteId, DbType.Int32);
            AddErrorParameters(parameters);
            try
            {
                var x = Connection.Execute(
                   "[dbo].[sp_ReferenteDelete]",
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
        private void AddErrorParameters(DynamicParameters parameters)
        {
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
        }
    }
}
