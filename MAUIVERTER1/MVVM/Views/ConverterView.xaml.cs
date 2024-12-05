using MAUIVERTER1.MVVM.ViewModels;

namespace MAUIVERTER1.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		//BindingContext = new ConverterViewModel();
	}

	//Invocamos el método Convert cuando cambiamos alguna unidad de medida
    private void Picker_SelectedIndexChanged(object sender, EventArgs e) 
    {
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
    }
}