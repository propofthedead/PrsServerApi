using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsServerApi.Models
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public int VendorId { get; set; }
		[Required]
		[StringLength(20)]
		public string Name { get; set; }
		[Required]
		[StringLength(20)]
		public string PartNumber { get; set; }
		[Required]
		[StringLength(200)]
		public string Description { get; set; }
		[Required]
		[StringLength(20)]
		public string Unit { get; set; }
		[Required]
		[StringLength(200)]
		public string PhotoPath { get; set; }
		public bool Active { get; set; }
		public virtual Vendor Vendor { get; set; }
		public Product() { }
	}
}