using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsServerApi.Models
{
	public class PurchaseRequest
	{
		public int Id { get; set; }
		[Required]
		public int UserId { get; set; }
		[Required]
		[StringLength(100)]
		public string Justification { get; set; }
		[Required]
		[StringLength(180)]
		public string Description { get; set; }
		[Required]
		public string DeliveryMode { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public bool Active { get; set; }
		[Required]
		public decimal Total { get; set; }
		[Required]
		[StringLength(250)]
		public string ReasonForRejection { get; set; }
		public virtual User User { get; set; }
		public PurchaseRequest() { }
	}
}