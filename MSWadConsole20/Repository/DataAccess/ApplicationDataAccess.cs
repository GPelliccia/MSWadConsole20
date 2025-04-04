using Dapper;
using MSWadConsole20.Repository.DataModel.Request;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MSWadConsole20.Repository.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Repository.DataAccess
{
    public class ApplicationDataAccess
    {
        private readonly string _connectionString;

        public ApplicationDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }


        public LibraryData? GetApplication(ApplicationModelRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@ApplicazioneID", request.ApplicationId, DbType.Int32);
            parameters.Add("@CodiceFiscale", request.CodiceFiscaleUtente, DbType.String);
            AddErrorParameters(parameters);

            var responseStored = connection.Execute("[dbo].[sp_ApplicazioniSelect]",
                                                    parameters,
                                                    commandType : CommandType.StoredProcedure
                                                    );

            return connection.QueryFirstOrDefault<LibraryData>(
                "[dbo].[sp_Library_Select]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }




        private void AddErrorParameters(DynamicParameters parameters)
        {
            parameters.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMsg", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);
        }


        private void SetErrorResponse<T>(ApplicationResponse<T> response, DynamicParameters parameters)
        {
            response.ErrorCode = parameters.Get<int>("@ErrorCode");
            response.ErrorMessage = parameters.Get<string>("@ErrorMsg");
        }
    }
}
