
using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using CScore.DataLayer.Tables;

namespace CScore.DataLayer
{
    public static class DBuilder
    {
        public static SQLiteAsyncConnection _connection;
        private static String DbPath;
        public static String DbName = "Tes";
        public static void setDbPath(String newDbPath)
        {
            DbPath = newDbPath;
        }


        // use it when you need to initilize connection with database and create the tables 
        public static async Task InitializeAsync(String path, ISQLitePlatform sqlitePlatform, String userType)
        {
            DbPath = path;
            _connection = ConnectionBinder.GetConnection(DbPath, sqlitePlatform);
            
            // Create CS tables if need be
            await _connection.CreateTableAsync<Users>();
            await _connection.CreateTableAsync<AnboxL>();
            await _connection.CreateTableAsync<InboxL>();
            await _connection.CreateTableAsync<SemesterL>();
            await _connection.CreateTableAsync<ScheduleL>();
            await _connection.CreateTableAsync<AttachmentL>();

            if (userType == "S" )
            {
                await _connection.CreateTableAsync<MidMarkDistributionL>();
                await _connection.CreateTableAsync<StudentCoursesL>();
                await _connection.CreateTableAsync<ResultsL>();
            }
             if (userType == "L")
            {
                await _connection.CreateTableAsync<LecturerStudentsL>();
            }
            
        }

        //insert data 
        public static async Task<Users> CreateAsync(string text)
        {
            var entity = new Users()
            {
                Use_nameEN = text
            };
            var count = await _connection.InsertAsync(entity);
            return (count == 1) ? entity : null;
            
        }

        public static async Task<IEnumerable<Users>> GetAllAsync()
        {
            var entities = await _connection.Table<Users>().ToListAsync();
            return entities;
        }
    }
}
