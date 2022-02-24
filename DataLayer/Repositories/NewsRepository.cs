using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class NewsRepository
    {
        NewsDbContext _ctx;
        public NewsRepository(NewsDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<News> GetLastSixNews()
        {
            return _ctx.News.OrderByDescending(c => c.PublishDate).Take(6).ToList();
        }

        public News GetNewsById(int id)
        {
            return _ctx.News.FirstOrDefault(c => c.NewsId == id);
        }

        public void AddOrUpdateNews(News news)
        {
            if (news.NewsId <= 0)
            {
                _ctx.News.Add(news);
            }
            else
            {
                News updated = GetNewsById(news.NewsId);
                updated.NewsTitle = news.NewsTitle;
                updated.Content = news.Content;
                updated.CategoryId = news.CategoryId;
            }
            _ctx.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            News news = GetNewsById(id);
            _ctx.News.Remove(news);
            _ctx.SaveChanges();
        }
    }
}
