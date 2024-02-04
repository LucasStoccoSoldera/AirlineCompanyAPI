using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyAPI.Data.Relational.Models;

/// <summary>
/// Boarding passes
/// </summary>
public partial class BoardingPass
{
    /// <summary>
    /// Ticket number
    /// </summary>
    [Column("ticket_no")]
    public string TicketCode { get; set; } = null!;

    /// <summary>
    /// Flight ID
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Boarding pass number
    /// </summary>
    [Column("boarding_no")]
    public int BoardingCode { get; set; }

    /// <summary>
    /// Seat number
    /// </summary>
    [Column("seat_no")]
    public string SeatCode { get; set; } = null!;

    public virtual TicketFlight TicketFlight { get; set; } = null!;
}
