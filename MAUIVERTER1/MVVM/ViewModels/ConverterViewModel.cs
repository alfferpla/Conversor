using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace MAUIVERTER1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; } //La enlazamos al Picker del Xaml
        public string CurrentToMeasure { get; set; } //La enlazamos al Picker del Xaml
        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }

        //Llamo al método Convert después de cambiar el número de unidades en la App, en Xaml dentro de Entry
        public ICommand ReturnCommand => new Command(() => {Convert(); }); 

        public ConverterViewModel(string quantityName) //Constructor
        {
            QuantityName = quantityName;
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();
            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
            Convert(); //Llamo al método Conversión
        }

        public void Convert() //Método que lleva a cabo la conversión
        {
            //result=Clase.método(ValorQueremosConvertir, MedidaDelValor, DesdeQuéUnidadMedida, HastaQuéMedida)
            var result= UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }
        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuantityName).UnitInfos.Select(u => u.Name).ToList();
            return new ObservableCollection<string>(types);
        }
    }
}
