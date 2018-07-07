using LOGICA.Entity;
using LOGICA.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inventario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAlbums()
        {
            try
            {
                List<Album> _albums = new lHome().GetAlbums();
                return Json(_albums);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetPhotos(int AlbumId)
        {
            try
            {
                List<Photo> _photos = new lHome().GetPhotos(AlbumId);
              return Json(_photos);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

        [HttpPost]
        public ActionResult GetComments(int PhotoId)
        {
            try
            {
                List<Comment> _comments = new lHome().GetComments(PhotoId);
                return Json(_comments);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }

    }

}