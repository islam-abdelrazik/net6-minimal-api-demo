var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HelloService>(new HelloService());

var app = builder.Build();

app.MapGet("/", () => new HelloService().SayHello("Omar Islam"));
app.MapGet("/GetById/{id}", async (http) =>
{
    if (!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = StatusCodes.Status404NotFound;
        return;
    }
    Customer customer = new ("dd","ddd");;
    http.Response.StatusCode = StatusCodes.Status200OK;
    await http.Response.WriteAsJsonAsync(customer);
});

app.MapPost("/add", (Customer customer) =>
{
    Customer newCustomer =
    customer with { Address = "new Address" };
    return newCustomer;
});
app.Run();
