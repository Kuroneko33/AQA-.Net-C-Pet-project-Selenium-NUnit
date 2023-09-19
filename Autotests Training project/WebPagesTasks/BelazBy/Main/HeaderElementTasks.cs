namespace Autotests_Training_project.WebPagesTasks.BelazBy.Main
{
    using WebPages.BelazBy.Main.Elements;
    using WebPages.BelazBy.Main;
    using WebPages;
    using HeaderElements;

    public class HeaderElementTasks : ElementTasks<HeaderElement>
    {
        public HeaderElementTasks(HeaderElement element) : base(element) { }

        private TopLeftElementTasks topLeft;
        public TopLeftElementTasks TopLeft =>
            topLeft ??= new TopLeftElementTasks(_element.TopLeft);

        private TopRightElementTasks topRight;
        public TopRightElementTasks TopRight =>
            topRight ??= new TopRightElementTasks(_element.TopRight);
    }
}
