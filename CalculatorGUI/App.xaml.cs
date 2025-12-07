namespace CalculatorGUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage())
        {
            Title = "Calculator",
            Height = 700,
            Width = 425,
            MinimumHeight = 700,
            MinimumWidth = 425
        };
    }
}