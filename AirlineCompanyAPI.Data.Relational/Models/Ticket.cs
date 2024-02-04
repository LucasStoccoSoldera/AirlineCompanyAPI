using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyAPI.Data.Relational.Models;

/// <summary>
/// Tickets
/// </summary>
public partial class Ticket
{
    /// <summary>
    /// Ticket number
    /// </summary>
    [Column("ticket_no")]
    public string TicketCode { get; set; } = null!;

    /// <summary>
    /// Booking number
    /// </summary>
    [Column("book_ref")]
    public string BookCode { get; set; } = null!;

    /// <summary>
    /// Passenger ID
    /// </summary>
    public string PassengerId { get; set; } = null!;

    /// <summary>
    /// Passenger name
    /// </summary>
    public string PassengerName { get; set; } = null!;

    /// <summary>
    /// Passenger contact information
    /// </summary>
    public string? ContactData { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<TicketFlight> TicketFlights { get; set; } = new List<TicketFlight>();
}
