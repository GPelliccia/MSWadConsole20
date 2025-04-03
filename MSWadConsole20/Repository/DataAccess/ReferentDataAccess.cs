using Dapper;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel;
using System.Data;
using System.Data.SqlClient;
using Azure;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ReferentDataAccess
    {
        private readonly string _connectionString;

        public ReferentDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public StoredData<ReferenteModel>? GetReferent(ReferentRequest request)
        {
            StoredData<ReferenteModel> response = new StoredData<ReferenteModel>();

            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ReferenteID", request.ReferenteId, DbType.Int32);
            parameters.Add("@Cognome", request.Cognome, DbType.String);
            parameters.Add("@Nome", request.Nome, DbType.String);
            parameters.Add("@Tipo", request.Tipo, DbType.String);
            parameters.Add("@Utenza", request.Utenza, DbType.String);
            parameters.Add("@ConDisabilitati", request.ConDisabilitati, DbType.Boolean);
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            var res = connection.QueryFirstOrDefault<ReferenteModel>(
                "[dbo].[sp_ReferentiSelect]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            response.ErrorCode = parameters.Get<int>("@ErrorCode");
            response.ErrorMessage = parameters.Get<string>("@ErrorMsg");

            if (response.ErrorCode == 0)
                response.Data = res;

            return response;
        }
    }
}
