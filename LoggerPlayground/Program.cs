using Logger;

namespace LoggerPlayground
{
    class Program
	{
        static void Main(string[] args)
        {
			// Creating a default Log with all persistence types
			// and all verbose levels
			bool logMessage = true, logError = true, logWarning = true;
            Log log1 = new Log(logMessage, logWarning, logError);

            log1.EnableConsole();
            log1.WriteError("Writing an error to Console");
            log1.EnableFileSystem();
			log1.WriteMessage("Writing a message to Console and File");
            log1.EnableMongo();
            log1.WriteWarning("Writing a warning to all persinstence repositories");
		}
    }
}
