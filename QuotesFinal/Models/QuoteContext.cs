using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesFinal.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<QuoteResponse> responses { get; set; }

        //public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<QuoteResponse>().HasData(

                new QuoteResponse
                {
                    QuoteId = 1,
                    Author = "Kanye West",
                    Quote = "You can't look at a glass half full or empty if it's overflowing",
                    Date = "Jan 16, 2018",
                    Subject = "Perspective",
                    Citation = "Twitter"
                },

                new QuoteResponse
                {
                    QuoteId = 2,
                    Author = "Elon Musk",
                    Quote = "69.420% of statistics are false",
                    Date = "Apr 9, 2022",
                    Subject = "Satire",
                    Citation = "Twitter",
                },

                new QuoteResponse
                {
                    QuoteId = 3,
                    Author = "Abraham Lincoln",
                    Quote = "Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal.",
                    Date = "Nov 19, 1863",
                    Subject = "History",
                    Citation = "Gettysburg Address",
                }

            );
        }
    }
}