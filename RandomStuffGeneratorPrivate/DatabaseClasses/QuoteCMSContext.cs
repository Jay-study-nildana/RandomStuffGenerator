using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomStuffGeneratorPrivate.DatabaseClasses
{
    public class QuoteCMSContext : DbContext
    {

        public QuoteCMSContext(DbContextOptions<QuoteCMSContext> options)
            : base(options)
        {

        }
        //lets add the Quote Table to the Context
        public DbSet<QuoteModel> QuoteModels { get; set; }
        //lets add QuoteHistoryModel to the Context
        public DbSet<QuoteHistoryModel> QuoteHistoryModels { get; set; }

        //below, some old boilerplate code
        //I am just keeping here for reference 

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=blogging.db");

        //database context 
        //services.AddDbContext<APIServerDbContext>(options =>
        //            options.UseSqlServer(Configuration.GetConnectionString("APIServerDatabase")));

        ////database context 
        ////services.AddDbContext<BloggingContext>(options =>
        ////            options.UseSqlite("Data Source=blogging.db");
    }

    //below, some old boilerplate code
    //I am just keeping here for reference 

    //public class Blog
    //{
    //    public int BlogId { get; set; }
    //    public string Url { get; set; }

    //    public List<Post> Posts { get; } = new List<Post>();
    //}

    //public class Post
    //{
    //    public int PostId { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }

    //    public int BlogId { get; set; }
    //    public Blog Blog { get; set; }
    //}
}
