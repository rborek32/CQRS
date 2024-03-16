using CQRS.Data;
using CQRS.Model;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllRecords()
    {
        var records = _context.Employees.ToList();
        return Ok(records);
    }
    
    [HttpPost]
    public IActionResult InitializeDatabase()
    {
        _context.Employees.AddRange(new Employee[]
        {
            new Employee { FirstName = "Example 1" , LastName = "sure"},
            new Employee { FirstName = "Example 2" , LastName = "sure"}
        });
        _context.SaveChanges();
        return Ok("Database initialized with examples.");
    }
}