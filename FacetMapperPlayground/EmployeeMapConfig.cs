using Facet.Mapping;

namespace FacetMapperPlayground;

public class EmployeeMapConfig : IFacetMapConfiguration<Employee, EmployeeDTO>
{
    public static void Map(Employee source, EmployeeDTO target)
    {
        target.Name = $"{DateTime.Now.Year} - {source.Name}";
    }
}
