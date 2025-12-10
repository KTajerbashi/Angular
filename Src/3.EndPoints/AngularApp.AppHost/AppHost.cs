var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AngularApp_EndPoint_WebApi>("angularapp-endpoint-webapi");

builder.Build().Run();
