using KKOK_WEB.CommHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
//builder.WebHost.UseUrls();  //주소 설정

// 외부 접속 추가
// 관련 자료 : https://www.sysnet.pe.kr/2/0/12081
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{ serverOptions.ListenAnyIP(5029); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<CommHub_Base>("/hubbase");  // 허브 주소 추가
app.MapHub<CommHub_Member>("/memberhub");
app.MapHub<CommHub_Project>("/projecthub");

app.Run();
