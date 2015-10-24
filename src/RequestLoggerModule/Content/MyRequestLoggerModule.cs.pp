using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace $rootnamespace$
{
    class MyRequestLoggerModule : NoiseBakery.RequestLogger.RequestLoggerModule
    {
        /// <summary>
        /// Tells the module to capture the response body.
        /// </summary>
        public override bool CaptureResponseBody
        {
            get
            {
                // Set it to true if you want to capture the response body.
                return false;
            }
        }

        protected override void SaveLogEntry(NoiseBakery.RequestLogger.LogEntry logEntry, HttpRequest request, HttpResponse response)
        {
            // Add some code in order to save to your database.
            ////var db = new ApplicationDbContext();
            ////db.Log.Add(logEntry);
            ////db.SaveChanges();
        }
    }
}