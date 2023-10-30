using Microsoft.AspNetCore.Mvc;
using web_24BM.Models;
using web_24BM.Services;

namespace web_24BM.Controllers
{
    public class CurriController : Controller
    {
        private readonly ICurriculum _curriculumService;

        public CurriController(ICurriculum curriculumService)
        {
            _curriculumService = curriculumService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _curriculumService.GetAll());
        }

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		public async Task<IActionResult> Create(Curriculum model)
		{
			var response = await _curriculumService.Create(model);

			if (response.Success)
			{
				TempData["MenssageSuccess"] = response.Message;
				return RedirectToAction("Index", "Curri");
			}
			else
			{
				TempData["ErrorMessage"] = response.Message;

				return View(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int idCurriculum)
		{
			var curriculum = await _curriculumService.GetById(idCurriculum);

			return View(curriculum);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Curriculum model)
		{
			var response = await _curriculumService.Update(model);

			if (response.Success)
			{
				TempData["MenssageSuccess"] = response.Message;
				return RedirectToAction("Index", "Curri");
			}
			else
			{
				TempData["ErrorMessage"] = response.Message;

				return View(model);
			}

		}

		[HttpPost]
		public async Task<IActionResult> Delete(int idCurriculum)
		{
			var response = await _curriculumService.Delete(idCurriculum);
			if (response.Success)
			{
				TempData["MenssageSuccess"] = response.Message;
				return RedirectToAction("Index", "Curri");
			}
			else
			{
				TempData["ErrorMessage"] = response.Message;

				return RedirectToAction("Index", "Curri");
			}
		}
	}
}
