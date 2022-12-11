using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebOS.AuxiliaryClasses;
using WebOS.Data;
using WebOS.Models;
using static WebOS.Models.Common;

namespace WebOS.Controllers
{
    public class UploadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;
        public UploadsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: Uploads
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Upload.Include(u => u.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Uploads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Upload == null)
            {
                return NotFound();
            }

            var upload = await _context.Upload
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upload == null)
            {
                return NotFound();
            }

            return View(upload);
        }

        // GET: Uploads/Create
        public IActionResult Create()
        {
            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Uploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FileName,NameDescription,ApplicationUserId,CreationDate,FolderDestination")] Upload upload, IFormFile myfile)
        {
            //if (ModelState.IsValid)
            //{
            upload.ApplicationUserId = _userManager.GetUserId(User);
            upload.CreationDate = DateTime.Now;

            switch (upload.FolderDestination)
            {
                case FolderDestination.Files:
                    upload.FileName = await UserFile.UploadeNewFileAsync(upload.FileName,
myfile, _environment.WebRootPath, Properties.Resources.Files);
                    break;
                case FolderDestination.Images:
                    upload.FileName = await UserFile.UploadeNewFileAsync(upload.FileName,
myfile, _environment.WebRootPath, Properties.Resources.Pictures);
                    break;
            }

            //            if (upload.FolderDestination == FolderDestination.Secured)
            //            {
            //                upload.FileName = await UserFile.UploadeNewFileAsync(upload.FileName,
            //myfile, _environment.WebRootPath, Properties.Resources.Secured);
            //            }
            //            else
            //            {
            //                upload.FileName = await UserFile.UploadeNewFileAsync(upload.FileName,
            //myfile, _environment.WebRootPath, Properties.Resources.PublicationFiles);
            //            }
            _context.Add(upload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", upload.ApplicationUserId);

            //return View(upload);
        }

        // GET: Uploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Upload == null)
            {
                return NotFound();
            }

            var upload = await _context.Upload.FindAsync(id);
            if (upload == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", upload.ApplicationUserId);
            return View(upload);
        }

        // POST: Uploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName,NameDescription,ApplicationUserId,CreationDate,FolderDestination")] Upload upload)
        {
            if (id != upload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadExists(upload.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", upload.ApplicationUserId);
            return View(upload);
        }

        // GET: Uploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Upload == null)
            {
                return NotFound();
            }

            var upload = await _context.Upload
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upload == null)
            {
                return NotFound();
            }

            return View(upload);
        }

        // POST: Uploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Upload == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Upload'  is null.");
            }
            var upload = await _context.Upload.FindAsync(id);
            if (upload != null)
            {
                _context.Upload.Remove(upload);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UploadExists(int id)
        {
          return _context.Upload.Any(e => e.Id == id);
        }
    }
}
