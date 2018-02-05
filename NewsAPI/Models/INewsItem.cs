using System;

namespace NewsAPI
{
    public interface INewsItem
    {
        Int64 Id { get; set; }
        DateTime PublicationdDate { get; set; }
        String Title { get; set; }
        String Author { get; set; }
        String Url { get; set; }
        Category Category { get; set; }
        DateTime CreationDate { get; set; }
    }
}
