using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Logger.Services;
using MongoDB.Driver;
using Logger.Repositories;

namespace Logger.Factories
{
    public abstract class LogRepositoryFactory
    {
        public abstract LogRepository CreateRepository();
    }
}
