using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using QuizSystemAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// เพิ่มการตั้งค่าบริการที่นี่
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// เพิ่มบริการอื่นๆ ที่คุณต้องการ
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// การตั้งค่า pipeline HTTP ที่นี่
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ใช้งาน CORS
app.UseCors("AllowAllOrigins");

// ต้องมีการเรียก UseRouting ก่อน UseEndpoints
app.UseRouting();

// ใช้งาน Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// ต้องมีการเรียก UseAuthorization ก่อน MapControllers
app.UseAuthorization();

// กำหนด Endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// สั่งให้ HTTP Request ใช้ https
app.UseHttpsRedirection();
app.UseStaticFiles();

// เรียก MapControllers ที่นี่เพื่อให้สามารถใช้ได้
app.MapControllers();

app.Run();
