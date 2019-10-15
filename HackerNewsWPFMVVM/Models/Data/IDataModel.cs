using System.Collections.Generic;

namespace HackerNewsWPFMVVM.Models.Data
{
    public interface IDataModel
    {
        string By { get; set; }
        int Id { get; set; }
        List<int> Kids { get; set; }
        string Type { get; set; }
        string Url { get; set; }
    }
}