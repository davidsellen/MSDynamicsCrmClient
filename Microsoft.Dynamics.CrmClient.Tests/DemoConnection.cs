using System;

namespace Microsoft.Dynamics.CrmClient.Tests
{
    public class DemoConnection : IServiceConnection
    {


        public string Version => "v9.0";

        public string ClientId => "YOUR CLIENT ID";

        public string ClientSecret => "YOUR CLIENT SECRET";
           

        public string Url => "YOUR CRM URL";

        public string Authority => "https://login.microsoftonline.com/YOUR AUTHORITY ID";
    }
}
