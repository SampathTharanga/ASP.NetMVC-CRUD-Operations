using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Operations.Models
{
    [MetadataType (typeof(EmployeeMetadata))]
    public class Employee
    {
    }

    public class EmployeeMetadata
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }
        [Required (AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }
    }
}