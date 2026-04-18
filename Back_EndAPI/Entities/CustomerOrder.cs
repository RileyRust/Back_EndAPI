using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Entities;


[Table("customer_order", Schema = "Team2Part2")]
public class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("date_ordered")]
    public DateOnly DateOrdered { get; set; }

    [Column("name_ordered")]
    public string NameOrdered { get; set; }

    [Column("customer_shipping_fee")]
    public decimal CustomerShippingFee { get; set; }
}

