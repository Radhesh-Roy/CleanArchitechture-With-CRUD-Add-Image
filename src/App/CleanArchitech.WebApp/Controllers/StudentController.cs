using CleanArchitechture.Application.Repository;
using CleanArchitechture.Application.ViewModel;
using CleanArchitechture.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitech.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _studentRepository.GetAllAsync(cancellationToken));
        }

        public async Task<ActionResult<StudentVm>>CreateOrEdit(int id,CancellationToken cancellation)
        {

            if (id==0)
            {
                return View(new StudentVm());
            }
            else
            {
                return View(await _studentRepository.GetFindIdAsync(id,cancellation));
            }
        }
        [HttpPost]
        public async Task<ActionResult<StudentVm>>CreateOrEdit(int id,StudentVm studentVm,CancellationToken cancellation,IFormFile image)
        {
            if (id==0) 
            {
                if (image !=null && image.Length>0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/Student",image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);   
                    };
                    studentVm.Images = $"{image.FileName}";
                }

                await _studentRepository.Insert(studentVm, cancellation);
                return RedirectToAction("Index");
            
            }
            else
            {
                await _studentRepository.Update(id, studentVm, cancellation);
                return RedirectToAction("Index");   
            }

           
           
        }
        public async Task<IActionResult>Delete(int id,CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetFindIdAsync(id, cancellationToken);
            if (student !=null)
            {
                await _studentRepository.Delete(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Details(int id,CancellationToken cancellationToken,IFormFile image,StudentVm studentVm)
        {

            if (image != null && image.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Student", image.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                };
                studentVm.Images = $"{image.FileName}";
            }
            var data = await _studentRepository.GetFindIdAsync(id, cancellationToken);
            return View(data);  
        }
    }
}
