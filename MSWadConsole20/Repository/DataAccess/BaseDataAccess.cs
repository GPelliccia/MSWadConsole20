using MSWadConsole20.Repository.Connection;
using System;
using System.Data;

namespace MSWadConsole20.Repository.DataAccess
{
    public abstract class BaseDataAccess : IDisposable
    {
        protected readonly IConnectionFactory _connectionFactory;
        protected IDbConnection? _connection;
        protected IDbTransaction? _transaction;

        public BaseDataAccess(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = _connectionFactory.CreateConnection();
                }
                return _connection;
            }
        }

        protected IDbTransaction Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = Connection.BeginTransaction();
                }
                return _transaction;
            }
        }

        public void Commit()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}