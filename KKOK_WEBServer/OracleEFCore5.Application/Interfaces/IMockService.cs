﻿using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Collections.Generic;

namespace OracleEFCore5.Application.Interfaces
{
    public interface IMockService
    {
        List<TestTable> GetTestTables(int rowCount);
        List<TestTable> SeedTestTables(int rowCount);
    }
}