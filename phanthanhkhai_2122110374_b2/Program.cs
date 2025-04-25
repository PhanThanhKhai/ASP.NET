using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using phanthanhkhai_2122110374_b2.Data;
using phanthanhkhai_2122110374_b2.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ DbContext để kết nối với cơ sở dữ liệu SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm AutoMapper vào DI container
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Thêm dịch vụ controllers (API controllers)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Cấu hình Swagger để hiển thị tài liệu API và hỗ trợ Bearer Token
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MyShop API",
        Version = "v1"
    });

    // Cấu hình Bearer Token cho Swagger UI
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Nhập token vào ô bên dưới. Ví dụ: Bearer <token>",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Cấu hình xác thực JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Thêm cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // URL của frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Sử dụng chính sách CORS
app.UseCors("AllowFrontend");

// Cấu hình pipeline xử lý HTTP request
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Hiển thị Swagger UI
    app.UseSwaggerUI();  // Cung cấp giao diện người dùng Swagger
}

app.UseHttpsRedirection();  // Chuyển hướng tất cả HTTP request sang HTTPS

app.UseAuthentication();  // Sử dụng middleware xác thực JWT
app.UseAuthorization();  // Sử dụng middleware phân quyền

app.MapControllers();  // Định nghĩa các route cho controller

app.Run();  // Chạy ứng dụng
