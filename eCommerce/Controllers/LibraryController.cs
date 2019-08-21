using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class LibraryController : Controller
    {
        private readonly GameContext _context;
        
        // Passes DBcontext to controller with constructor
        public LibraryController(GameContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            //Null-coalescing operator
            // If id is not null set page to it, or if null start with one.
            int page = id ?? 1; // id is the page number coming in
            //Create a list of all VG in database for display purposes
            const int PageSize = 3;
            List<VideoGame> games =  await VideoGameDb.GetGamesByPage(_context, page, PageSize);

            //Maximum page
            int totalPages = 
                await VideoGameDb.GetTotalPages(_context, PageSize);
            ViewData["Pages"] = totalPages;
            ViewData["CurrentPage"] = page;
            return View(games);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                //Add to database
                await VideoGameDb.Add(game, _context);
                return RedirectToAction("Index");
            }

            //Return veiw with model including error messages
            return View(game);
        }

        public async Task<IActionResult> Update(int id)
        {
            //Get the single video game out of the db
            VideoGame game = await VideoGameDb.GetGameById(id, _context);
            
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VideoGame g)
        {
            if (ModelState.IsValid)
            {
                //If it works update the game
                await VideoGameDb.UpdateGame(g, _context);
                //redirect to index
                return RedirectToAction("Index");
            }
            //If any erorrs show user form again
            return View(g);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            VideoGame game = await VideoGameDb.GetGameById(id, _context);

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await VideoGameDb.DeleteById(id, _context);
            // Direct back to the index
            return RedirectToAction("Index");
        }
    }
}