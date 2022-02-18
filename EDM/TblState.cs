using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblState
    {
        public TblState()
        {
            TblDoctors = new HashSet<TblDoctor>();
            TblHospitals = new HashSet<TblHospital>();
            TblPatients = new HashSet<TblPatient>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<TblDoctor> TblDoctors { get; set; }
        public virtual ICollection<TblHospital> TblHospitals { get; set; }
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
