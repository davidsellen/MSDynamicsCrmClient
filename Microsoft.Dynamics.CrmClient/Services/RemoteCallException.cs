using System;

namespace Microsoft.Dynamics.CrmClient
{
    [Serializable]
    public class RemoteCallException : ApplicationException
    {
        public RemoteCallException(string message, string resource, string error, string contents = null) : base(message)
        {
            this.Data["resource"] = resource;
            this.Data["error"] = error;
            this.Data["contents"] = contents;
        }

        public RemoteCallException(string message, Exception innerException) : base(message, innerException)
        {
        }


    }


}
