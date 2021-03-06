// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.Analytics.Models;

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    /// <summary>
    /// The account specific properties that are associated with an underlying
    /// Data Lake Analytics account.
    /// </summary>
    public partial class DataLakeAnalyticsAccountProperties
    {
        private DateTime _creationTime;
        
        /// <summary>
        /// Optional. Gets or sets the account creation time.
        /// </summary>
        public DateTime CreationTime
        {
            get { return this._creationTime; }
            set { this._creationTime = value; }
        }
        
        private IList<DataLakeStoreAccount> _dataLakeStoreAccounts;
        
        /// <summary>
        /// Optional. Gets or sets the list of Data Lake storage accounts
        /// associated with this account.
        /// </summary>
        public IList<DataLakeStoreAccount> DataLakeStoreAccounts
        {
            get { return this._dataLakeStoreAccounts; }
            set { this._dataLakeStoreAccounts = value; }
        }
        
        private string _defaultDataLakeStoreAccount;
        
        /// <summary>
        /// Optional. Gets or sets the default data lake storage account
        /// associated with this Data Lake Analytics account.
        /// </summary>
        public string DefaultDataLakeStoreAccount
        {
            get { return this._defaultDataLakeStoreAccount; }
            set { this._defaultDataLakeStoreAccount = value; }
        }
        
        private string _endpoint;
        
        /// <summary>
        /// Optional. Gets or sets the full CName endpoint for this account.
        /// </summary>
        public string Endpoint
        {
            get { return this._endpoint; }
            set { this._endpoint = value; }
        }
        
        private DateTime _lastModifiedTime;
        
        /// <summary>
        /// Optional. Gets or sets the account last modified time.
        /// </summary>
        public DateTime LastModifiedTime
        {
            get { return this._lastModifiedTime; }
            set { this._lastModifiedTime = value; }
        }
        
        private int? _maxDegreeOfParallelism;
        
        /// <summary>
        /// Optional. Gets or sets the maximum supported degree of parallelism
        /// for this acocunt.
        /// </summary>
        public int? MaxDegreeOfParallelism
        {
            get { return this._maxDegreeOfParallelism; }
            set { this._maxDegreeOfParallelism = value; }
        }
        
        private int? _maxJobCount;
        
        /// <summary>
        /// Optional. Gets or sets the maximum supported jobs running under the
        /// account at the same time.
        /// </summary>
        public int? MaxJobCount
        {
            get { return this._maxJobCount; }
            set { this._maxJobCount = value; }
        }
        
        private Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeAnalyticsAccountStatus? _provisioningState;
        
        /// <summary>
        /// Optional. Gets or sets the provisioning status of the Data Lake
        /// Analytics account.
        /// </summary>
        public Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeAnalyticsAccountStatus? ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }
        
        private Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeAnalyticsAccountState? _state;
        
        /// <summary>
        /// Optional. Gets or sets the state of the Data Lake Analytics account.
        /// </summary>
        public Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeAnalyticsAccountState? State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        
        private IList<StorageAccount> _storageAccounts;
        
        /// <summary>
        /// Optional. Gets or sets the list of Azure Blob storage accounts
        /// associated with this account.
        /// </summary>
        public IList<StorageAccount> StorageAccounts
        {
            get { return this._storageAccounts; }
            set { this._storageAccounts = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// DataLakeAnalyticsAccountProperties class.
        /// </summary>
        public DataLakeAnalyticsAccountProperties()
        {
            this.DataLakeStoreAccounts = new LazyList<DataLakeStoreAccount>();
            this.StorageAccounts = new LazyList<StorageAccount>();
        }
    }
}
