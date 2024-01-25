using Projects;

var builder = DistributedApplication.CreateBuilder(args);



var enlightenmentApi = builder.AddProject<EnlightenmentApp_API>("enlightenment_api");

builder.AddNpmApp("frontend_react", "../EnlightenmentApp.FrontendApp/frontend-react")
    .WithReference(enlightenmentApi)
    .WithServiceBinding(hostPort:3000, scheme: "http", env: "PORT");


builder.Build().Run();
