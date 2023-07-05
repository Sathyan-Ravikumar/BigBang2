using System;
using System.Collections.Generic;

namespace AngularWithAPI.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }

    public byte[]? Hashkey { get; set; }

    public byte[]? Password { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorDetail> DoctorDetails { get; set; } = new List<DoctorDetail>();
}
