using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;


namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        //
        // GET: /StoreManager/
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var albums = storeDB.Albums
        .Include("Genre").Include("Artist")
        .ToList();

            return View();
        }
        public ActionResult Edit(int id)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);

            try
            {
                // Save Album

                UpdateModel(album, "Album");
                storeDB.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                // Error occurred - so redisplay the form

                var viewModel = new StoreManagerViewModel()
                {
                    Album = album,
                    Genres = new SelectList(storeDB.Genres.ToList(), "GenreId", "Name", album.GenreId),
                    Artists = new SelectList(storeDB.Artists.ToList(), "ArtistId", "Name", album.ArtistId)
                };

                return View(viewModel);
            }

        }
        [HttpPost]
        public ActionResult Create(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Save Album
                    storeDB.AddToAlbums(album);
                    storeDB.SaveChanges();

                    return Redirect("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }

            // Invalid - redisplay with errors

            var viewModel = new StoreManagerViewModel()
            {
                Album = album,
                Genres = new SelectList(storeDB.Genres.ToList(), "GenreId", "Name", album.GenreId),
                Artists = new SelectList(storeDB.Artists.ToList(), "ArtistId", "Name", album.ArtistId)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var album = storeDB.Albums
                .Include("OrderDetails").Include("Carts")
                .Single(a => a.AlbumId == id);

            storeDB.DeleteObject(album);
            storeDB.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
