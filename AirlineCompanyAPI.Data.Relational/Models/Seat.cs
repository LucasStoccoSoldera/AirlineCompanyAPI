using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyAPI.Data.Relational.Models;

/// <summary>
/// Seats
/// </summary>
public partial class Seat
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Seat number
    /// </summary>
    [Column("seat_no")]
    public string SeatCode { get; set; } = null!;

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; } = null!;

    public virtual AircraftsDatum AircraftCodeNavigation { get; set; } = null!;
}
