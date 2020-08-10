using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvaloniaApplication1
{
    public enum MyEnum
    {
        Val1,
        Val2,
        Val3,
    }

    internal sealed class MyObj
    {
        public MyEnum Value;

        public MyObj(int i)
        {
            Value = (MyEnum)i;
        }
    }

    public sealed class TestModel : INotifyPropertyChanged, IDisposable
    {
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public MyEnum Value
        {
            get => Obj.Value;
            set
            {
                if (value != Obj.Value)
                {
                    Obj.Value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public static IEnumerable<MyEnum> SelectableValues { get; } = new[] { MyEnum.Val1, MyEnum.Val2, MyEnum.Val3 };

        internal MyObj Obj;

        internal TestModel(MyObj obj)
        {
            Obj = obj;
        }

        public void Dispose()
        {
            Obj = null;
            PropertyChanged = null;
        }
    }
}
