namespace MVCMotAppointments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // Declare correct table to look at to bypass invalid column name errors I was having
    [Table("MOT_Centres")]
    public partial class MotCentre
    {
        // Store property for the Id of an Mot Centre
        public int Id { get; set; }

        // The centre name is required before a form is posted
        [Required(ErrorMessage = "The centre name is required!")]
        // Maximum length of characters allowed for a centre name
        [StringLength(100)]
        // Sets the data type to text
        [DataType(DataType.Text)]
        // Store centre name property in model
        public string CentreName { get; set; }

        // The operating hours are required before a form can be posted
        [Required(ErrorMessage = "The operating hours are required!")]
        // Sets the data type to text
        [DataType(DataType.Text)]
        // Store operating hours property in model
        public string OperatingHrs { get; set; }

        // The address is required before a form can be posted
        [Required(ErrorMessage = "The address is required!")]
        // Sets the data type to text
        [DataType(DataType.Text)]
        // Store address property in model
        public string Address { get; set; }

        // Telephone number is required before a form is posted 
        [Required]
        // Ensure the telephone number can only be 11 characters 
        [StringLength(11)]
        // Regular expression to ensure phone number is in the correct format
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid Phone Number!")]
        // Set the data type to phone number to ensure the number is in a credible format
        [DataType(DataType.PhoneNumber)]
        // Store the telephone number property in model
        public string TelephoneNo { get; set; }

        // The county is required before a form can be posted
        [Required(ErrorMessage = "The county is required!")]
        // The maximum length of characters allowed for a county
        [StringLength(30)]
        // Sets the data type to text
        [DataType(DataType.Text)]
        // Store county property in model
        public string County { get; set; }
    }
}
