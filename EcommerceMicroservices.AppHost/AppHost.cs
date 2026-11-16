var builder = DistributedApplication.CreateBuilder(args);

// 1. Run SQL Server in Docker with persistent storage




var sqlPassword = builder.AddParameter("sql-password", secret: true);

var sqlServer = builder.AddSqlServer("sqlserver", password: sqlPassword, port: 14330)
                       .WithDataVolume();


// 2. Create a dedicated database for the Customer microservice
var customerDb = sqlServer.AddDatabase("customerdb");

// 3. Register CustomerWebApi and pass the database connection
var customerApi = builder.AddProject<Projects.CustomerWebApi>("customer-api")
                         .WithReference(customerDb)
                         .WaitFor(customerDb);

builder.Build().Run();

