using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblDoctors = new HashSet<TblDoctor>();
            TblHospitals = new HashSet<TblHospital>();
            TblPatients = new HashSet<TblPatient>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? PostCode { get; set; }

        public virtual ICollection<TblDoctor> TblDoctors { get; set; }
        public virtual ICollection<TblHospital> TblHospitals { get; set; }
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
