using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoxBraydonProject5
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        string movieId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (noMovieSelected())
                Response.Redirect("MovieSearch.aspx");
            else
                ShowSelectedMovieDetails();
        }

        private bool noMovieSelected()
        {
            return Request.QueryString["movieId"] == null;
        }

        private void ShowSelectedMovieDetails()
        {
            movieId = Request.QueryString["movieId"].ToString();
            SelectedMovie thisMovie = getSelectedMovieInfo();

            Title = thisMovie.Title;

            movieTitle.Text = thisMovie.Title;
            genre.Text = thisMovie.Genre;
            releaseDate.Text = thisMovie.Released;
            runtime.Text = thisMovie.Runtime;
            moviePoster.ImageUrl = thisMovie.Poster;
            plot.Text = thisMovie.Plot;
            rating.Text = thisMovie.Rated;
        }

        private SelectedMovie getSelectedMovieInfo()
        {
            string movieUrl = "http://www.omdbapi.com/?i=" + movieId;
            HttpWebRequest searchRequest = (HttpWebRequest)WebRequest.Create(movieUrl);
            HttpWebResponse response = (HttpWebResponse)searchRequest.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string responseContents = responseReader.ReadToEnd();
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(SelectedMovie));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseContents));
            return (SelectedMovie)jsonSerializer.ReadObject(stream);
        }
    }

    [DataContract]
    public class Rating
    {
        [DataMember(Name = "Source")]
        public string Source { get; set; }

        [DataMember(Name = "Value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class SelectedMovie
    {
        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "Rated")]
        public string Rated { get; set; }

        [DataMember(Name = "Released")]
        public string Released { get; set; }

        [DataMember(Name = "Runtime")]
        public string Runtime { get; set; }

        [DataMember(Name = "Genre")]
        public string Genre { get; set; }

        [DataMember(Name = "Director")]
        public string Director { get; set; }

        [DataMember(Name = "Writer")]
        public string Writer { get; set; }

        [DataMember(Name = "Actors")]
        public string Actors { get; set; }

        [DataMember(Name = "Plot")]
        public string Plot { get; set; }

        [DataMember(Name = "Language")]
        public string Language { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "Awards")]
        public string Awards { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }

        [DataMember(Name = "Ratings")]
        public IList<Rating> Ratings { get; set; }

        [DataMember(Name = "Metascore")]
        public string Metascore { get; set; }

        [DataMember(Name = "imdbRating")]
        public string imdbRating { get; set; }

        [DataMember(Name = "imdbVotes")]
        public string imdbVotes { get; set; }

        [DataMember(Name = "imdbID")]
        public string imdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "DVD")]
        public string DVD { get; set; }

        [DataMember(Name = "BoxOffice")]
        public string BoxOffice { get; set; }

        [DataMember(Name = "Production")]
        public string Production { get; set; }

        [DataMember(Name = "Website")]
        public string Website { get; set; }

        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }
}