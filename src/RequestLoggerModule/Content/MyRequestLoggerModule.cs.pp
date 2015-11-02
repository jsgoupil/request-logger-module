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
        /// Indicates to capture the request body.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>True to capture the request. False otherwise.</returns>
        public override bool ShouldCaptureRequestBody(HttpRequest request)
        {
            // Set it to true if you want to capture the request body.
            return false;
        }

        /// <summary>
        /// Indicates to capture the response body.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>True to capture the response. False otherwise.</returns>
        public override bool ShouldCaptureResponseBody(HttpRequest request)
        {
            // Set it to true if you want to capture the response body.
            return false;
        }

        protected override void SaveLogEntry(NoiseBakery.RequestLogger.LogEntry logEntry, HttpRequest request, HttpResponse response)
        {
            // Add some code in order to save to your database.
            ////using (var db = new ApplicationDbContext())
            ////{
            ////    db.Log.Add(logEntry);
            ////    db.SaveChanges();
            ////}
        }
    }
}