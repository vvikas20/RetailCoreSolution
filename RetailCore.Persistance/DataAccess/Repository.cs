using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Persistance.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected BaseDBContext dataContext;
        protected readonly DbSet<T> dbset;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected BaseDBContext DataContext
        {
            get { return dataContext ?? (dataContext = (BaseDBContext)DatabaseFactory.Get()); }
        }


        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(Guid id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        protected DataTable ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (commandType == CommandType.Text)
            {
                return SqlQuery(sqlQuery, parameters);
            }
            else if (commandType == CommandType.StoredProcedure)
            {
                return StoredProcedure(sqlQuery, parameters);
            }

            return null;
        }
        protected void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (DataContext.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                DataContext.Database.GetDbConnection().Open();
            }

            var command = DataContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            command.ExecuteNonQuery();
        }
        protected ICollection ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (DataContext.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                DataContext.Database.GetDbConnection().Open();
            }

            var command = DataContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (var reader = command.ExecuteReader())
            {
                var mapper = new DataReaderMapper();
                //return mapper.MapToList(reader);
                return new List<string>();
            }
        }

        private DataTable SqlQuery(string sqlQuery, SqlParameter[] parameters = null)
        {

            var dataTable = new DataTable();
            if (DataContext.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                DataContext.Database.GetDbConnection().Open();
            }

            var command = DataContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }

        private DataTable StoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            var dataTable = new DataTable();
            if (DataContext.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                DataContext.Database.GetDbConnection().Open();
            }

            var command = DataContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }
    }
}
