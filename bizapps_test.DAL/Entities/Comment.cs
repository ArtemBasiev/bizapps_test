using System;


namespace bizapps_test.DAL.Entities
{
    public class Comment
    {
        public int Id { get; private set; }
        public string CommentText { get; private set; }
        public string UserName { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int ParentId { get; private set; }

        public Comment(int idComment, string commentText, string userName, DateTime creationDate)
        {
            Id = idComment;
            CommentText = commentText;
            UserName = userName;
            CreationDate = creationDate;
        }


        public Comment(int idComment, string commentText, string userName)
        {
            Id = idComment;
            CommentText = commentText;
            UserName = userName;
        }

        public Comment(int idComment, string commentText, string userName, int parentId)
        {
            Id = idComment;
            CommentText = commentText;
            UserName = userName;
            ParentId = parentId;
        }

        public Comment(string commentText, string userName, DateTime creationDate)
        {
            CommentText = commentText;
            UserName = userName;
            CreationDate = creationDate;
        }


        public Comment(string commentText, string userName)
        {
            CommentText = commentText;
            UserName = userName;
        }


        public Comment(string commentText, string userName, int parentId)
        {
            CommentText = commentText;
            UserName = userName;
            ParentId = parentId;
        }

        public Comment(int idComment, string commentText)
        {
            Id = idComment;
            CommentText = commentText;
        }

        public Comment(int idComment)
        {
            Id = idComment;
        }
    }
}
