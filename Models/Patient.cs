using System;
using System.ComponentModel.DataAnnotations;
namespace ProjectJunior.Models
{
	public class Patient
	{
		public int Id { get; set; }
        	[Required]
        	public string? Name { get; set; }
        	[Required]
        	public string? Surname { get; set; }
        	[Required]
        	public int Age { get; set; }
        	[Required]
        	public string? MainDiagnosis { get; set; }
		public string? SubDiagnosis { get; set; }
        	[Required]
        	public bool IsPrivilege { get; set; }
	}
}

