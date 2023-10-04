
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const string InvalidCommentError = "Content must be between {0} and {1} characters long!";
        
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;

        private string content;
        private string author;

        public Comment(string content, string author)
        {
            this.Content = content;
            this.Author = author;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            init
            {
                this.ValidateComment(value);
                this.content = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            init
            {
                this.author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{content}");
            output.Append($"User: {this.Author}");

            return output.ToString();
        }

        private void ValidateComment(string content)
        {
            Validator.ValidateStringNullOrEmpty(content, nameof(this.Content));

            Validator.ValidateIntRange(content.Length, CommentMinLength, CommentMaxLength,
                string.Format(InvalidCommentError, CommentMinLength, CommentMaxLength));
        }
    }
}
