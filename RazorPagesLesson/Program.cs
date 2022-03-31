using RazorPagesLesson.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = true;
});
// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapRazorPages();

//app.MapGet("/{cmd}", (string cmd) => getPage(cmd));

app.Run();

//string getPage(string c)
//{
//    if (c.ToUpper().Equals("GC"))
//    {
//        Console.WriteLine("command: GC.Collect(); is executing...");
//        GC.Collect();
//    }
        
//    return $"command : {c}";
//}