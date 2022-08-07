using ShopManagement.Configuration;


var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("SqlServer");

ShopManagementBootstraper.Configure(builder.Services, conectionString);


// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapDefaultControllerRoute();
});

//app.MapRazorPages();

app.Run();
