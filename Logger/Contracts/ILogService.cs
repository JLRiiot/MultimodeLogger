using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logger.Contracts
{
    public interface ILogService : IDisposable
    {
        string Insert(ILogEntity logEntity);
        Task<List<ILogEntity>> GetAllAsync();
    }
}
