using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


[Table("received_item", Schema = "Team2Part2")]
public class ReceivedItem
{
    public int Id { get; set; }
    public int ShipmentId { get; set; }
    public int PurchaseOrderId { get; set; }
    public int SkuNumber { get; set; }
    public int ActualPricePaid { get; set; }
    public int Qty { get; set; }

}
