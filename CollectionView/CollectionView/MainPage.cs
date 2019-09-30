using System.Collections.Generic;
using Xamarin.Forms;

namespace CollectionView
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            BackgroundColor = Color.Beige;
            Content = new Xamarin.Forms.CollectionView
            {
                SelectionMode = SelectionMode.Multiple,
                ItemsLayout = ListItemsLayout.Vertical,
                ItemTemplate = new ItemTemplate(),
                ItemsSource = new List<int> {1, 2, 3, 4, 5, 6}
            };
        }
    }

    internal class ItemTemplate : DataTemplateSelector
    {
        readonly DataTemplate _itemDataTemplate;

        public ItemTemplate()
        {
            _itemDataTemplate = new DataTemplate(typeof(ItemViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return _itemDataTemplate;
        }
    }

    public class ItemViewCell : ContentView
    {
        public ItemViewCell()
        {
            Content =
                new StackLayout
                {
                    Children =
                    {
                        new ScrollView
                        {
                            Orientation = ScrollOrientation.Horizontal,
                            Content = new AbsoluteLayout
                            {
                                Children =
                                {
                                    new ItemView(),
                                    new BoxView
                                    {
                                        HeightRequest = 100,
                                        WidthRequest = 100,
                                        BackgroundColor = Color.Aqua
                                    },
                                    new Button
                                    {
                                        HeightRequest = 100,
                                        WidthRequest = 100,
                                        BackgroundColor = Color.Fuchsia
                                    }
                                }
                            }
                        },
                        new BoxView
                        {
                            HeightRequest = 100,
                            WidthRequest = 100,
                            BackgroundColor = Color.Black
                        }
                    }
                };
        }
    }

    public class ItemView : StackLayout
    {
        public ItemView()
        {
            Children.Add(
                new Label
                {
                    HorizontalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.Red,
                    HeightRequest = 60,
                    WidthRequest = 1000,
                    Text = "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test"
                }
            );
        }
    }
}