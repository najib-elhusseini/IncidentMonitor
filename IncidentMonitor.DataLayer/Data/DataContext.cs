using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentMonitor.Models;
using SQLite;

namespace IncidentMonitor.DataLayer.Data
{
    public class DataContext
    {
        const string _databaseName = "event_monitor.db";
        readonly string? _databaseFolderPath;
        readonly string? _databasePath;

        public SQLiteConnectionString DbConnectionString { get; private set; }
        public SQLiteAsyncConnection Connection { get; private set; }

        /// <summary>
        /// Creates a new ApplicationDbContext instance that uses Sqlite as a lightweight store. 
        /// </summary>
        /// <param name="dbFolderPath">The database folder path</param>
        public DataContext(string dbFolderPath)
        {
            _databaseFolderPath = dbFolderPath;
            _databasePath = Path.Combine(dbFolderPath, _databaseName);
            DbConnectionString = new(_databasePath);
            Connection = new(DbConnectionString);

            InitializeDatabaseContext();
        }

        public async void InitializeDatabaseContext()
        {
            try
            {
                await Connection.CreateTableAsync<RemedyForceSetting>();
                await Connection.CreateTableAsync<EmailConfiguration>();                
                await Connection.CreateTableAsync<NotificationUser>();
                await Connection.CreateTableAsync<AppCompany>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }


        }






    }
}
