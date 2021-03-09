namespace MVCMotAppointments
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MotDatabaseContext : DbContext
    {
        public MotDatabaseContext()
            : base("name=MotDatabaseContext")
        {
        }

        // Entities
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<MotCentre> MOT_Centres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
