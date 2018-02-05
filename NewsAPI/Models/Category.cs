using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAPI
{
    [Table("Category")]
    public class Category : ICategory
    {
        [Column("Id")]
        [Key]
        public Int64 Id { get; set; }

        [Column("Name")]
        public String Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Column("RssURL")]
        public String RssURL {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public Category(Int64 id, String name, String url, DateTime creationDate)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            //Id = id;
            Name = name;
            RssURL = url;
            //CreationDate = creationDate;

            _lastId = id;
        }

        public Category(Int64 id, String name, String url) : this(++_lastId, name, url, DateTime.Now)
        {
        }

        public Category(String name, String url) :this (++_lastId, name, url)
        {

        }

        public Category() : this(++_lastId, "", "")
        {

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null &&
                   //Id == category.Id &&
                   Name == category.Name &&
                   RssURL == category.RssURL;
        }

        public override int GetHashCode()
        {
            var hashCode = 1169894586;
            //hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RssURL);
            return hashCode;
        }

        private static long _lastId;
        private String _name;
        private String _url;
    }
}
