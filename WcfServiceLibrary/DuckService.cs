using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class DuckService : IDuckService
    {      

        public Duck GetDuck(Duck composite)
        {
            if (composite == null)
            {
                composite = new Duck();
                //throw new ArgumentNullException("composite");
            }
            if (composite.IsGay)
            {
                composite.Name = "Mr."+ composite.Name+ " is gay";
            }
            return composite;
        }
        public Duck Separate(Duck composite)
        {
            if (composite == null)
                return null;
            else
            {
                composite.SizeDick -= 5;
            }
            return composite;
        }
    }
}
