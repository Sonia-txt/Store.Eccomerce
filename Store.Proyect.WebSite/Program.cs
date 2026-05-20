using Store.Proyect.WebSite.Services;
using Store.Proyect.WebSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleDetailService, SaleDetailService>();

// Configurar HttpClient ignorando los errores de certificados SSL locales
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7141/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // Este truco hace que acepte cualquier certificado local sin tronar
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
});
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

app.MapBlazorHub();
app.MapFallbackToPage("/Index");

app.Run();