using ProbeMQTT.Interfaces;
using ProbeMQTT.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProbeMQTT.Database
{
    class ConnectionDatabase
    {
        readonly SQLiteAsyncConnection db;

        public ConnectionDatabase()
        {
            db = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("ConnectionSQLite.db"));
            db.CreateTableAsync<Connection>();
        }

        public SQLiteAsyncConnection ConnectDatabase()
        {
            return db;
        }
    }
}
