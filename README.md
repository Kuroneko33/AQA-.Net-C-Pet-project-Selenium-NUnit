# О проекте
Проект является демонстрационным пет-проектом по авто-тестированию веб-сайтов на <a href="https://www.selenium.dev">Selenium</a> + <a href="https://nunit.org">NUnit</a>;
## Цель проекта:
>Отработка и демонстрация навыков работы с технологиями OpenQA.Selenium + NUnit.Framework, практическое применение теории тестирования, а также принципов и шаблонов проектирования для авто-тестирования веб-сайтов.

## Задачи проекта:
>### Создание тестового фреймворка:

>>#### Создание и обработка файлов конфигурации – <a href="#Configurations">Configurations</a>.

>>#### Инициализация и конфигурирование веб-драйвера – <a href="#WebDriverContext.WebDriverBuilder">WebDriverBuilder</a>.

>>#### Расширение функционала Selenium:

>>>Создание безопасного IWebElement, по принципу LazyElements – <a href="#Addons.Selenium.IWebElementSafe">IWebElementSafe</a>.

>>>Создание класса, позволяющего объединять базовые элементы интерфейса Selenium.By в цепочку для получения составного локатора, дополнительно используя элементы интерфейса, предоставляемые – <a href="#Addons.Selenium.ByCssBuilder">ByCssBuilder</a>.

>>>Создание механизма переключения типа локаторов для отработки и демонстрации навыков работы с разными типами локаторов - <a href="#Addons.Selenium.BySwitcher">BySwitcher</a>.

>>#### Расширение функционала NUnit:

>>>Создание и использование константных значений свойств <a href="#Addons.NUnit.Properties">Properties</a>.

>>>Создание и использование кастомных атрибутов <a href="#Addons.NUnit.TestAttributes">TestAttributes</a>.

>>#### Создание абстрактного представления тестируемых страниц <a href="#WebPages.PageObjects">PageObjects</a> и элементов <a href="#WebPages.PageElements">PageElements</a>.

>>#### Создание композиции страниц внутри <a href="#WebPages.PageObjects">PageObjects</a> и <a href="#WebPages.PageElements">PageElements</a>.

>>#### Создание программных интерфейсов взаимодействия с тестируемыми страницами <a href="#WebPagesTasks.PageTasks">PageTasks</a> и элементами <a href="#WebPagesTasks.ElementTasks">ElementTasks</a>.

>>#### Создание композиции программных интерфейсов страниц внутри <a href="#WebPagesTasks.PageTasks">PageTasks</a> и <a href="#WebPagesTasks.ElementTasks">ElementTasks</a>.
<br>

>### Тестирование веб-сайтов:

>>#### Создание тестовых артефактов:

>>>Создание тест планов (для каждого веб-сайта).

>>>Абстрактного представления страниц и элементов, участвующих в тестировании.

>>>Программных интерфейсов взаимодействия с тестируемыми страницами и элементами.

>>>Тестов – тестовых методов.

>>>Тестовых наборов - классов с набором тестовых методов и состоянием.

>>>Тест кейсов - наборов параметров тестовых методов.

>>>Наборов тест кейсов, в том числе генерируемых на основе массива.  

>>> Настройка автоматических отчетов о тестировании.

>>> Составление отчетов о дефектах.

>>>>Исследование и локализация найденных дефектов.

>>>Составление отчетов о тестировании.

>>>>Оценка качества продукта.
<br>

>### Запуск в тест раннере и подключение репортера.
<br>

>### Использование CI/CD



___
## Configurations <a id="Configurations"></a>

>ConfigurationsEnum - перечисление файлов конфигурации.<br>
ConfigurationsEnumExtension - расширение ConfigurationsEnum для чтения файлов конфигурации. 

### Config
>Папка .config файлов

### ConfigEnums
>Перечисления параметров соответствующих файлов конфигурации и расширения для получения их значений.
___
## WebDriverContext <a id="WebDriverContext"></a>
### WebDriverBuilder <a id="WebDriverContext.WebDriverBuilder"></a>
>Класс для инициализации и конфигурирования веб-драйвера.<br>
По умолчанию устанавливает значения из конфигурационных фалов Driver.config, DriverDevTools.config и Proxy.config.<br>
При отсутствии конфигурационных файлов выставляются стандартные значения по умолчанию.

