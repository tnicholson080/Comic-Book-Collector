using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly IOverallStatsDao _overallStatsDao;
        private readonly IUserStatsDao _userStatsDao;

        public StatsController(IOverallStatsDao overallStatsDao, IUserStatsDao userStatsDao)
        {
            _overallStatsDao = overallStatsDao;
            _userStatsDao = userStatsDao;
        }

        [Authorize]
        [HttpGet("/stats/{userId}")]
        public ActionResult<UserStats> GetUserStats(int userId)
        {
            return Ok(_userStatsDao.GetUsersStats(userId));
        }
        
        [HttpGet("/stats/overall")]
        public ActionResult<OverallStats> GetOverallStats()
        {
            return Ok(_overallStatsDao.GetOverallStats());
        }

    }
}
