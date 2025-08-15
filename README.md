# FacetMapperPlayground

A demonstration project showcasing the capabilities of the [Facet](https://github.com/Tim-Maes/Facet) library, a powerful C# source generator for creating compile-time projections and mappings with zero runtime overhead.

## 🎯 What is this project?

This playground demonstrates how to use Facet to create lightweight projections (DTOs) from domain models without writing boilerplate code. Facet generates everything at compile time, providing strong typing with no performance cost.

## 💎 What is Facet?

Facet is a C# source generator that allows you to define focused views of larger models at compile time. Instead of manually writing separate DTOs, mappers, and projections, Facet lets you declare what you want to keep and generates everything else automatically.

## 🚀 Features Demonstrated

This project showcases:

- ✅ **Basic Faceting**: Creating DTOs by excluding unwanted properties
- ✅ **Custom Mapping**: Implementing custom transformation logic
- ✅ **Compile-time Generation**: Zero runtime overhead with source generation
- ✅ **Strong Typing**: Full IntelliSense support for generated code

## 📁 Project Structure

```
FacetMapperPlayground/
├── Employee.cs              # Domain model (source)
├── Facets.cs               # Facet definitions and configurations
├── EmployeeMapConfig.cs    # Custom mapping configuration
├── Program.cs              # Main program demonstrating usage
└── FacetMapperPlayground.csproj  # Project file with Facet packages
```

## 🔧 Prerequisites

- .NET 9.0 or higher
- Visual Studio 2022 or JetBrains Rider (for best IntelliSense experience)

## 📦 NuGet Packages Used

```xml
<PackageReference Include="Facet" Version="2.0.1" />
<PackageReference Include="Facet.Extensions" Version="2.0.1" />
<PackageReference Include="Facet.Mapping" Version="2.0.1" />
```

## 🏃‍♂️ Running the Project

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd FacetMapperPlayground
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run --project FacetMapperPlayground
   ```

## 📚 Code Walkthrough

### 1. Domain Model (`Employee.cs`)

```csharp
public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Address { get; set; }
}
```

### 2. Facet Definition (`Facets.cs`)

```csharp
[Facet(sourceType: typeof(Employee),
    exclude: [nameof(Employee.Age), nameof(Employee.BirthDate), nameof(Employee.Address)],
    Configuration = typeof(EmployeeMapConfig))]
public partial class EmployeeDTO
{
}
```

**What happens here:**
- Creates an `EmployeeDTO` that includes only `Id` and `Name` properties
- Excludes `Age`, `BirthDate`, and `Address` from the generated DTO
- Uses custom mapping configuration for transformation logic

### 3. Custom Mapping (`EmployeeMapConfig.cs`)

```csharp
public class EmployeeMapConfig : IFacetMapConfiguration<Employee, EmployeeDTO>
{
    public static void Map(Employee source, EmployeeDTO target)
    {
        target.Name = $"{DateTime.Now.Year} - {source.Name}";
    }
}
```

**What happens here:**
- Implements custom transformation logic
- Prefixes the employee name with the current year
- Demonstrates how to modify property values during mapping

### 4. Usage (`Program.cs`)

```csharp
var employee = new Employee
{
    Id = 1,
    Name = "John Doe",
    Age = 30,
    BirthDate = new DateTime(1993, 5, 15),
    Address = "123 Main St, Anytown, USA"
};

var employeeDTO = employee.ToFacet<Employee, EmployeeDTO>();
```

## 🎓 What You'll Learn

By exploring this project, you'll understand:

1. **How to define Facets** using the `[Facet]` attribute
2. **Property exclusion** to create focused projections
3. **Custom mapping configurations** for complex transformations
4. **Compile-time code generation** benefits
5. **Extension methods** for easy mapping (`ToFacet<T, TTarget>()`)

## 🔍 Generated Code

Facet generates code similar to this behind the scenes:

```csharp
public partial class EmployeeDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public EmployeeDTO() { }
    
    public EmployeeDTO(Employee source)
    {
        Id = source.Id;
        // Custom mapping applied here
        EmployeeMapConfig.Map(source, this);
    }
}
```

## 🌟 Benefits Demonstrated

- **🚀 Performance**: Zero runtime overhead - everything is generated at compile time
- **🎯 Focus**: Create DTOs with only the properties you need
- **🔒 Type Safety**: Full compile-time checking and IntelliSense support
- **🔄 DRY Principle**: No duplicate property definitions between models and DTOs
- **⚡ Easy Mapping**: Simple extension methods for object transformation

## 📖 Further Reading

- [Facet GitHub Repository](https://github.com/Tim-Maes/Facet)
- [Facet Documentation](https://github.com/Tim-Maes/Facet/blob/master/docs/README.md)
- [What is being generated?](https://github.com/Tim-Maes/Facet/blob/master/docs/07_WhatIsBeingGenerated.md)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
