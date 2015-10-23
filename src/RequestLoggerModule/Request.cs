using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoiseBakery.RequestLogger
{
    /// <summary>
    /// Request class holding important data about the http request.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// HTTP Method (e.g. POST, GET, etc.)
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Raw URL requested on the server.
        /// </summary>
        public string RawUrl { get; set; }

        /// <summary>
        /// Server Protocol (e.g. HTTP 1.1)
        /// </summary>
        public string ServerProtocol { get; set; }

        /// <summary>
        /// List of headers key/value pair sent from the client.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Request body, used for POST, PATCH, etc.
        /// </summary>
        public string Body { get; set; }
    }
}
