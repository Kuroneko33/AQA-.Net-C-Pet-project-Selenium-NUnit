using System;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Search
{
    using WebPages.GitHub.Main.Search;

    public class SearchResult_UsersElementTasks : ElementTasks_IDisplayable<SearchResult_UserElement>
    {
        public SearchResult_UsersElementTasks(SearchResult_UserElement element, Action display) : base(element, display) { }


        public string UserId
        {
            get
            {
                _stateSetUp();
                return _element.UserId.Text;
            }
        }
    }
}
