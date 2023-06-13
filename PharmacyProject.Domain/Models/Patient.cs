using System;
namespace PharmacyProject.Domain.Models
{
	public class Patient
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public int Age { get; set; }
		public string? MainDiagnosis { get; set; }
		public string? SubDiagnosis { get; set; }
		public bool IsPrivilege { get; set; }
		public string? Email {get;set;}
		public string? Password { get; set; }
	}
}

