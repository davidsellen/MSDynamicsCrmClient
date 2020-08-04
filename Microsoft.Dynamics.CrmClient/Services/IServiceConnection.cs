using System;

namespace Microsoft.Dynamics.CrmClient
{
    public interface IServiceConnection
    {


        /// <summary>
        /// Azure AD App Id
        /// </summary>
        string ClientId { get; }
        /// <summary>
        /// Client Secret Generated for App
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// Your O365 Org URL https://< your D365 org>.< crm instance location e.g crm, crm8 >.dynamics.com
        /// </summary>
        string Url { get; }

        string Authority { get; }
    }
}
