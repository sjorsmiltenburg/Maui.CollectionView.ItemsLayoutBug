using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace zz_MauiApp1_imagetest;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = new MainPageViewModel();
    }
}

public class MainPageViewModel : INotifyPropertyChanged
{
    public MainPageViewModel()
    {
        MyItems.Add(new MyItem() { Name = "1" });
        MyItems.Add(new MyItem() { Name = "2" });
        MyItems.Add(new MyItem() { Name = "3" });
        MyItems.Add(new MyItem() { Name = "4" });
        MyItems.Add(new MyItem() { Name = "5" });
        MyItems.Add(new MyItem() { Name = "6" });
    }

    public ObservableCollection<MyItem> MyItems { get; set; } = new ObservableCollection<MyItem>();

    int _columnCount = 1;

    public ItemsLayout MyLayout
    {
        get
        {
            var x = new GridItemsLayout(_columnCount, ItemsLayoutOrientation.Vertical);
            x.VerticalItemSpacing = 0;
            x.HorizontalItemSpacing = 0;
            return x;
        }
    }

    public ICommand AddColumnCommand => new Command(() =>
    {
        _columnCount++;
        OnPropertyChanged(nameof(MyLayout));
    });

    public ICommand RemoveColumnCommand => new Command(() =>
    {
        _columnCount--;
        OnPropertyChanged(nameof(MyLayout));
    });


    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}

public class MyItem
{
    public string Name { get; set; }
}

