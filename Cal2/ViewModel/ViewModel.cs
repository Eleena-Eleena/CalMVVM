using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Cal2
{
    class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<String> list = new ObservableCollection<String>();
        public ObservableCollection<ICommand> com = new ObservableCollection<ICommand>();
        public event PropertyChangedEventHandler PropertyChanged; // событие. которое реагирует на изменение свойст
        public ViewModel()
        {
            list.Add("Сложение");
            list.Add("Вычитание");
            list.Add("Деление");
            list.Add("Умножение");
            firstNumber = 0;
            secondNumber = 0;
            result = 0;

            com.Add(new AddCommand(this));
            com.Add(new SubCommand(this));
            com.Add(new DivCommand(this));
            com.Add(new MulCommand(this));

        }

        private double firstNumber;
        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                    firstNumber = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstNumber"));  // событие, которое реагирует на изменение свойства
            }
        }
        private string sign;
        public string Sign
        {
            get { return sign; }
            set
            {
                sign = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Sign"));  // событие, которое реагирует на изменение свойства
            }
        }
        private double secondNumber;
        public double SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SecondNumber"));  // событие, которое реагирует на изменение свойства

            }
        }
        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));  // событие, которое реагирует на изменение свойства

            }
        }
        private ICommand cv;
        public ICommand Cv
        {
            get { return cv; }
            set
            {
                cv = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Cv"));  // событие, которое реагирует на изменение свойства

            }
        }
        public ObservableCollection<string> ComboChange // свойство для заполнения Combobox
        {
            get
            {
                return list;
            }
        }
        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            get { return cbIndex; }
            set
            {
                cbIndex = value;
                Cv = com[cbIndex];
                switch(cbIndex)
                {
                    case 0:
                        Sign = "+";
                        break;
                    case 1:
                        Sign = "-";
                        break;
                    case 2:
                        Sign = "/";
                        break;
                    case 3:
                        Sign = "*";
                        break;

                }
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }
    }
}
