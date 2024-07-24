using Microsoft.Extensions.Logging;

var builder = DistributedApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("CONNECTION_STRING_SECTION", "db1");

var db1 =
        builder
           .AddPostgres("postgres-server",
                        password: ParameterExtensions.CreateStablePassword(builder, "postgrespassword"))
           .WithDataVolume()
           .AddDatabase(Environment.GetEnvironmentVariable("CONNECTION_STRING_SECTION")!)
    ;

var api =
        builder
           .AddProject<Projects.ApiService>("api-service")
           .WithReference(db1)
    ;

// migration
 var _ =
        builder
        .AddProject<Projects.DbMigrationService>("migration")
        .WithReference(db1)
            ;

// worker
builder
   .AddProject<Projects.Worker>("worker-service")
   .WithReference(db1)
    ;

// web
builder
   .AddProject<Projects.Web2>("web-frontend")
   .WithExternalHttpEndpoints()
   .WithReference(api)
    ;

builder.Build()
       
       .Run();
