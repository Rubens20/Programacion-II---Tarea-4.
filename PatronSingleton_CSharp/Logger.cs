using System;
using System.Collections.Generic;
using System.Text;

namespace PatronSingleton_CSharp
{
    sealed class Logger
    {
        private static readonly Logger _logger = new Logger();

        public static Logger GetLogger()
        {
            return _logger;
        }

        public void Log(string message)
        {
            Console.WriteLine("Ha ocurrido una excepcion: " + message);
        }
    }
}
