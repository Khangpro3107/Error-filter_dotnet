using DI.Filters;
using ErrorHandling.Filters;
using ErrorHandling.Middlewares;
using ErrorHandling.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<CustomMiddleware>();
builder.Services.AddSingleton<LogService>();
builder.Services.AddScoped<MyExceptionHandlingMiddleware>();

// demo-ing multiple types of filters
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<CustomAuthorizationFilter>();
//    options.Filters.Add<CustomResourceFilter>();
//    options.Filters.Add<CustomActionFilter>();
//    options.Filters.Add<CustomExceptionFilter>();
//    options.Filters.Add<CustomResultFilter>();
//});

// demo-ing a filter that can be used as an attribute; it is also at the global scope
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalFilterAttribute>();
    options.Filters.Add<CustomResourceFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    // using a custom error handling page
    //app.UseExceptionHandler("/CustomException");
    
    // using a middleware to handle errors
    //app.UseExceptionHandler(app =>
    //{
    //    app.Run(async context =>
    //    {
    //        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
    //        await context.Response.WriteAsync("Lambda handler");
    //    });
    //});
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// global middleware for error handling
//app.UseMiddleware<MyExceptionHandlingMiddleware>();

// a random middleware
app.UseMiddleware<CustomMiddleware>();

app.MapControllers();

app.Run();
