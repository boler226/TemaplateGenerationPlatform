using Microsoft.EntityFrameworkCore;
using TemaplateGenerationPlatform.Application.Commands.CreateTemplate;
using TemaplateGenerationPlatform.Application.Mappings;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;
using TemaplateGenerationPlatform.Infrastructure.DbContext;
using TemaplateGenerationPlatform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<TemplateEntity>, TemplateRepository>();

builder.Services.AddAutoMapper(typeof(TemplateMappingProfile).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateTemplateCommandHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
