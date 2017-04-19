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
    public partial class MovieSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            if (IsPostBack)
            {
                movieResults.InnerHtml = "";
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Result resultsList = getSearchResultsList();
            if (resultsList.Response.Equals("True"))
                displayResultsFor(resultsList);
            else
                displayNoMoviesFoundMessage();
        }

        private Result getSearchResultsList()
        {

            string userSearchText = searchTextBox.Text;
            string searchUrl = "http://www.omdbapi.com/?s=" + userSearchText;
            HttpWebRequest searchRequest = (HttpWebRequest)WebRequest.Create(searchUrl);
            HttpWebResponse response = (HttpWebResponse)searchRequest.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string responseContents = responseReader.ReadToEnd();
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Result));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseContents));
            return (Result)jsonSerializer.ReadObject(stream);
        }

        private void displayResultsFor(Result resultsList)
        {
            movieResults.InnerHtml += "<h3>Here's what we found:</h3>";
            foreach (Movie result in resultsList.Movie)
                if (result.Type.Equals("movie"))
                    displayDetailsPageLinkFor(result);
        }

        private void displayDetailsPageLinkFor(Movie m)
        {
            movieResults.InnerHtml += "<h3><a href=MovieDetails.aspx?movieId=" + m.imdbID + ">" + m.Title + "</h3>";
            movieResults.InnerHtml += "<img src=" + m.Poster + "/></a><br/>";
        }

        private void displayNoMoviesFoundMessage()
        {
            movieResults.InnerHtml += "<h3>We couldn't find any movies with that title.<h3>";
        }
    }

    [DataContract]
    public class Movie
    {
        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "imdbID")]
        public string imdbID { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }

        [DataMember(Name = "Poster")]
        public string Poster { get; set; }
    }

    [DataContract]
    public class Result
    {
        [DataMember(Name = "Search")]
        public IList<Movie> Movie { get; set; }

        [DataMember(Name = "totalResults")]
        public string totalResults { get; set; }

        [DataMember(Name = "Response")]
        public string Response { get; set; }
    }
}