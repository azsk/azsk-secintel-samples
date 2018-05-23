using System;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.ServiceBus;

namespace SecIntelSample
{
    public class AzureServiceBusSample
    {
        // Rule ID: azure_sbr_no_client_authentication
        public void RunUsingRelay(string httpAddress, string listenToken)
        {
            using (var host = new WebServiceHost(this.GetType()))
            {
                // Warning generate due to usage of insecure [None] RelayClientAuthenticationType

                var webHttpRelayBinding = new WebHttpRelayBinding(EndToEndWebHttpSecurityMode.Transport,
                                                                  RelayClientAuthenticationType.None)
                { IsDynamic = false };

                // Safe
                webHttpRelayBinding = new WebHttpRelayBinding(EndToEndWebHttpSecurityMode.Transport,
                                                                  RelayClientAuthenticationType.RelayAccessToken)
                { IsDynamic = false };

                host.AddServiceEndpoint(this.GetType(),
                    webHttpRelayBinding,
                    httpAddress)
                    .EndpointBehaviors.Add(
                        new TransportClientEndpointBehavior(
                            TokenProvider.CreateSharedAccessSignatureTokenProvider(listenToken)));

                host.Open();

                Console.WriteLine("Copy the following address into a browser to see the image: ");
                Console.WriteLine(httpAddress + "/Image");
                Console.WriteLine();
                Console.WriteLine("Press [Enter] to exit");
                Console.ReadLine();

                host.Close();
            }
        }

        [OperationContract, WebGet]
        Stream Image()
        {
            Debug.Assert(WebOperationContext.Current != null, "WebOperationContext.Current != null");

            var stream = new MemoryStream();
            stream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return stream;
        }
    }
}