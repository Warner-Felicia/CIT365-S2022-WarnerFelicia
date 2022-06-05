using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Moses",
                        Chapter = "7",
                        Verse = "29-37",
                        Note = "I love these verses because it shows how much Heavenly Father loves his children and how sad He is when his children hurt and are unkind to each other.",
                        Date = new DateTime(2021, 8, 17, 0, 0, 0)
                    },

                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = "37",
                        Verse = "36-37",
                        Note = "These verses helped me as I was about to move out of the house and live on my own.  They remind me that if I always pray and seek the Lord's counsel, He will not lead me astray.",
                        Date = new DateTime(2022, 5, 27, 0, 0, 0)
                    },

                    new Scripture
                    {
                        Book = "Joshua",
                        Chapter = "1",
                        Verse = "5",
                        Note = "I think Joshua must have been at least a little intimidated by being Moses' successor and I love here how the Lord comforts Joshua.  The Lord is with us in the errands He gives us too and will not fail or forsake us either.",
                        Date = new DateTime(2022, 1, 5, 0, 0, 0)
                    },

                    new Scripture
                    {
                        Book = "Joshua",
                        Chapter = "3",
                        Verse = "5",
                        Note = "This verse immediately made me think of the Mormon Message video with Elder Holland with the football players.  I also love it on another layer because it applies to small things as well as big things.  If we let the Lord guide and lead our lives, He will do wonders, both big and small, with us.",
                        Date = new DateTime(2021, 11, 17, 0, 0, 0)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}