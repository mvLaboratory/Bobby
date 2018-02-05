using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAPI
{
    [Table("RssItem")]
    public class RssItem : INewsItem
    {
        [Column("Id")]
        [Key]
        public Int64 Id { get; set; }

        [Column("PublicationdDate")]
        public DateTime PublicationdDate { get; set; }

        [Column("Title")]
        public String Title { get; set; }

        [Column("Author")]
        public String Author { get; set; }

        [Column("Url")]
        public String Url { get; set; }

        [Column("Category")]
        public Category Category { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public RssItem(long id, DateTime publicationdDate, String title, String author, String url, Category category)
        {
            if (id < 0)
            {
                throw new ArgumentException("id");
            }

            Id = id;
            PublicationdDate = publicationdDate;
            Title = title;
            Author = author;
            Url = url;
            Category = category;
            CreationDate = DateTime.Now;

            _lastId = id;
        }

        public RssItem(DateTime publicationdDate, String title, String author, String url, Category category)
            : this(++_lastId, publicationdDate, title, author, url, category)
        {
        }

        public RssItem(String title, String author, String url, Category category) 
            : this (++_lastId, DateTime.Now, title, author, url, category)
        {
        }

        public RssItem() : this("", "", "", null)
        {

        }

        public override String ToString()
        {
            return Title;
        }

        public override bool Equals(object obj)
        {
            var item = obj as RssItem;
            return item != null &&
                   Id == item.Id &&
                   //PublicationdDate == item.PublicationdDate &&
                   Title == item.Title &&
                   Author == item.Author &&
                   Url == item.Url &&
                   EqualityComparer<Category>.Default.Equals(Category, item.Category);
        }

        public override int GetHashCode()
        {
            var hashCode = -1369838347;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            //hashCode = hashCode * -1521134295 + PublicationdDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Url);
            hashCode = hashCode * -1521134295 + EqualityComparer<Category>.Default.GetHashCode(Category);
            return hashCode;
        }

        private static long _lastId;
    }
}
