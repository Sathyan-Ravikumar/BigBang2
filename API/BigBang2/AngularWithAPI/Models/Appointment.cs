using System;
using System.Collections.Generic;

namespace AngularWithAPI.Models;

public partial class Appointment
{
    public int? Userid { get; set; }

    public int? Doctorid { get; set; }

    public int Appid { get; set; }

    public string? PatientName { get; set; }

    public int? PatientAge { get; set; }

    public string? PatientGender { get; set; }

    public string? PatientAddress { get; set; }

    public long? PatientNumber { get; set; }

    public string? DoctorName { get; set; }

    public string? SpecializationPatientNeed { get; set; }

    public DateTime? VisitingDate { get; set; }

    public TimeSpan? AppoitmentTime { get; set; }

    public virtual DoctorDetail? Doctor { get; set; }

    public virtual User? User { get; set; }
}
