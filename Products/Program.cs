var builder = WebApplication.CreateBuilder(args);

var productsContext = builder.Configuration.GetConnectionString("ProductsContext")
    ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.");

builder.Services.AddDbContext<ProductDataContext>(options => options.UseSqlite(productsContext));

var app = builder.Build();

app.MapProductEndpoints();

app.UseStaticFiles();

await app.CreateDbIfNotExistsAsync();

await app.RunAsync();
