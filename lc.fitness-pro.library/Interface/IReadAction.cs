﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lc.fitness_pro.library.Interface
{
    public interface IReadAction<T>
    {
        Task<T> GetById(Guid key);
        IEnumerable<T> FindByField(Func<T, T> predicat);
    }
}