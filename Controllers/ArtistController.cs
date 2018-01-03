using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers
{


    public class ArtistController : Controller
    {

        private List<Artist> allArtists;

        public ArtistController()
        {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index()
        {
            //String describing the API functionality
            string instructions = "";
            instructions += "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [Route("artists")]
        [HttpGet]

        public JsonResult artists()
        {
            return Json(allArtists);
        }

        [Route("artists/name/{name}")]
        [HttpGet]

        public JsonResult artistname(string name)
        {
            var artists = allArtists.Where(artist => artist.ArtistName == name);
            return Json(artists);
        }

        [Route("artists/realname/{name}")]
        [HttpGet]

        public JsonResult artistrealname(string name)
        {
            var artists = allArtists.Where(artist => artist.RealName == name);
            return Json(artists);
        }

        [Route("artists/hometown/{name}")]
        [HttpGet]

        public JsonResult artisthometown(string name)
        {
            var artists = allArtists.Where(artist => artist.Hometown == name);
            return Json(artists);
        }

        [Route("artists/groupid/{id}")]
        [HttpGet]

        public JsonResult artistgroupid(int id)
        {
            var artists = allArtists.Where(artist => artist.GroupId == id);
            return Json(artists);
        }
    }
}