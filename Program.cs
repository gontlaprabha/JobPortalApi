var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();//Add services for controllers to the dependency injection container, enabling the application to handle HTTP requests and responses.

var app = builder.Build();//Build the application and configure the HTTP request pipeline.

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();//Enforces HTTPS by redirecting HTTP requests to HTTPS.

app.UseAuthorization();

app.MapControllers(); //Map controller actions to endpoints [Route("api/[controller]")] to http://localhost:5000/api/[controller]/[action]

app.Run();//run the application and listen for incoming HTTP requests on the configured URL and port.