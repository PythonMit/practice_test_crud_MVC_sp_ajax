using Microsoft.AspNetCore.Mvc;
using pra_test.Data;
using pra_test.Interface;
using pra_test.Models;
using pra_test.Service;

namespace pra_test.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerson _person;
        public PersonController(IPerson person)
        {
            _person = person;
        }
        public IActionResult Index()
        {
            var people = _person.GetPeople();
            return View(people);
        }
        [HttpPost]
        public IActionResult AddOrEditPerson(PersonModel person)
        {
            if (person.Id == 0)
            {
                _person.AddPerson(person);
            }
            else
            {
                _person.UpdatePerson(person);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult GetPersonById(int id)
        {
            var person = _person.GetPersonById(id);
            return Json(person);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _person.DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
