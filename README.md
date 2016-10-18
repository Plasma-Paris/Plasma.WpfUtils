 ![logo](ReadMeFiles\logo.png)

# Plasma.WpfUtils

Plasma.WpfUtils is a open-source librairy of reusable WPF simple mini-services.

## Plasma.WpfDialogBox

Service for MVVM usage of message box and dialog box

### Installing / Getting started

Simply reference the librairies into your project, or use NuGet :

```shell
Install-Package Plasma.WpfDialogBox
```

### Usage

#### Basic Usage

Add a CurrentMessageBox property to your view model

```c#
public class MainViewModel : ViewModelBase
{
    private MessageBoxContainerViewModel _CurrentMessageBox;
    public MessageBoxContainerViewModel CurrentMessageBox
    {
        get
        {
            return _CurrentMessageBox;
        }
        set
        {
            Set(() => CurrentMessageBox, ref _CurrentMessageBox, value);
        }
    }
}
```

Suscribe to the service event and set the `CurrentMessageBox` from this events

```c#
MessageBoxService _Service;
public MainViewModel()
{
    var defaultMessageBoxViewModel = new GenericMessageBoxViewModel();
    _Service = new MessageBoxService(defaultMessageBoxViewModel);
 
    _Service.OnShowRequestStarted += (s, e) => CurrentMessageBox = e.ViewModel;
    _Service.OnHideRequestEnded += (s, e) => CurrentMessageBox = null;
}
```

Add a `ContentControl` to your view for displaying the message box

```xml
<Window [...]>
    <Grid>
        <ContentControl Height="Auto" 
                        Width="Auto"
                        Content="{Binding CurrentMessageBox}">
            <!--MESSAGEBOX CONTAINER-->
        </ContentControl>
    </Grid>
</Window>
```

Add the correspondante `DataTemplate` and namespaces

```xml
<Window 
	[...]
    xmlns:boxView="clr-namespace:Plasma.WpfDialogBox.Views;assembly=Plasma.WpfDialogBox"
    xmlns:boxVM="clr-namespace:Plasma.WpfDialogBox.ViewModels;assembly=Plasma.WpfDialogBox"
    [...]>
    <Window.Resources>
        <ResourceDictionary>
            <DataTemplate DataType="{x:Type boxVM:MessageBoxContainerViewModel}">
                <boxView:MessageBoxContainer></boxView:MessageBoxContainer>
            </DataTemplate>
        </ResourceDictionary>
    </Window.Resources>
```

In this exemple, we add a button for displaying the message box 

```xml
<Button Command="{Binding YesNoMessageBoxCommand}" >Yes/No MessageBox</Button>
```

```c#
public RelayCommand YesNoMessageBoxCommand { get; private set; }
 
async void YesNoMessageBox()
{
    var result = await _Service.ShowMessage("This is the content of the message box", "This is the title", System.Windows.MessageBoxButton.YesNo);
    if (result == System.Windows.MessageBoxResult.Yes)
        await _Service.ShowMessage("User chosse Yes !");
    if (result == System.Windows.MessageBoxResult.No)
        await _Service.ShowMessage("User chosse No !");
}
```

#### Result

 ![1](ReadMeFiles\1.png) ![2](ReadMeFiles\2.png) ![3](ReadMeFiles\3.png)

#### Custom the *GenericMessageBox*

You can pass your own view model, descending from `GenericMessageBoxViewModel`

```c#
var myMessageBoxViewModel = new MyMessageBoxViewModel();
_Service = new MessageBoxService(myMessageBoxViewModel);
// […]
public class MyMessageBoxViewModel : GenericMessageBoxViewModel
{
    // What you want
    void MyCustomAction()
	{
    	base.Hide();
	}
}
```
And you can make your own view as a `UserControl`, using this view model

```xml
<ResourceDictionary>
  	[...]
    <DataTemplate DataType="{x:Type local:MyMessageBoxViewModel}">
        <local:MyUserControl></local:MyUserControl>
    </DataTemplate>
</ResourceDictionary>
```

 ![4](ReadMeFiles\4.png)

#### Make your own MessageBox

In the same spirit, you can make, your own view model and view, descending from `BaseMessageBoxViewModel`

```c#
public class MyMessageBoxViewModel : BaseMessageBoxViewModel
{
    // What you want
  	void MyCustomAction()
	{
    	base.Hide();
	}
}
```
Add your `DataTemplate`
```xml
<ResourceDictionary>
  	[...]
    <DataTemplate DataType="{x:Type local:MyCustomViewModel}">
        <local:MyUserControl></local:MyUserControl>
    </DataTemplate>
</ResourceDictionary>
```
And show it with the `ShowCustomMessageBox` method
```c#
var result = await _Service.ShowCustomMessageBox(new MyMessageBoxViewModel { /* What you want */ });
```

##### The *IsModal* option

With the `ShowMessage` method, the user can't intercat with other control *under* the message box, because the `BaseMessageBoxViewModel` has a `IsModal` boolean property automaticly set to `true` for the `GenericMessageBoxViewModel`. 

If you want to reproduce this behavior, just set `IsModal` to `true` in your `CustomViewModel`.

### To Do

* Make the `GenericMessageBox` usable with multiple languages.
* Add a parameter for allow to displaying the view into a real windows, instead of a WPF "popin".
* Allow to superpose message box (by exemple, an action in a message box wich open a other message box)

## Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are welcome.

## Licensing

The code in this project is licensed under GNU GPL license.