using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeREST
{
    // Enum for HTTP verbs
    public enum METHOD
    {
        GET,
        SET,
        PUT,
        DELETE
    }

    class Client
    {
        public string URI { get; set; }
        public METHOD HttpMethod { get; set; }

        // This constructor will set the method to GET by default, and initalize
        // the URI to an empty string.
        public Client()
        {
            URI = "";
            HttpMethod = METHOD.GET;
        }

        public string Request()
        {

            //
            //https://jsonplaceholder.typicode.com/posts
            //
            // Create a new request and assign the method to be used.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Method = HttpMethod.ToString();
            string responseToReturn = "";

            // Use the response
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Check to see if the request was successful
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    // If it wasnt, throw an exception.
                    throw new Exception("The response did not return successfully.");
                }
                // HttpWebResponse.GetResponseStream returns a Stream object, which I need a StreamReader to properly read.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Check to see if something was returned
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseToReturn = reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        throw new Exception("The request returned null.");
                    }

                }
            }
            // Return the whole JSON output in string form.
            return responseToReturn;
        }

    }
}
