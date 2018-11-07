using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDuckService
    {
        
        [OperationContract]
        Duck GetDuck(Duck composite);

        [OperationContract]

        Duck Separate(Duck composite);
        

        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary.ContractType".
    [DataContract]
    public class Duck
    {
        bool isGay = true;
        string name = "Pidor";
        int sizeDick = 15;

        [DataMember]
        public bool IsGay
        {
            get { return isGay; }
            set { isGay = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int SizeDick
        {
            get { return sizeDick; }
            set { sizeDick = value; }
        }
    }
}
