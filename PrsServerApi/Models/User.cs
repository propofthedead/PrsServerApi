using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrsServerApi.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		[StringLength(20)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(20)]
		public string LastName { get; set; }
		[Required]
		[StringLength(20)]
		[Index(IsUnique=true)]
		public string UserName { get; set; }
		[Required]
		[StringLength(20)]
		public string Password { get; set; }
		[Required]
		[StringLength(12)]
		public string Phone { get; set; }
		[Required]
		[StringLength(80)]
		public string Email { get; set; }
		[Required]
		public bool IsReviewer { get; set; }
		[Required]
		public bool IsAdmin { get; set; }
		[Required]
		public bool Active { get; set; }

		public User() { }
	}
}