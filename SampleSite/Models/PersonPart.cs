using Microsoft.AspNetCore.Mvc;
using SampleSite.MetaData;
using System;
using System.Collections.Generic;

namespace SampleSite.Models;

[ModelMetadataType(typeof(PersonMetaData))]
public partial class Person
{
    
}
