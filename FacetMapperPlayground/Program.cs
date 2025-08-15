using Facet.Extensions;
using FacetMapperPlayground;
using Microsoft.EntityFrameworkCore;

// single item
var employee = new Employee
{
    Id = 1,
    Name = "John Doe",
    Age = 30,
    BirthDate = new DateTime(1993, 5, 15),
    Address = "123 Main St, Anytown, USA"
};

var _employeeDTO = employee.ToFacet<Employee, EmployeeDTO>();


// in memory list
var employees = Enumerable.Range(1, 5).Select(i => new Employee
{
    Id = i,
    Name = $"Employee {i}",
    Age = 25 + i * 2,
    BirthDate = DateTime.Now.AddYears(-(25 + i * 2)),
    Address = $"{100 + i * 50} Street {i}, City {i}"
});

var employeeList = employees.Select(EmployeeDTO.Projection.Compile()).ToList();

// database
var options = new DbContextOptionsBuilder<EmployeeDBContext>()
           .UseInMemoryDatabase("EmployeeDb")
           .Options;

using var context = new EmployeeDBContext(options);
context.Employees.AddRange(
    new Employee { Id = 1, Name = "Alice Johnson", Age = 28, BirthDate = new DateTime(1995, 3, 12), Address = "456 Oak Ave, Springfield" },
    new Employee { Id = 2, Name = "Bob Smith", Age = 35, BirthDate = new DateTime(1988, 8, 23), Address = "789 Pine St, Riverside" },
    new Employee { Id = 3, Name = "Carol Davis", Age = 42, BirthDate = new DateTime(1981, 11, 7), Address = "321 Elm Dr, Lakeside" }
);
context.SaveChanges();

var employeeListFromDB = context.Employees.Select(EmployeeDTO.Projection).ToList();

Console.WriteLine("End!!!");