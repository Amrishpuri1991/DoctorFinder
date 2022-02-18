using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblAppointments = new HashSet<TblAppointment>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddressLine1 { get; set; }
        public string PatientAddressLine2 { get; set; }
        public string PatientAddressLine3 { get; set; }
        public string PatientEmail { get; set; }
        public int? PatientPhoneNumber { get; set; }
        public int? AppointmentId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public virtual TblAppointment Appointment { get; set; }
        public virtual TblCity City { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblAppointment> TblAppointments { get; set; }
    }
}
