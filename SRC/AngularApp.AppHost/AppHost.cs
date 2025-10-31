var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Angular_EndPoint_WebApi>("angular-endpoint-webapi");

builder.Build().Run();
