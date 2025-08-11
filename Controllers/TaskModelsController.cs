using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    public class TaskModelsController : Controller
    {
        private readonly AppDbContext _context;

        public TaskModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TaskModels
        public async Task<IActionResult> Index(string SearchString)
        {
            var tasks= from t in _context.Tasks select t;
            if (!String.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(t => t.Title.Contains(SearchString) || t.status.Contains(SearchString));
            }

            return View(await tasks.ToListAsync());
        }

        // GET: TaskModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: TaskModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,status,Remarks,CreatedByName,CreatedById,UpdatedByName,UpdatedById")] TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                taskModel.CreatedOn = DateTime.Now;
                taskModel.UpdatedOn = DateTime.Now;

                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //if (ModelState.IsValid)
            //{
            //    _context.Add(taskModel);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(taskModel);
        }

        // GET: TaskModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            return View(taskModel);
        }

        // POST: TaskModels/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,status,Remarks,CreatedByName,CreatedById,UpdatedByName,UpdatedById")] TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingTask = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
                    if (existingTask == null)
                    {
                        return NotFound();
                    }

                    // Compare if data has actually changed
                    if (!AreTasksEqual(existingTask, taskModel))
                    {
                        taskModel.CreatedOn = existingTask.CreatedOn; // keep old created date
                        taskModel.UpdatedOn = DateTime.Now; // update only if changes found
                        _context.Update(taskModel);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        // Optional: Add message to show user "No changes were made"
                        TempData["Message"] = "No changes detected.";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskModel.Id))
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
            return View(taskModel);
        }

        // Helper method to check if any field has changed
        private bool AreTasksEqual(TaskModel oldTask, TaskModel newTask)
        {
            return oldTask.Title == newTask.Title &&
                   oldTask.Description == newTask.Description &&
                   oldTask.DueDate == newTask.DueDate &&
                   oldTask.status == newTask.status &&
                   oldTask.Remarks == newTask.Remarks &&
                   oldTask.CreatedByName == newTask.CreatedByName &&
                   oldTask.CreatedById == newTask.CreatedById &&
                   oldTask.UpdatedByName == newTask.UpdatedByName &&
                   oldTask.UpdatedById == newTask.UpdatedById;
        }

        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,status,Remarks,CreatedByName,CreatedById,UpdatedByName,UpdatedById")] TaskModel taskModel)
        //{
        //    if (id != taskModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var existingTask = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        //            if (existingTask == null)
        //            {
        //                return NotFound();
        //            }
        //            taskModel.CreatedOn = existingTask.CreatedOn;
        //            taskModel.UpdatedOn = DateTime.Now; // ✅ only update this
        //            _context.Update(taskModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TaskModelExists(taskModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(taskModel);
        //}

        // GET: TaskModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: TaskModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel != null)
            {
                _context.Tasks.Remove(taskModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
