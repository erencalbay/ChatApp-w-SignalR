using SignalRChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>policy
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(x => true)));

builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //https://localhost:7298/myhub
    endpoints.MapHub<ChatHub>("/myhub");
});

app.Run();
