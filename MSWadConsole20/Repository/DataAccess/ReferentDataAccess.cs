using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ReferentDataAccess
    {
        private readonly string _connectionString;

        public ReferentDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public StoredResponse<ReferenteData>? GetReferent(ReferentRequest request)
        {
            StoredResponse<ReferenteData> response = new StoredResponse<ReferenteData>();

            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteID", request.ReferenteId, DbType.Int32);           
            AddErrorParameters(parameters);

            var referente = connection.QueryFirstOrDefault<ReferenteData>(
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

            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();            
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Int32);
            AddErrorParameters(parameters);

            var listaReferenti = connection.Query<ReferenteData>(
                "[dbo].[sp_ReferentiSelect]",
                parameters,
                commandType: CommandType.StoredProcedure
            ).AsList();

            response.SetErrorResponse(parameters);
            if (response.Success)
                response.Data = listaReferenti;

            return response;
        }

        public StoredResponse<List<TipiReferenti>>? GetTypeReferents(TipiReferentiRequest request)
        {
            StoredResponse<List<TipiReferenti>> response = new StoredResponse<List<TipiReferenti>>();

            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@TipoReferenteID", request.TipoReferenteID, DbType.Int32);
            parameters.Add("@Nome", request.Nome, DbType.String);
            parameters.Add("@Abbreviazione", request.Abbreviazione, DbType.String);
            AddErrorParameters(parameters);

            var tipiReferenti = connection.Query<TipiReferenti>(
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

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

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

            var x = connection.Execute(
                "[dbo].[sp_ReferentiInsert]",
                parameters,
                transaction: transaction,
                commandType: CommandType.StoredProcedure
            );


            response.SetErrorResponse(parameters);
            if (response.Success)
            {
                transaction.Commit();
                response.Data = parameters.Get<int>("@ReferenteId");
            }
            else
            {
                transaction.Rollback();
            }            

            return response;
        }

        public StoredResponse UpdateReferent(ReferentRequest request)
        {
            var response = new StoredResponse();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

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
                var x = connection.Execute(
                                "[dbo].[sp_ReferentiUpdate]",
                                parameters,
                                transaction : transaction,
                                commandType: CommandType.StoredProcedure
                );

                response.SetErrorResponse(parameters);
                if (response.Success)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
  
            return response;
        }

        public StoredResponse ChiudiReferente(ReferentRequest request)
        {
            var response = new StoredResponse();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction(); // Inizio transazione

            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteID", request.ReferenteId, DbType.Int32);
            AddErrorParameters(parameters);
            try
            {
                var x = connection.Execute(
                   "[dbo].[sp_ReferenteDelete]",
                   parameters,
                   transaction: transaction,
                   commandType: CommandType.StoredProcedure
                );

                response.SetErrorResponse(parameters);
                if (response.Success)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
