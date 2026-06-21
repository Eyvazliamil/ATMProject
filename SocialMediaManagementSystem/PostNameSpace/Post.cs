using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagementSystem.PostNameSpace
{
    internal class Post
    {
        private Guid _id { get; set; }
        private string _content { get; set; }
        private DateTime _creationDateTime { get; set; }
        private long _likeCount { get; set; }
        private long _viewCount { get; set; }

        public Post() { }
        public Post(Guid id, string content, DateTime creationDateTime, long likeCount, long viewCount)
        {
            _id = id;
            _content = content;
            _creationDateTime = creationDateTime;
            _likeCount = likeCount;
            _viewCount = viewCount;
        }

        public void setContent(string content) => _content = content;  
        public void setLikeCount(long like) => _likeCount = like;
        public void setViewCount(long view) => _viewCount = view;

        public Guid getId() => _id;
        public string getContent() => _content;
        public DateTime getCreationDateTime() => _creationDateTime;
        public long getLikeCount() => _likeCount;
        public long getViewCount() => _viewCount;

        public void AddLike()
        {
            _likeCount++;
        }

        public void AddView()
        {
            _viewCount++;
        }
    }
}
