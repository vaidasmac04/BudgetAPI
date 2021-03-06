﻿using Budget.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Incomes
{
    public interface IIncomeUpdater
    {
        Task Update(Income income);
    }
}
