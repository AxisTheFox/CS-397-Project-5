using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
            return Request.QueryString == null;
        }

        private void ShowSelectedMovieDetails()
        {
            movieId = Request.QueryString.ToString();
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