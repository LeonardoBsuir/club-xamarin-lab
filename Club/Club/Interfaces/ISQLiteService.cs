﻿using System;
using SQLite;

namespace Club
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}