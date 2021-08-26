using System;
using System.Collections.Generic;

namespace FA.JustBlog.WebAPI.ViewModels
{
    public class PostEditViewModels : BasicViewModels
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public Guid CategoryId { get; set; }

        public List<Guid> TagIds { get; set; }
    }
}