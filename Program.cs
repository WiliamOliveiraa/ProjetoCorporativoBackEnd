using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<NotificacaoService>();


builder.Services.AddControllers();


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();


var notificacaoService = app.Services.CreateScope().ServiceProvider.GetRequiredService<NotificacaoService>();
var timer = new System.Threading.Timer(async _ => await notificacaoService.EnviarNotificacoesAsync(), null, TimeSpan.Zero, TimeSpan.FromDays(1));

app.Run();
