using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblAppointment
    {
        public TblAppointment()
        {
            TblPatients = new HashSet<TblPatient>();
        }

        public int AppointmentId { get; set; }
        public bool? AppointmentStatus { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? AppointmentPrice { get; set; }
        public int? HospitalId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual TblHospital Hospital { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
