using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMotAppointments.Models.Repositories
{
    public interface IAppointmentRepository
    {
        // Declare method to return all appointments as an enumerable list
        IEnumerable<Appointment> SelectAll();

        // Declare method to return a single appointment entity where it's id matches the id parameter
        Appointment SelectByID(int id);

        // Declare method to return an enumerable list of appointments for a specific mot centre id
        IEnumerable<Appointment> SelectAppointmentsByCentreId(int id);

        // Declare method that accepts a new appointment object and adds it to the Appointment DbSet
        void Insert(Appointment obj);

        // Declare method that updates an appointment object and marks it as modified in the Appointment DbSet
        void Update(Appointment obj);

        // Declare method that removes an appointment object from the DbSet if the id parameter matches an mot centre id
        void Delete(int id);

        // Declare method to save changes made to the database
        void Save();
    }
}
