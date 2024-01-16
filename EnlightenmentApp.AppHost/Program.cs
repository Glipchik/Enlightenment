var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.EnlightenmentApp_API>("enlightenmentapp.api");
builder.AddNpmApp("frontend-react", "../EnlightenmentApp.FrontendApp/frontend-react");

builder.Build().Run();
