namespace MVCMotAppointments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointment
    {
        // Store the Primary Key, Appointment Id in model
        public int Id { get; set; }

        // The registration number field must be filled out before a form can be posted 
        [Required(ErrorMessage = "The registration number is required!")]
        // Set the maximum number of characters for a registration number to 20
        [StringLength(20)]
        // Set the data type to text
        [DataType(DataType.Text)]
        // Store registration number property in model
        public string RegistrationNo { get; set; }

        // The owner field must be filled out before a form can be posted
        [Required(ErrorMessage = "The owner of the vehicle is required!")]
        // Set the data type to text
        [DataType(DataType.Text)]
        // Store owner property in model
        public string Owner { get; set; }

        // The appointment date must be filled in before a form can be posted
        [Required(ErrorMessage = "The date of the appointment is required!")]
        // Set the data type to DateTime 
        [DataType(DataType.DateTime)]
        // Set the display format for the appointment date e.g: 01/02/2021 12:30pm
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        // Store appointment date in the model 
        public DateTime AppointmentDate { get; set; }

        // Store the Foreign Key, mot centre Id in the model
        public int MotCentreId { get; set; }

        // Reference MotCentre model class to access other properties through relationship e.g: name of the mot centre from an mot centre Id
        public virtual MotCentre MotCentre { get; set; }
    }
}
