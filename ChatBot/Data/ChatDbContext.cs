using Microsoft.EntityFrameworkCore;

namespace ChatBot.Data
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public bool IsUserMessage { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class ChatDbContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
        }
    }
}
