var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AngularApp_EndPoint_WebApi>("angularapp-endpoint-webapi");

builder.AddProject<Projects.AngularApp_EndPoint_WebApp>("angularapp-endpoint-webapp");

builder.Build().Run();
