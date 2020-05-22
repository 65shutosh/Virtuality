using Microsoft.AspNetCore.Http;

namespace Virtuality.API.Helpers
{
    public static class Extensions
    {
        // This function is being used in startup Class to convey a proper message to client
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // creating a header and giving it the message required
            response.Headers.Add("Applicaition-Error", message);
            // to mark Application-Error as a response header
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            // Allowing any access to any origin 
            response.Headers.Add("Access-Control-Allow-origin", "*");
        }													

    }
}           