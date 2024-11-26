var builder = DistributedApplication.CreateBuilder(args);

//var stateStore = builder.AddDaprStateStore("statestore");
var orderChannel = builder.AddDaprPubSub("order");

builder.AddProject<Projects.PrimaryService>("primaryservice")
    .WithReference(orderChannel)
    //.WithReference(stateStore)
    .WithDaprSidecar();

builder.AddProject<Projects.SecondaryService>("secondaryservice")
    .WithReference(orderChannel)
    //.WithReference(stateStore)
    .WithDaprSidecar();

builder.Build().Run();
