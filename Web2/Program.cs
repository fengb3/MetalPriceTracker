using Masa.Blazor;
using Web2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMasaBlazor(options =>
{
    options.ConfigureIcons(IconSet.FontAwesome6);
});
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpApi<IMetalMetaApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("http+https://api-service/");
    })
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

