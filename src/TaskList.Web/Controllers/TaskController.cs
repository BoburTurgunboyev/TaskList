using Microsoft.AspNetCore.Mvc;
using TaskList.Application.Services.TaskServ;
using TaskList.Web.Models;
using Task = TaskList.Domain.Entities.Task;

namespace TaskList.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index(int pg = 1)
        {
            var tasks = await _taskService.RetrieveAll();
            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = tasks.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = tasks.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            // return View(tasks);

            return View(data);
        }



        // Get: Product/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _taskService.RetrieveById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        // Get: Product/Create
        public IActionResult Create()
        {
            return View();
        }


        // Post: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Status")] Task product)
        {
            if (ModelState.IsValid)
            {

                await _taskService.Add(product);


                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        // Get: Users/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _taskService.RetrieveById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Post: Users/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,Status")] Task product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var newProduct = await _taskService.Modify(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }



        //   Get:  Product/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _taskService.RetrieveById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Post: Product/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _taskService.RemoveById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
