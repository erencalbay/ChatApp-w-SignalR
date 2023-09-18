using SignalRChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>policy
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(x => true)));

builder.Services.AddSignalR();

app.MapGet("/", () => "Hello World!");
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chathub");
});

app.Run();
