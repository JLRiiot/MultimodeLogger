using System;
using Microsoft.Extensions.Configuration;
using Logger;
using Logger.Repositories;
using MongoDB.Driver;
using System.IO;
using Logger.Services;

namespace LoggerPlayground
{
    class Program
	{
        static void Main(string[] args)
        {
            // Creating a default Log with all persistence types
            // and all verbose levels
            Log log1 = new Log();

            log1.WriteError("Testing error");
			log1.WriteMessage("Testing if polymorphism works");
            log1.WriteWarning("For this entry _t must be WarningLogEntity");

			// You can configure your own Log instance with different Repositories
			// and log verbosity levels using a different constructors:
			// Log log2 = new Log(<YOUR LOG REPOSITORY>)
			// Log log2 = new Log(<A LIST OF YOUR LOG REPOSITORIES>)
		}
    }
}
