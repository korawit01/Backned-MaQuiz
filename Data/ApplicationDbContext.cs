using Microsoft.EntityFrameworkCore;
using QuizSystemAPI.Models; // นำเข้า namespace ของ Quiz

namespace QuizSystemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        // รวม DbSet อื่นๆ ที่คุณต้องการ

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // modelBuilder.Entity<Answer>()
            // .HasOne(a => a.Question)
            // .WithMany(q => q.Answers)
            // .HasForeignKey(a => a.QuestionId)
            // .OnDelete(DeleteBehavior.Cascade); 
            base.OnModelCreating(modelBuilder);
            // กำหนดการสร้างโมเดลเพิ่มเติมถ้าจำเป็น
        }
    }
}
