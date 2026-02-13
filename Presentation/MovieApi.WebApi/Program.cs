using MovieApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices()
    .AddIdentityServices()
    .AddMediatrServices()
    .AddSwaggerServices();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApi.WebApi V1");
    });
}

//launchSettings.json dosyasýnda bu konu ile alakalý çalýþma zaten yapýldý, ek olarak
//burada bulunmasý adýna eklenmiþtir.
//app.Use(async (context, next) =>
//{
//    if(context.Request.Path == "/")
//    {
//        context.Response.Redirect("/swagger/index.html");
//        return;
//    }
//    await next();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
