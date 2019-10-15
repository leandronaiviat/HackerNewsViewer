using System.Collections.Generic;

namespace HackerNewsWPFMVVM.Models.Data
{
    public class GetCommentsResponse
    {
        public CommentModel Comment { get; set; }
        public int TopCommentId { get; set; }
    }
}