___
## Addons <a id="Addons"></a>
### Selenium <a id="Addons.Selenium"></a>
#### IWebElementSafe <a id="Addons.Selenium.IWebElementSafe"></a>
>Обертка над IWebElement по принципу LazyElements, предоставляющая механизм отложенной инициализации внутреннего IWebElement, а также повторного поиска элемента при изменении его Id.
```C#
//Примеры использования:

IWebElementSafe element = webDriver.FindElementSafe(by);
IList<IWebElementSafe> elementsCollection = webDriver.FindElementsSafe(by);

IWebElementSafe childElement = element.FindElementSafe(by);
IList<IWebElementSafe> childElementsCollection = element.FindElementsSafe(by);
```
#### ByCssBuilder <a id="Addons.Selenium.ByCssBuilder"></a>
>Класс, позволяющий объединять базовые элементы интерфейса Selenium.By в цепочку для получения составного локатора, дополнительно используя элементы интерфейса, предоставляемые ByCssBuilder.
```C#
//Примеры использования:

By by = ByCssBuilder.NewInstance...

ByCssBuilder.NewInstance.TagName("button").ClassName("Button--link").Attribute("aria-label", "Toggle navigation")
implicit converts to By:
By.CssSelector("button.Button--link[aria-label='Toggle navigation']")

ByCssBuilder.NewInstance.TagName("nav").ClassName("menu").Descendant.TagName("a").PartialLinkText(linkText)
implicit converts to By:
By.CssSelector($"nav.menu a[href*='{linkText}']"

ByCssBuilder.NewInstance.Scope.Child.TagName("ul").Child.TagName("li")[index]
implicit converts to By:
By.CssSelector($":scope>ul>li:nth-of-type({index}")
```
#### BySwitcher <a id="Addons.Selenium.BySwitcher"></a>
>Класс, предоставляющий механизм переключения типа локаторов.<br>
Создан специально для отработки и демонстрации навыков работы с разными типами локаторов.<br>

>Не для применения в реальных проектах.<br>
Создает излишнюю громоздкость в классах страниц.<br>
Соответственно без использования BySwitcher классы страниц будет выглядеть намного легче и гармоничнее.
```C#
//Примеры использования:

By by = BySwitcher.SelectFrom(
    ByCssBuilder.NewInstance...,
    By.CssSelector("..."),
    By.XPath("..."));
```
### NUnit <a id="Addons.NUnit"></a>

#### Properties <a id="Addons.NUnit.Properties"></a>
> Categories – строковые константы категорий.<br>
> Reasons – строковые константы причин.

#### TestAttributes <a id="Addons.NUnit.TestAttributes"></a>
>FunctionalTestingLevelAttribute – уровень функционального тестирования.

>PriorityAttribute – приоритет.<br>
>SeverityAttribute – важность.

>SetUpTestSuite – обозначение для тестового набора с предварительной подготовкой состояния.
___
## WebPages <a id="WebPages"></a>
### PageObjects <a id="WebPages.PageObjects"></a>
>Абстрактное представление тестируемой страницы.

>Области ответственности: 

>>Доступ к элементам страницы.

>>Создание композиции страниц и элементов.

>>~~Программный интерфейс взаимодействия со страницей~~<br>
(extracted to <a href="#WebPagesTasks.PageTasks">PageTasks</a>)

>Возможность использования конструктора без параметров:<br>
создание страницы с использованием базового BaseUrl страницы.<br>
При отсутствии IWebDriver происходит инициализация внутренним WebDriverBuilder.

>Возможность использования конструктора с передачей IWebDriver и выбором источника Url между базовым BaseUrl страницы и Url переданного драйвера.

>Возможность использования конструктора с передачей IWebDriver и CustomUrl.

### PageElements <a id="WebPages.PageElements"></a>
>Абстрактное представление элемента страницы, с набором внутренних подэлементов.

>Области ответственности: 

>>Доступ к подэлементам элемента.

>>Создание композиции страниц и элементов.

>>~~Программный интерфейс взаимодействия с элементом~~<br>
(extracted to <a href="#WebPagesTasks.ElementTasks">ElementTasks</a>)

>Возможность использования конструктора с передачей IWebDriver и parentElement: IWebElementSafe.

___
## WebPagesTasks <a id="WebPagesTasks"></a>
### PageTasks <a id="WebPagesTasks.PageTasks"></a>
>Класс, использующий объекты страниц для доступа к элементам и предоставляющий программный интерфейс взаимодействия со страницей, используемый для написания тестов.<br>

>Области ответственности: 

>>Предоставление программного интерфейса взаимодействия со страницей.

>>Создание композиции интерфейсов страниц и элементов.

>Возможность использования конструктора с передачей объекта страницы.


### ElementTasks <a id="WebPagesTasks.ElementTasks"></a>
>Класс, использующий объекты элементов страниц для доступа к подэлементам и предоставляющий программный интерфейс взаимодействия с элементом.<br>

>Области ответственности: 

>>Предоставление программного интерфейса взаимодействия с элементом.

>>Создание композиции интерфейсов страниц и элементов.

>Возможность использования конструктора с передачей элемента страницы.
### ElementTasks_IDisplayable <a id="ElementTasks_IDisplayable"></a>
>Класс, использующий объекты элементов страниц для доступа к подэлементам и предоставляющий Пользовательский интерфейс взаимодействия с элементом, потенциально требующий 
выполнения некоторого действия родительским элементом для отображения или подготовки состояния элемента.<br>

>Области ответственности: 

>>Предоставление программного интерфейса взаимодействия с элементом.

>>Создание композиции программных интерфейсов страниц и элементов.

>Возможность использования конструктора с передачей элемента страницы и Action display, отвечающего за отображение этого элемента.
