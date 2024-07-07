var builder = DistributedApplication.CreateBuilder(args);

// var usernameStr = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "username";
// var passwordStr = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "password";

// var username = builder.AddParameter("usernameStr", secret: true);
// var password = builder.AddParameter("passwordStr", secret: true);

Environment.SetEnvironmentVariable("CONNECTION_STRING", "db1");

var db1 =
        builder
           .AddPostgres("postgres-server",
                        password: ParameterExtensions.CreateStablePassword(builder, "postgrespassword"))
           .WithDataVolume()
           .AddDatabase(Environment.GetEnvironmentVariable("CONNECTION_STRING")!)
    ;

var api =
        builder
           .AddProject<Projects.ApiService>("api-service")
           .WithReference(db1)
    ;

// migration
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
   .AddProject<Projects.Web>("web-frontend")
   .WithExternalHttpEndpoints()
   .WithReference(api)
    ;

builder.Build().Run();