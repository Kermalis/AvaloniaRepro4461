using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace AvaloniaApplication1
{
    public sealed class MainWindow : Window, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public new event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestModel> Objects { get; } = new ObservableCollection<TestModel>();
        private TestModel _selectedObject;
        public TestModel SelectedObject
        {
            get => _selectedObject;
            set
            {
                if (value != _selectedObject)
                {
                    _selectedObject = value;
                    OnPropertyChanged(nameof(SelectedObject));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            DataContext = this;
            AvaloniaXamlLoader.Load(this);

            Test_AddNewObjs();
        }

        public void DoButton()
        {
            DisposeModels();
            Test_AddNewObjs();
        }

        private void Test_AddNewObjs()
        {
            for (int i = 0; i < 3; i++)
            {
                Objects.Add(new TestModel(new MyObj(i)));
            }
            SelectedObject = Objects.FirstOrDefault();
        }

        private void DisposeModels()
        {
            foreach (TestModel m in Objects)
            {
                m.Dispose();
            }
            Objects.Clear();
        }
    }
}
