## 1. Views
    - To enable controller with view go to program.cs and add service

### Configure
```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//Enable controllers with views
var app = builder.Build();

app.UseStaticFiles();
//app.UseRouting();
app.MapControllers();

app.Run();
```