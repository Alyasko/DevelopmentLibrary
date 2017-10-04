using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookPages.Contracts.Interfaces.Repositories;
using BookPages.Models;

namespace BookPages.DataAccess.Repositories.MsAccess
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity>
    {
        protected const String TableNameBookSections = "BookSection";
        protected const String TableNameBookPages = "BookPage";
        protected const String TableNameUsers = "[User]";
        protected const String TableNameUserRoles = "UserRole";
        protected const String TableNameTopics = "Topic";
        protected const String TableNameArticles = "Article";

        protected OleDbDataReader DataReader;

        protected MsAccessDbManager MsAccessDbManager;

        protected AbstractRepository()
        {
            DataReader = null;
        }

        protected TValue GetTableValue<TValue>(OleDbDataReader dataReader, int rowNumber)
        {
            return dataReader.IsDBNull(rowNumber) ? default(TValue) : (TValue)dataReader.GetValue(rowNumber);
        }

        protected TValue GetTableValue<TValue>(int rowNumber)
        {
            return GetTableValue<TValue>(DataReader, rowNumber);
        }

        protected String SafeGetStringValue(String inputValue)
        {
            return inputValue ?? "";
        }

        public abstract void Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Delete(int id);

        public abstract IEnumerable<TEntity> GetAll();
    }
}
