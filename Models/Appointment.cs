using System;
using System.Collections.Generic;

namespace CitasGestor.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string UserName { get; set; } = null!;

    public int? UserAge { get; set; }

    public string Attendant { get; set; } = null!;

    public decimal? AmountPayable { get; set; }

    public string? Status { get; set; }
}
