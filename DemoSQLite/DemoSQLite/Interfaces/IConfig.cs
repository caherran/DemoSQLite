﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Interfaces
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        //ISQLitePlatform Plataforma { get; }
    }
}
