using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }

        public void Create()
        {
            
        }
    }
}
