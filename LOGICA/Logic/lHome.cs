using LOGICA.Entity;
using Newtonsoft.Json;
using RESTHeper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LOGICA.Logic
{
    public class lHome
    {

        public List<Album> GetAlbums()
        {
            List<Album> response = new List<Album>();
            try
            {
                string url = "https://jsonplaceholder.typicode.com/albums";
                string jsonresp = RESTHeper.RESTHeper.Get(url);
                response = JsonConvert.DeserializeObject<List<Album>>(jsonresp);
            }
            catch (Exception)
            {
                response = null;
            }
            return response;
        }

        public List<Photo> GetPhotos(int AlbumId)
        {
            List<Photo> response = new List<Photo>();
            try
            {
                string url = "https://jsonplaceholder.typicode.com/photos";
                string jsonresp = RESTHeper.RESTHeper.Get(url);
                response = JsonConvert.DeserializeObject<List<Photo>>(jsonresp);
                response = (from res in response where res.albumId == AlbumId select res).ToList();
            }
            catch (Exception)
            {
                response = null;
            }
            return response;
        }

        public List<Comment> GetComments(int PostId)
        {
            List<Comment> response = new List<Comment>();
            try
            {
                string url = "https://jsonplaceholder.typicode.com/comments";
                string jsonresp = RESTHeper.RESTHeper.Get(url);
                response = JsonConvert.DeserializeObject<List<Comment>>(jsonresp);
                response = (from res in response where res.postId == PostId select res).ToList();
            }
            catch (Exception)
            {
                response = null;
            }
            return response;
        }

    }
}