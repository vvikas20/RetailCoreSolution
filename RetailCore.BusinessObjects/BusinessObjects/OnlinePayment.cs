using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public partial class OnlinePayment
{
    public Guid OnlinePaymentId { get; set; }

    public Guid? OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string? TransactionStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Order? Order { get; set; }
}
