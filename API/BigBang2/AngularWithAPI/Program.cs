using AngularWithAPI.Data;
using AngularWithAPI.Models.DTO;
using AngularWithAPI.Repository.Authorization.Token;
using AngularWithAPI.Repository.Authorization.Userfolder;
using AngularWithAPI.Repository.Authorization.Userloginregister;
using AngularWithAPI.Repository.Tables.AppointmentTable;
using AngularWithAPI.Repository.Tables.DoctorDetailsTable;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DoctorBookingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
builder.Services.AddScoped<IAppointment, AppointmentService>();
builder.Services.AddScoped<IDoctorDetails, DoctorDetailsService>();


builder.Services.AddScoped<DoctorDetailsDTO>();
builder.Services.AddScoped<IUserservice,UserServices>();
builder.Services.AddScoped<IToken, TokenService>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<DoctorDetailsDTO>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });

builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
});




builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AngularCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
