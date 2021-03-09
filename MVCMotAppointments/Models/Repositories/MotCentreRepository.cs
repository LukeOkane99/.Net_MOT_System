using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCMotAppointments.Models.Repositories
{
    public class MotCentreRepository : IMotCentreRepository
    {
        private MotDatabaseContext db = null;

        // Constructors to initialise MotDatabaseContext db object
        public MotCentreRepository()
        {
            this.db = new MotDatabaseContext();
        }

        public MotCentreRepository(MotDatabaseContext db)
        {
            this.db = db;
        }

        // Implementation of method to return a list of all mot centres in alphabetical order of the centre name
        public IEnumerable<MotCentre> SelectAll()
        {
            return db.MOT_Centres.OrderBy(a => a.CentreName).ToList();
        }

        // Implementation of method to return a single mot centre based off of it's unique id
        public MotCentre SelectByID(int id)
        {
            return db.MOT_Centres.Find(id);
        }

        // Implementation of method to insert a new mot centre object into the database
        public void Insert(MotCentre obj)
        {
            db.MOT_Centres.Add(obj);
        }

        // Implementation of method to update an motcentre object in the database
        public void Update(MotCentre obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        // Imlementation of method to delete an mot centre from the database based on it's unique id
        public void Delete(int id)
        {
            MotCentre existing = db.MOT_Centres.Find(id);
            db.MOT_Centres.Remove(existing);
        }

        // Implementation of method to save changes to the database
        public void Save()
        {
            db.SaveChanges();
        }
    }
}