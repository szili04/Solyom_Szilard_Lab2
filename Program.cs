using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Solyom_Szilard_Lab2;
using Solyom_Szilard_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Solyom_Szilard_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Solyom_Szilard_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Solyom_Szilard_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Solyom_Szilard_Lab2Context")
        ?? throw new InvalidOperationException("Connection string 'Solyom_Szilard_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();