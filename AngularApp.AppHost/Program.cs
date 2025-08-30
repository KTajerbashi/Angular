var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Angular_EndPoint_WebApp_Server>("angular-endpoint-webapp-server");

builder.Build().Run();
