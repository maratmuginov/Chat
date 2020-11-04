using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChatSignalR.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChatSignalR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatLib.Models;

namespace ChatSignalR.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public ChatController(ILogger<ChatController> logger, ApplicationDbContext context, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var messages = await _context.Messages.ToListAsync();
            return View();
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid == false) 
                return Error();
            
            message.UserName = User.Identity.Name;
            var sender = await _userManager.GetUserAsync(User);
            message.UserId = sender.Id;
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
