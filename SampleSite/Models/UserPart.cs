using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SampleSite.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleSite.Models
{

    [ModelMetadataType(typeof(UserMetaData))]
    public partial class User
    {
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public string NewProperty { get; set; }
    }
}
