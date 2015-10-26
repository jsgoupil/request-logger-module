using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NoiseBakery.RequestLogger
{
    /// <summary>
    /// Module handling logging requests and responses.
    /// </summary>
    public abstract class RequestLoggerModule : IHttpModule
    {
        /// <summary>
        /// Key used to save in HttpContext.Items.
        /// </summary>
        private const string FILTER_KEY = "RequestLoggerModule.Filter";

        /// <summary>
        /// Key used to save in HttpContext.Items.
        /// </summary>
        private const string EXTRA_KEY = "RequestLoggerModule.Extra";

        /// <summary>
        /// Indicates to capture the request body.
        /// </summary>
        public virtual bool CaptureRequestBody
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Indicates to capture the response body.
        /// </summary>
        public virtual bool CaptureResponseBody
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes the class.
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        /// <summary>
        /// Disposes the class.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Initializes the request by setting a response filter.
        /// </summary>
        /// <param name="sender">Application.</param>
        /// <param name="e">Event.</param>
        private void BeginRequest(object sender, EventArgs e)
        {
            if (CaptureResponseBody)
            {
                var application = (HttpApplication)sender;
                var response = application.Response;
                var filter = new OutputFilterStream(response.Filter);
                response.Filter = filter;

                application.Request.RequestContext.HttpContext.Items[FILTER_KEY] = filter;
            }
        }

        /// <summary>
        /// Finalizes the log.
        /// </summary>
        /// <param name="sender">Application.</param>
        /// <param name="e">Event.</param>
        private void EndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var request = application.Request;
            var response = application.Response;
            var items = request.RequestContext.HttpContext.Items;

            var filter = items[FILTER_KEY] as OutputFilterStream;
            var extra = items[EXTRA_KEY] as Dictionary<string, object>;

            var logEntry = new LogEntry
            {
                Request = new Request
                {
                    Method = request.HttpMethod,
                    RawUrl = request.RawUrl,
                    ServerProtocol = request.ServerVariables["SERVER_PROTOCOL"],
                    Headers = request.Headers,
                    Body = CaptureRequestBody ? new StreamReader(request.InputStream).ReadToEnd() : null,
                },
                Response = new Response
                {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    Headers = response.Headers,
                    Body = filter != null ? filter.ReadStream() : null
                },
                Extra = extra
            };

            // Let's rewind the request stream.
            request.InputStream.Seek(0, SeekOrigin.Begin);

            SaveLogEntry(logEntry, request, response);
        }

        /// <summary>
        /// Saves the log somewhere. To a database for instance.
        /// Raw request/response is also given in case other information should be saved.
        /// </summary>
        /// <param name="logEntry">Curated data to save to a database.</param>
        /// <param name="request">Raw request.</param>
        /// <param name="response">Raw response.</param>
        abstract protected void SaveLogEntry(LogEntry logEntry, HttpRequest request, HttpResponse response);

        /// <summary>
        /// Saves a key/value pair into the HttpContext.Items for future use by the logger.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public static void SaveItem(string key, object value)
        {
            Dictionary<string, object> dictionary = null;
            dictionary = HttpContext.Current.Items[EXTRA_KEY] as Dictionary<string, object>;
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
                HttpContext.Current.Items[EXTRA_KEY] = dictionary;
            }

            dictionary[key] = value;
        }
    }
}
