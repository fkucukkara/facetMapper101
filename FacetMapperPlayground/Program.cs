using Facet.Extensions;
using FacetMapperPlayground;

var employee = new Employee
{
    Id = 1,
    Name = "John Doe",
    Age = 30,
    BirthDate = new DateTime(1993, 5, 15),
    Address = "123 Main St, Anytown, USA"
};

var _employeeDTO = employee.ToFacet<Employee, EmployeeDTO>();


Console.WriteLine("OK");