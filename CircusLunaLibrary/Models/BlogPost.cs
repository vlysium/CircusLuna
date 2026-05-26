using System;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents an individual blog entry or promotional article for the circus.
    /// Tracks editorial content, release dates, and automatically generates short unique identifiers.
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Gets or sets the unique alphanumeric identifier for the blog post.
        /// Generated automatically during object construction.
        /// </summary>
        public string BlogPostID { get; set; }

        /// <summary>
        /// Gets or sets the headline or title of the blog post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the main body text or editorial narrative of the article.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the publication or creation timestamp for the article.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class with explicit text parameters.
        /// Automatically derives an 8-character string token identity using a truncated <see cref="Guid"/>.
        /// </summary>
        /// <param name="title">The headline or title of the blog post.</param>
        /// <param name="content">The main body text or editorial narrative of the article.</param>
        /// <param name="date">The publication or creation timestamp for the article.</param>
        public BlogPost(string title, string content, DateTime date)
        {
            BlogPostID = Guid.NewGuid().ToString().Substring(0, 8);
            Title = title;
            Content = content;
            Date = date;
        }

        /// <summary>
        /// Returns a formatted string summary combining the publishing timestamp, title, and body content text.
        /// </summary>
        /// <returns>A multiline text string optimized for console or log diagnostics.</returns>
        public override string ToString()
        {
            return $"{Date} {Title}\n{Content}";
        }
    }
}