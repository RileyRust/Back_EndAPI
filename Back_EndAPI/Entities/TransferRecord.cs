using Back_EndAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("transfer_record", Schema = "Team2Part2")]
public partial class TransferRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("withdrawal")]
    public bool? Withdrawal { get; set; }

    [Column("deposit")]
    public bool? Deposit { get; set; }

    [Column("qty")]
    public int? Qty { get; set; }

    [Column("receiveditemid")]
    public int? Receiveditemid { get; set; }

    [Column("datetime", TypeName = "timestamp without time zone")]
    public DateTime? Datetime { get; set; }


    [ForeignKey("Receiveditemid")]
    public virtual ReceivedItem? Receiveditem { get; set; }

    [ForeignKey("ShippedItemId")]
    public virtual ShippedItem? ShippedItem { get; set; }

    [ForeignKey("Storagelocationid")]
    public virtual Bin? Storagelocation { get; set; }
}
