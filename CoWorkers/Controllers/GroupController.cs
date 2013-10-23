using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoWorkers.Controllers
{
    public class GroupController : Controller
    {

        public static int groupIdForRedrection;
        public static String previousPage;
        public static int idUser = 0;

        public async Task<ActionResult> Create()
        {
            using (Service1Client service = new Service1Client())
            {
                idUser = Convert.ToInt32(HttpContext.User.Identity.Name);
                return View(new ZoombuViewModel
                {
                    User = await service.GetUserByIdAsync(idUser),
                    Group = new Group()
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(ZoombuViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (Service1Client service = new Service1Client())
                {
                    // Get user connected
                    idUser = Convert.ToInt32(HttpContext.User.Identity.Name);

                    Group groupTmp = viewModel.Group;
                    groupTmp.UserOwnerId = idUser;
                    if (await service.CreateGroupAsync(groupTmp) != -1)
                    {
                        //Redirect
                        previousPage = "../Home/";
                        return RedirectToAction(previousPage);
                    }
                    else
                    {
                        return RedirectToAction("Create", "Group");
                    }
                }
            }
            else
            {
                return View(viewModel);
            }
        }

    }
}
