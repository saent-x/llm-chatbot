using llm_chatbot.interfaces;
using llm_chatbot.services;
using llm_chatbot.view;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IChatService,ChatService>();
builder.Services.AddSingleton<NotificationService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.cc
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
