using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyAPI.Data.Relational.Models;

/// <summary>
/// Flight segment
/// </summary>
public partial class TicketFlight
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
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; } = null!;

    /// <summary>
    /// Travel cost
    /// </summary>
    public decimal Amount { get; set; }

    public virtual BoardingPass? BoardingPass { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
