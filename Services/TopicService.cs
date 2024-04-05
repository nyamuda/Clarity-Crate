using Clarity_Crate.Data;
using Clarity_Crate.Models;
using Microsoft.EntityFrameworkCore;

namespace Clarity_Crate.Services
{
    public class TopicService
    {
        private readonly ApplicationDbContext _context;
        public bool isProcessing = false;


        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Topic>> GetTopic()
        {
            return await _context.Topic.ToListAsync();
        }

        public async Task<Topic?> GetTopicById(int id)
        {
            return await _context.Topic.FindAsync(id);
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            isProcessing = !isProcessing;
            _context.Topic.Add(topic);
            await _context.SaveChangesAsync();
            isProcessing = !isProcessing;
            return topic;
        }


        public async Task<Topic> UpdateTopic(int id, Topic topic)
        {
            _context.Entry(topic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task DeleteTopic(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();
        }
    }
}
