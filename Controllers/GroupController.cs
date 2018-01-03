using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]

        public JsonResult groups()
        {
            return Json(allGroups);
        }

        [Route("groups/name/{name}")]
        [HttpGet]

        public JsonResult groups(string name)
        {
            var groups = allGroups.Where(group => group.GroupName == name);
            return Json(groups);
        }

        [Route("groups/id/{id}")]
        [HttpGet]

        public JsonResult groups(int id)
        {
            var groups = allGroups.Where(group => group.Id == id);
            return Json(groups);
        }

    }
}