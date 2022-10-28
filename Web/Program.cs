using Application.Data;
using Application.TMS;
using Web.Dependencies;

var builder = WebApplication.CreateBuilder(args);

//DBDependencies.RegisterInMemory(builder.Services);
DBDependencies.Register(builder.Services, builder.Configuration);
IdentityDependencies.Register(builder.Services);
ConfigurationDependencies.RegisterAll(builder.Services,builder.Configuration);
ApplicationDependencies.Register(builder.Services);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(typeof(RegisterProfileMapping));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();
var app = builder.Build();
await DatabaseSeeder.Seed(builder.Services);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   // app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();

