using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext;
using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.MIddlewares;
using StructureOfProject.Services;

Log.Logger = new LoggerConfiguration()
            .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddScoped<IPeopleService, PeopleService>();
   // builder.Services.AddScoped<IPeopleService, PeopleApiService>();

    builder.Services.AddScoped<IPeopleRepositories, PeopleRepositories>();

    builder.Services.AddScoped<PeopleApiService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSerilogRequestLogging(//configure =>
    
       // configure.MessageTemplate = "HTTP Hello {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000}ms";
    );

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<HttpInformationMiddleware>();
    app.UseMiddleware<GlobalExceptionErrorHandlingMiddleWare>();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();

    Log.CloseAndFlush();

