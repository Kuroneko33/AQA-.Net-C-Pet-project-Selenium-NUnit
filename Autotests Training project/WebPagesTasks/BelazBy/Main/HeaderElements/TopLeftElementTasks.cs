using System;

namespace Autotests_Training_project.WebPagesTasks.BelazBy.Main.HeaderElements
{
    using WebPages.BelazBy.Main.Elements.HeaderElements;
    using WebPages;
    using TopLeftElements;

    public class TopLeftElementTasks : ElementTasks<TopLeftElement>
    {
        public TopLeftElementTasks(TopLeftElement element) : base(element) { }


        private TopMenuElementTasks topMenu;
        public TopMenuElementTasks TopMenu =>
            topMenu ??= new TopMenuElementTasks(_element.TopMenu);
    }
}
