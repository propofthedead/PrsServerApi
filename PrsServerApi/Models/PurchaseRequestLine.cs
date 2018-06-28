using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsServerApi.Models
{
	public class PurchaseRequestLine
	{
		public int Id { get; set; }
		[Required]
		public int PurchaseRequestId { get; set; }
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int Quanity { get; set; }
		[Required]
		public decimal Price { get; set; }
		public virtual Product Product { get; set; }
		public virtual PurchaseRequest PurchaseRequest { get; set; }
		public PurchaseRequestLine() { }
	}
}