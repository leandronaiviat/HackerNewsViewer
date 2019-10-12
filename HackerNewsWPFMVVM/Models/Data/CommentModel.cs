using System.Collections.Generic;

namespace HackerNewsWPFMVVM.Models.Data
{
    public class CommentModel
    {
        public string By { get; set; }      //AskModel, StoryModel, CommentModel
        public int Id { get; set; }         //AskModel, StoryModel, CommentModel
        public List<int> Kids { get; set; } //AskModel, StoryModel, CommentModel
        public int Time { get; set; }       //AskModel, StoryModel, CommentModel
        public int Parent { get; set; }     //CommentModel
        public string Text { get; set; }    //AskModel, CommentModel
        public string Type { get; set; }    //AskModel, StoryModel, CommentModel
        public string Url { get; set; }     //AskModel, StoryModel, CommentModel
        public int Level { get; set; }
    }
}
