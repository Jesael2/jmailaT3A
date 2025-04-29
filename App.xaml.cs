namespace jmailaT3A
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var mainPage = new NavigationPage(new Views.vContactos());

            return new Window(mainPage);

        }
    }
}