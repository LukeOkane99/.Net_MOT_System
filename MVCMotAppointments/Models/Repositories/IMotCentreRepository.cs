using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCMotAppointments.Models.Repositories
{
    public interface IMotCentreRepository
    {
        // Declare method to return all mot centres as an enumerable list
        IEnumerable<MotCentre> SelectAll();

        // Declare method to return a single mot centre entity where it's id matches the id parameter  
        MotCentre SelectByID(int id);

        // Declare method that accepts a new mot centre object and adds it to the MotCentre DbSet
        void Insert(MotCentre obj);

        // Declare method that updates an mot centre object and marks it as modified in the MotCentre DbSet
        void Update(MotCentre obj);

        // Declare method that removes an mot centre object from the DbSet if the id parameter matches an mot centre id
        void Delete(int id);

        // Declare method to save changes made to the database
        void Save();
    }
}
