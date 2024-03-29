﻿
using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace CScore.DataLayer
{
    public class ConnectionBinder
    {

        public static SQLiteAsyncConnection GetConnection(string path, ISQLitePlatform sqlitePlatform)
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(
                () => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, false))
                );
            return new SQLiteAsyncConnection(connectionFactory);
        }
    }
}
