﻿using System;

using DDO.WebApp.Mappings;

namespace DDO.WebApp.Api.SupplierApi
{
    public class SupplierResource : KeyValuePairResource
    {
        public string Gstin { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ContactNumber { get; set; }
        public string RegistrationType { get; set; }

    }
}