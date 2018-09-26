﻿using System;
using DDO.Domain.Enums;

namespace DDO.WebApp.Api.SupplierApi
{
    public class SaveSupplierResource
    {
        public string Name { get; set; }
        
        public string Gstin { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ContactNumber { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public string Email { get; set; }
    }
}