var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var products = new List<Product>
{
    new Product("Laptop", 500),
    new Product("Mouse", 20),
    new Product("Keyboard", 50)
};

app.MapGet("/products", () =>
{
    return Results.Ok(products);
});

app.MapGet("/hello", () =>
{
    var response = new {Message = "This is json object",
    Success = true};
    return Results.Ok(response);
});

app.MapGet("/html", () =>
{
    return Results.Content("<h1>Hello World</h1>", "text/html");
});

app.Run();

public record Product(string Name, decimal Price);
