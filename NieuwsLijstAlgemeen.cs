using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SVORacing.Paginas
{
	public class NieuwsLijstAlgemeen : ContentPage
	{
        ListView lstView;
        ViewModels.NieuwsLijstAlgemeenVM viewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstView.TranslationX = -500;
            lstView.TranslateTo(0, 0, 750, Easing.CubicOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            lstView.TranslationX = -500;
        }

        public NieuwsLijstAlgemeen ()
		{
            Title = "Nieuws";
            BindingContext = viewModel = new ViewModels.NieuwsLijstAlgemeenVM();

            BackgroundColor = Color.FromHex("#1f1f1f");

            string title = "";
            if (Device.RuntimePlatform == Device.iOS)
            {
                title = "Enter The Grid";
            }
            else
            {
                title = "race.ttf#race";
            }

            ActivityIndicator loadingImage = new ActivityIndicator();
            loadingImage.SetBinding(ActivityIndicator.IsRunningProperty, "LoadingVisibility");
            loadingImage.SetBinding(ActivityIndicator.IsVisibleProperty, "LoadingVisibility");
            loadingImage.Color = Color.FromHex("#f50000");
            loadingImage.HeightRequest = 50;
            loadingImage.HorizontalOptions = LayoutOptions.Center;
            loadingImage.VerticalOptions = LayoutOptions.Center;
            loadingImage.WidthRequest = 50;

            lstView = new ListView();
            lstView.SetBinding(ListView.ItemsSourceProperty, "NieuwsLijst");
            lstView.SeparatorColor = Color.Transparent;
            lstView.HasUnevenRows = true;
            lstView.IsPullToRefreshEnabled = true;
            lstView.SetBinding(ListView.RefreshCommandProperty, "GetNieuwsLijst");
            lstView.SetBinding(ListView.IsRefreshingProperty, "IsRefreshing");
            lstView.BackgroundColor = Color.FromHex("#1f1f1f");
            lstView.ItemTemplate = new DataTemplate(() =>
            {
                Image afbeelding = new Image();
                afbeelding.Aspect = Aspect.AspectFill;
                afbeelding.SetBinding(Image.SourceProperty, "source");

                Label titel = new Label();
                titel.FontFamily = title;
                titel.FontAttributes = FontAttributes.Bold;
                titel.SetBinding(Label.TextProperty, "titel");
                titel.TextColor = Color.Black;
                titel.FontSize = 12;

                MultiLineLabel inleiding = new MultiLineLabel();
                inleiding.Lines = 3;
                inleiding.SetBinding(Label.TextProperty, "inleiding");
                inleiding.TextColor = Color.Black;
                inleiding.LineBreakMode = LineBreakMode.WordWrap;
                inleiding.FontSize = 12;


                Label datum = new Label();
                datum.SetBinding(Label.TextProperty, "datum");
                datum.TextColor = Color.LightGray;
                datum.FontSize = 12;

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    titel.FontSize = 25;
                    inleiding.FontSize = 25;
                    datum.FontSize = 25;
                }

                Frame frame = new Frame();
                frame.CornerRadius = 5;
                frame.IsClippedToBounds = true;
                frame.Padding = 0;
                frame.WidthRequest = 1500;
                frame.HeightRequest = 80;
                frame.Content = afbeelding;

                StackLayout children = new StackLayout
                {
                    Spacing = 0,
                    Margin = 2.5,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        titel,
                        inleiding,
                        datum
                    }
                };

                Grid viewGrid = new Grid();
                //viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(140, GridUnitType.Absolute) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(140, GridUnitType.Absolute) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                viewGrid.Children.Add(frame, 0, 0);
                viewGrid.Children.Add(children, 1, 0);

                Frame wholeFrame = new Frame();
                if (Device.RuntimePlatform == Device.iOS)
                {
                    wholeFrame.TranslationX = 0;
                }
                else
                {
                    wholeFrame.TranslationX = -500;
                }
                wholeFrame.Padding = 2.5;
                wholeFrame.CornerRadius = 5;
                wholeFrame.BackgroundColor = Color.White;
                wholeFrame.Margin = new Thickness(5,2.5);
                wholeFrame.Content = viewGrid;
                wholeFrame.TranslateTo(0, 0, 750, Easing.CubicOut);
                wholeFrame.TranslateTo(0, 0, 750, Easing.CubicOut);
                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = wholeFrame
                };
            });

            lstView.ItemTapped += async (o, e) =>
            {
                var myList = (ListView)o;
                var nieuws = (myList.SelectedItem as Entiteiten.Nieuws);
                await Navigation.PushAsync(new NieuwsWeergave(nieuws, false, false));
                myList.SelectedItem = null; // de-select the row
            };

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(lstView, 0 , 0);
            grid.Children.Add(loadingImage, 0, 0);

            Content = grid;

        }
    }
}