using Facet;

namespace FacetMapperPlayground;

public class Facets
{
    [Facet(sourceType: typeof(Employee),
        exclude: [nameof(Employee.Age), nameof(Employee.BirthDate), nameof(Employee.Address)],
        Configuration = typeof(EmployeeMapConfig))]
    public partial class EmployeeDTO
    {
    }
}

