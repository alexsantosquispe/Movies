using Xamarin.Forms;
using Movies.Utils;
using Movies.Models;
using System.Collections.Generic;
using System;

namespace Movies
{
    public partial class MainPage : ContentPage
    {
        const string URL = "https://api.themoviedb.org/3";
        const string UPCOMING = "/movie/upcoming?api_key=940337eaad841b8c39112f6bc97b026e&language=en-US&page=1";
        const string POPULAR = "/movie/popular?api_key=940337eaad841b8c39112f6bc97b026e&language=en-US&page=1";
        const string IMAGE_URI = "https://image.tmdb.org/t/p/w500";
        DateTime releaseDate;

        public MainPage()
        {
            InitializeComponent();
            Populate();
        }

        public async void Populate()
        {
            if (Network.isConnected())
            {
                WSClient client = new WSClient();
                var ObjectResp = await client.Get<Upcoming>(URL + POPULAR);
                List<Movie> movies = ObjectResp.results;
                for (int i = 0; i < movies.Count; i++)
                {
                    movies[i].poster_path = IMAGE_URI + movies[i].poster_path;
                    movies[i].backdrop_path = IMAGE_URI + movies[i].backdrop_path;
                    releaseDate = DateTime.Parse(movies[i].release_date);
                    movies[i].release_date = String.Format("{0:MMMM, yyyy}", releaseDate);
                }
                TeatherToday.ItemsSource = ObjectResp.results;
            }            
        }
    }
}
