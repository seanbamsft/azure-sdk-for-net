// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.WebSites;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Database connection string information.
    /// </summary>
    public partial class ConnStringInfo
    {
        /// <summary>
        /// Initializes a new instance of the ConnStringInfo class.
        /// </summary>
        public ConnStringInfo()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ConnStringInfo class.
        /// </summary>
        /// <param name="name">Name of connection string.</param>
        /// <param name="connectionString">Connection string value.</param>
        /// <param name="type">Type of database. Possible values include:
        /// 'MySql', 'SQLServer', 'SQLAzure', 'Custom', 'NotificationHub',
        /// 'ServiceBus', 'EventHub', 'ApiHub', 'DocDb', 'RedisCache',
        /// 'PostgreSQL'</param>
        public ConnStringInfo(string name = default(string), string connectionString = default(string), ConnectionStringType? type = default(ConnectionStringType?))
        {
            Name = name;
            ConnectionString = connectionString;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of connection string.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets connection string value.
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets type of database. Possible values include: 'MySql',
        /// 'SQLServer', 'SQLAzure', 'Custom', 'NotificationHub', 'ServiceBus',
        /// 'EventHub', 'ApiHub', 'DocDb', 'RedisCache', 'PostgreSQL'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ConnectionStringType? Type { get; set; }

    }
}