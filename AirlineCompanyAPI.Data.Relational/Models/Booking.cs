using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyAPI.Data.Relational.Models;

/// <summary>
/// Bookings
/// </summary>
public partial class Booking
{
    /// <summary>
    /// Booking number
    /// </summary>
    [Column("book_ref")]
    public string BookCode { get; set; } = null!;

    /// <summary>
    /// Booking date
    /// </summary>
    public DateTime BookDate { get; set; }

    /// <summary>
    /// Total booking cost
    /// </summary>
    public decimal TotalAmount { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
