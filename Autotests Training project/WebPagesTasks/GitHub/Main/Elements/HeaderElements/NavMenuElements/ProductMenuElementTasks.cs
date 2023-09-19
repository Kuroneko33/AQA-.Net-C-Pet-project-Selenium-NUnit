using System;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements.HeaderElements.NavMenuElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements;
    using ProductMenuElements;

    public class ProductMenuElementTasks : ElementTasks_IDisplayable<ProductMenuElement>
    {
        public ProductMenuElementTasks(ProductMenuElement element, Action display) : base(element, display) { }


        private FirstColumnElementTasks firstColumn;
        public FirstColumnElementTasks FirstColumn => firstColumn ??= new FirstColumnElementTasks(_element.FirstColumn, _display);

        private SecondColumnElementTasks secondColumn;
        public SecondColumnElementTasks SecondColumn => secondColumn ??= new SecondColumnElementTasks(_element.SecondColumn, _display);
    }
}
