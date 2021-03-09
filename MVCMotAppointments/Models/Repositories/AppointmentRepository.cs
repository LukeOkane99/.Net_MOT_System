using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMotAppointments.Models.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MotDatabaseContext db = null;

        // Constructors to initialise db object
        public AppointmentRepository()
        {
            this.db = new MotDatabaseContext();
        }

        public AppointmentRepository(MotDatabaseContext db)
        {
            this.db = db;
        }

        // Implementation of method to return a list of all appointments, ordered by the date of the appointment
        public IEnumerable<Appointment> SelectAll()
        {
            return db.Appointments.OrderBy(a => a.AppointmentDate).ToList();
        }

        // Implementation of method to return a single appointment based off it's unique id
        public Appointment SelectByID(int id)
        {
            return db.Appointments.Find(id);
        }

        // Implementation of method to return a list of all appointments for a certain mot centre, ordered by the date of the appointment 
        public IEnumerable<Appointment> SelectAppointmentsByCentreId(int id)
        {
            return db.Appointments.Where(a => a.MotCentre.Id.Equals(id)).OrderBy(a => a.AppointmentDate).ToList();
        }

        // Implementation of method to insert a new appointment object into the database
        public void Insert(Appointment obj)
        {
            db.Appointments.Add(obj);
        }


        // Implementation of method to update an appointment object in the database
        public void Update(Appointment obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        // Implementation of method to delete an appointment from the database based on it's unique id
        public void Delete(int id)
        {
            Appointment existing = db.Appointments.Find(id);
            db.Appointments.Remove(existing);
        }

        // Implementation of method to save changes to the database
        public void Save()
        {
            db.SaveChanges();
        }
    }
}