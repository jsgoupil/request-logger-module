using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace $rootnamespace$
{
    class MyRequestLoggerModule : NoiseBakery.RequestLogger.RequestLoggerModule
    {
        protected override void SaveLogEntry(NoiseBakery.RequestLogger.LogEntry logEntry, HttpRequest request, HttpResponse response)
        {
            // Add some code in order to save to your database.
            ////var db = new ApplicationDbContext();
            ////db.Log.Add(logEntry);
            ////db.SaveChanges();
        }
    }
}