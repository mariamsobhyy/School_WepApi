using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School_WepApi.Data;
using School_WepApi.Mappers;
using School_WepApi.Models;
using School_WepApi.REPOs.Implementations;
using School_WepApi.REPOs.Intarfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));


builder.Services.AddScoped<IGenaricRepo<Teacher> , GenaricRepo<Teacher>>();
builder.Services.AddScoped<IGenaricRepo<ClassRoom> , GenaricRepo<ClassRoom>>();
builder.Services.AddScoped<IGenaricRepo<Department> , GenaricRepo<Department>>();
builder.Services.AddScoped<IGenaricRepo<Enrollment> , GenaricRepo<Enrollment>>();
builder.Services.AddScoped<IGenaricRepo<Student> , GenaricRepo<Student>>();
builder.Services.AddScoped<IGenaricRepo<Subject> , GenaricRepo<Subject>>();




builder.Services.AddScoped<ITeacher, TeacherCustomRepo>();
builder.Services.AddScoped<IClassroom, ClassroomCustomRepo>();
builder.Services.AddScoped<IDepartment, DepartmentCustomRepo>();
builder.Services.AddScoped<IEnrollment, EnrollmentCustomRepo>();
builder.Services.AddScoped<IStudent, StudentCustomRepo>();
builder.Services.AddScoped<Isubject, SubjectCustomRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
