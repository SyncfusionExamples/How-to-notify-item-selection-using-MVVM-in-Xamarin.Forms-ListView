using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PassItemData
{
    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs eventArgs = null;

            if (value is Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs)
            {
                eventArgs = value as Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs;
            }

            return eventArgs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
