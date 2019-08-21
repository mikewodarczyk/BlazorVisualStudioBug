using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

//#nullable enable

namespace MyCompany.Schema
{
    public class ThirdPartyDistributor : IThirdPartyDistributor
    {
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "{0} must be no longer than {1} characters"), MinLength(1)]
        public string Name { get; set; } = "";
       

        public string WarehouseCode { get; set; }
      
        public string IdCode { get; set; } = "";

        public string IdCodeQualifier { get; set; } = "";

        public string GS03Id { get; set; } = "";

        public string OutputEdiPath { get; set; } = "";

        public string InputEdiPath { get; set; } = "";

        public override string ToString()
        {
            return $"ThirdPartyDistributor={{Id:{Id},Name:{Name}}}";
        }
    }

}
