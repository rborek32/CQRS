using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CQRS.Model;

public class Employee
{
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("hire_date")]
    public DateTime? HireDate { get; set; }
    [Column("hourly_rate")]
    public decimal? HourlyRate { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }  
}