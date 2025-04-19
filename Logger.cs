using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    interface ILogger
    {
        void Log(string message);
    }
    class Logger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"Log: {message} at {DateTime.Now}");

    }
}
