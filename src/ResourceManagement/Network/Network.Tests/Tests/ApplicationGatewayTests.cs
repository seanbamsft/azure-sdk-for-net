﻿using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure;
using System;
using Microsoft.Azure.Management.Network;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.Network.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Networks.Tests
{
    public class ApplicationGatewayTests
    {
        private static string GetChildAppGwResourceId(string subscriptionId,
                                                        string resourceGroupName,
                                                        string appGwname,
                                                        string childResourceType,
                                                        string childResourceName)
        {
            return string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/applicationGateways/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    appGwname,
                    childResourceType,
                    childResourceName);
        }

        [Fact]
        public void ApplicationGatewayApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();                
                //var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                

                #region LocalNRPRun

                //System.Uri nrpBaseUri = new System.Uri("http://127.0.0.1/");
                System.Uri nrpBaseUri = new System.Uri("http://kaga/");
                string subscriptionId = "947008ac-b143-4b7d-83ca-c99fbfd6c330";
                //string subscriptionId = "7e2a56ef-1038-4480-a48c-5697c3e8eb3c";
                X509Certificate2 nrpManagementCertificate = new X509Certificate2();
                nrpManagementCertificate.Import(@"D:\git_networking_nrp_dev\Networking\nrp\src\Certs\nrpclienttest.pfx", 
                    "rdPa$$w0rd", X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet);
                CertificateCloudCredentials credentials = new CertificateCloudCredentials(subscriptionId, nrpManagementCertificate);

                #region RegisterSubscriptionToNRP_OneTimeLocalSetup
                // Register Subscription
                var certHandler = new WebRequestHandler();
                certHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                certHandler.UseDefaultCredentials = false;
                certHandler.ClientCertificates.Add(nrpManagementCertificate);

                HttpClient httpClient = new HttpClient(certHandler);
                //httpClient.BaseAddress = new Uri("http://127.0.0.1/");
                httpClient.BaseAddress = new Uri("http://kaga/");
                //httpClient.BaseAddress = new Uri("https://nrp7.windows.azure-test.net");

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, "subscriptions/947008ac-b143-4b7d-83ca-c99fbfd6c330?api-version=2014-04-01");
                //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, "subscriptions/7e2a56ef-1038-4480-a48c-5697c3e8eb3c?api-version=2014-04-01");

                req.Content = new StringContent("{\"state\":\"Registered\"}", Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("x-ms-client-role", "PlatformServiceAdministrator");
                httpClient.SendAsync(req).ContinueWith(respTask =>
                {
                    Console.WriteLine("Response: {0}", respTask.Result);
                });

                #endregion RegisterSubscriptionToNRP_OneTimeLocalSetup

                //LocalNRP
                var networkResourceProviderClient = new NetworkResourceProviderClient(credentials, nrpBaseUri);
                networkResourceProviderClient.HttpClient.DefaultRequestHeaders.Add("x-ms-client-role", "NrpUser");
                
                //string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string resourceGroupName = "azsmnetkagatest";
                //var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                //var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/applicationGateways");
                //resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                //    new ResourceGroup
                //    {
                //        Location = location
                //    });
                #endregion


                // Create Application Gateway
                int instanceCount = 1;
                //string vnetName = TestUtilities.GenerateName();
                //string subnetName = TestUtilities.GenerateName();
                //var appGwName = TestUtilities.GenerateName();
                //var frontendIpConfigName = TestUtilities.GenerateName();
                //var frontendPortName = TestUtilities.GenerateName();
                //var backendAddressPoolName = TestUtilities.GenerateName();
                //var backendHttpSettingsName = TestUtilities.GenerateName();
                //var requestRoutingRuleName = TestUtilities.GenerateName();
                //var backendAddressName1 = TestUtilities.GenerateName();
                //var backendAddressName2 = TestUtilities.GenerateName();
                //var sslCertName = TestUtilities.GenerateName();
                //var httpListenerName = TestUtilities.GenerateName();

                string vnetName = "azsmnet_vnetName";
                string subnetName = "azsmnet_subnetName";
                var appGwName = "azsmnet_appGwName";
                var gatewayIpConfigName = "azsmnet_gatewayIpConfigName";
                var frontendIpConfigName = "azsmnet_frontendIpConfigName";
                var frontendPortName = "azsmnet_frontendPortName";
                var backendAddressPoolName = "azsmnet_backendAddressPoolName";
                var backendHttpSettingsName = "azsmnet_backendHttpSettingsName";
                var requestRoutingRuleName = "azsmnet_requestRoutingRuleName";                
                var sslCertName = "azsmnet_sslCertName";
                var password = "1234";
                var httpListenerName = "azsmnet_httpListenerName";

                X509Certificate2 cert = new X509Certificate2("D:\\AppGWe2eTest\\GW5000.pfx", password, X509KeyStorageFlags.Exportable);
                ApplicationGatewaySslCertificate sslCert = new ApplicationGatewaySslCertificate()
                {
                    Name = sslCertName,
                    Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),                    
                    Password = password
                };

                var vnet = new VirtualNetwork()
                {
                    Location = "WestUs",

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                        }
                    }
                };

                
                
                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                var appGw = new ApplicationGateway()
                {
                    Location = "WestUs",
                    Name = appGwName,
                    InstanceCount = instanceCount,
                    Size = ApplicationGatewaySize.Medium,
                    GatewayIpConfigurations = new List<ApplicationGatewayIpConfiguration>()
                    {
                        new ApplicationGatewayIpConfiguration()
                        {
                            Name = gatewayIpConfigName,
                            Subnet = new ResourceId()
                            {
                                Id = getSubnetResponse.Subnet.Id
                            }
                        }
                    },
                    SslCertificates = new List<ApplicationGatewaySslCertificate>()
                    {
                        sslCert
                    },
                    FrontendIpConfigurations = new List<ApplicationGatewayFrontendIpConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                            Subnet = new ResourceId()
                            {
                                Id = getSubnetResponse.Subnet.Id
                            }                          
                        }                    
                    },
                    FrontendPorts = new List<ApplicationGatewayFrontendPort>
                    {
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPortName,
                            Port = 80
                        }
                    },
                    BackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                    {
                        new ApplicationGatewayBackendAddressPool()
                        {
                            Name = backendAddressPoolName,
                            BackendAddresses = new List<ApplicationGatewayBackendAddress>()
                            {
                                new ApplicationGatewayBackendAddress()
                                {
                                    //Fqdn = "testDnsName1",
                                    IpAddress = "10.2.0.1"
                                },
                                new ApplicationGatewayBackendAddress()
                                {
                                    //Fqdn = "testDnsName2",
                                    IpAddress = "10.2.0.2"
                                }
                            }
                        }
                    },
                    BackendHttpSettingsCollection = new List<ApplicationGatewayBackendHttpSettings> 
                    {
                        new ApplicationGatewayBackendHttpSettings()
                        {
                            Name = backendHttpSettingsName,
                            Port = 80,
                            Protocol = ApplicationGatewayProtocol.Http,
                            CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled
                        }
                    },
                    HttpListeners = new List<ApplicationGatewayHttpListener>
                    {
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListenerName,
                            FrontendPort = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIpConfiguration = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIpConfigName)
                            },
                            SslCertificate = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "sslCertificates", sslCertName)
                            },
                            Protocol = ApplicationGatewayProtocol.Http
                        }
                    },
                    RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                    {
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRuleName,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                            }
                        }
                    }


                };

                // Put AppGw
                var putAppGwResponse = networkResourceProviderClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGwName, appGw);
                Assert.Equal(HttpStatusCode.OK, putAppGwResponse.StatusCode);
                Assert.Equal("Succeeded", putAppGwResponse.Status);

                //// Get AppGw
                //var getAppGw = networkResourceProviderClient.ApplicationGateways.Get(resourceGroupName, appGwName);
                //Assert.Equal(appGwName, getAppGw.ApplicationGateway.Name);
                //Assert.Equal(instanceCount, getAppGw.ApplicationGateway.InstanceCount);
                //Assert.Equal(ApplicationGatewaySize.Medium, getAppGw.ApplicationGateway.Size);
                //Assert.Equal(appGwName, getAppGw.ApplicationGateway.Name);

                //// List AppGw
                //var listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);

                //// List all AppGw
                //var listAllAppGw = networkResourceProviderClient.ApplicationGateways.ListAll();

                //Start AppGw
                var startResult = networkResourceProviderClient.ApplicationGateways.Start(resourceGroupName, appGwName, appGw);

                ////Stop AppGw
                //var stopResult = networkResourceProviderClient.ApplicationGateways.Stop(resourceGroupName, appGwName, appGw);

                //// Delete AppGw
                //var deleteAppGw = networkResourceProviderClient.ApplicationGateways.Delete(resourceGroupName, appGwName);

                //// Verify Delete
                //listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                //Assert.Equal(0, listAppGw.ApplicationGateways.Count);
            }
        }
    }
}