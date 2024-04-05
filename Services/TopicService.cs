﻿using Clarity_Crate.Data;
using Clarity_Crate.Models;
using Microsoft.EntityFrameworkCore;

namespace Clarity_Crate.Services
{
    public class TopicService
    {
        private readonly ApplicationDbContext _context;
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public bool isProcessing = false;


        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task GetTopics()
        {
            Topics = await _context.Topic.Include(t => t.Subjects).ToListAsync();

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


        public async Task UpdateTopic(int id, Topic topic)
        {
            Topic topicExists = await _context.Topic.FindAsync(id);
            if (topicExists != null)
            {
                topicExists.Name = topic.Name;
                topicExists.Subjects = topic.Subjects;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTopic(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();
        }
    }
}
