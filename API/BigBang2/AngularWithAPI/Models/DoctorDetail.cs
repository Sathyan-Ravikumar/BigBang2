using System;
using System.Collections.Generic;

namespace AngularWithAPI.Models;

public partial class DoctorDetail
{
    public int Doctorid { get; set; }

    public int? Userid { get; set; }

    public string? DoctorName { get; set; }

    public string? Specialization { get; set; }

    public int? Experience { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public long? ContactNumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? User { get; set; }
}
