﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetAPI.Data.Seeder
{
    public interface IParser
    {
        public IList<T> Parse<T>(string path);
    }
}
