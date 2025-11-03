using TestApi.Users.Services;

var builder = WebApplication.CreateBuilder(args);

_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen();

_ = builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

_ = app.MapGet("/users", async (IUserService userService) => await userService.GetAllUsersAsync());
_ = app.MapGet("/users/{id:guid}", async (Guid id, IUserService userService) => await userService.GetUserByIdAsync(id));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

_ = app.UseHttpsRedirection();

app.Run();
