using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class IndexPageSection
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public List<IndexPageSection> GetPlaceInIndex()
        {
            var model = new List<IndexPageSection>
            {
                new IndexPageSection {ID = 1,Title = "اسلایدر"},
                new IndexPageSection {ID = 2,Title = "اخبار ویژه"},
                new IndexPageSection {ID = 4,Title = "آخرین ویدیوها"},
            };
            return model;
        }
    }


    //public class IndexModel
    //{
    //    public List<News> SliderNews { get; set; }
    //    public List<News> SpecialNews { get; set; }
    //    public List<News> LastVideo { get; set; }

    //    public List<News> LastNews { get; set; }
    //    public List<News> InNews { get; set; }
    //    public List<News> OutNews { get; set; }
    //    public List<News> PrivateNews { get; set; }
    //    public News NewsDetails { get; set; }
    //    public LoginViewModel loginVM { get; set; }
    //    public List<Advertise> Adv { get; set; }
    //    public Poll PollModel { get; set; }

    //    public List<News> searchmodel { get; set; }

    //}
}
