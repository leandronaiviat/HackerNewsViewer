using System.Collections.Generic;

namespace HackerNewsWPFMVVM
{
    public class AskModel
    {
        public string By { get; set; }      //AskModel, StoryModel, CommentModel
        public int Descendants { get; set; }//AskModel, StoryModel
        public int Id { get; set; }         //AskModel, StoryModel, CommentModel
        public List<int> Kids { get; set; } //AskModel, StoryModel, CommentModel
        public int Score { get; set; }      //AskModel, StoryModel
        public int Time { get; set; }       //AskModel, StoryModel, CommentModel
        public string Title { get; set; }   //AskModel, StoryModel
        public string Text { get; set; }    //AskModel, CommentModel
        public string Type { get; set; }    //AskModel, StoryModel, CommentModel
        public string Url { get; set; }     //AskModel, StoryModel, CommentModel
    }
}
