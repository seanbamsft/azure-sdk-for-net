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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Management.Sql.Models
{
    /// <summary>
    /// Represents the properties of an Azure SQL Recommended Elastic Pool.
    /// </summary>
    public partial class RecommendedElasticPoolProperties
    {
        private double _databaseDtuMax;
        
        /// <summary>
        /// Optional. Gets the maximum DTU for the database.
        /// </summary>
        public double DatabaseDtuMax
        {
            get { return this._databaseDtuMax; }
            set { this._databaseDtuMax = value; }
        }
        
        private double _databaseDtuMin;
        
        /// <summary>
        /// Optional. Gets the minimum DTU for the database.
        /// </summary>
        public double DatabaseDtuMin
        {
            get { return this._databaseDtuMin; }
            set { this._databaseDtuMin = value; }
        }
        
        private string _databaseEdition;
        
        /// <summary>
        /// Optional. Gets the edition of the Azure SQL Recommended Elastic
        /// Pool. The DatabaseEditions enumeration contains all the valid
        /// editions.
        /// </summary>
        public string DatabaseEdition
        {
            get { return this._databaseEdition; }
            set { this._databaseEdition = value; }
        }
        
        private IList<Database> _databases;
        
        /// <summary>
        /// Optional. Gets the list of Azure Sql Databases in this pool.
        /// Expanded property
        /// </summary>
        public IList<Database> Databases
        {
            get { return this._databases; }
            set { this._databases = value; }
        }
        
        private double _dtu;
        
        /// <summary>
        /// Optional. Gets the DTU for the Sql Azure Recommended Elastic Pool.
        /// </summary>
        public double Dtu
        {
            get { return this._dtu; }
            set { this._dtu = value; }
        }
        
        private double _maxObservedDtu;
        
        /// <summary>
        /// Optional. Gets maximum observed DTU.
        /// </summary>
        public double MaxObservedDtu
        {
            get { return this._maxObservedDtu; }
            set { this._maxObservedDtu = value; }
        }
        
        private double _maxObservedStorageMB;
        
        /// <summary>
        /// Optional. Gets maximum observed storage in megabytes.
        /// </summary>
        public double MaxObservedStorageMB
        {
            get { return this._maxObservedStorageMB; }
            set { this._maxObservedStorageMB = value; }
        }
        
        private IList<RecommendedElasticPoolMetric> _metrics;
        
        /// <summary>
        /// Optional. Gets or sets the list of Azure Sql Databases housed in
        /// the server. Expanded property
        /// </summary>
        public IList<RecommendedElasticPoolMetric> Metrics
        {
            get { return this._metrics; }
            set { this._metrics = value; }
        }
        
        private DateTime _observationPeriodEnd;
        
        /// <summary>
        /// Optional. Gets the observation period start.
        /// </summary>
        public DateTime ObservationPeriodEnd
        {
            get { return this._observationPeriodEnd; }
            set { this._observationPeriodEnd = value; }
        }
        
        private DateTime _observationPeriodStart;
        
        /// <summary>
        /// Optional. Gets the observation period start.
        /// </summary>
        public DateTime ObservationPeriodStart
        {
            get { return this._observationPeriodStart; }
            set { this._observationPeriodStart = value; }
        }
        
        private double _storageMB;
        
        /// <summary>
        /// Optional. Gets storage size in megabytes.
        /// </summary>
        public double StorageMB
        {
            get { return this._storageMB; }
            set { this._storageMB = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RecommendedElasticPoolProperties
        /// class.
        /// </summary>
        public RecommendedElasticPoolProperties()
        {
            this.Databases = new LazyList<Database>();
            this.Metrics = new LazyList<RecommendedElasticPoolMetric>();
        }
    }
}
