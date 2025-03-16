[Back to README](../README.md)
## Project Configuration

### Prerequisites

Ensure you have the following installed on your machine:
- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Setting Up .NET SDK 8.0

1. Visit the [.NET SDK download page](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
2. Download and install the installer for your operating system.

### Restore NuGet Packages

Navigate to the root of the project and run:

```bash
dotnet restore
```

### Running Migrations Locally

1. Navigate to your `DbContext` directory.
2. Execute:

   ```bash
   dotnet ef database update
   ```

### MySQL Configuration

To use a local MySQL configuration, modify `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DeveloperEvaluation;User Id=developer;Password=yourpassword;"
  }
}
```

Adjust `User Id`, `Password`, and other parameters as necessary for your local environment.

### Running Tests

To execute unit and integration tests:

1. Navigate to the project test directory.
2. Run:

   ```bash
   dotnet test
   ```

### Publishing the Project

To publish the project, follow these steps:

1. Navigate to the project directory you wish to publish (typically where the `.csproj` file is located for your main application).
2. Execute the following command, replacing `<OutputFolder>` with your desired output directory:

   ```bash
   dotnet publish -c Release -o <OutputFolder>
   ```

   This will compile the application in Release mode and generate the publish output into the specified folder.

---