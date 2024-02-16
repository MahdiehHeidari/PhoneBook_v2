
using DAL.DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;


namespace UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly PhoneBookContext _context;
        private readonly BLL.PersonRepository _personRepo;
        private readonly BLL.PhoneRepository _phoneRepo;
        public PersonController(PhoneBookContext context)
        {
          
            _personRepo = new BLL.PersonRepository();
            _context = context;
        }

        // GET: person
        public async Task<IActionResult> Index()
        {

            var persons = _personRepo.GetUser();
            var personWithPhones = persons;

            return personWithPhones != null ?
                          View(persons) :
                          Problem("Entity set 'PhoneBookContext.Persons'  is null."); ;
        }

        // GET: person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var persons = _personRepo.GetUser();
            if (id == null || persons == null)
            {
                return NotFound();
            }
            var person = _personRepo.getuserid((int)id);
          
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: person/Create
        public IActionResult Create()
        {
          
            var persons = new Person();
            persons.Phones = new List<Phone>();

            return View(persons);
          
        }
   

        [HttpPost]
        public ActionResult Create(Person person)
        {
          
            if (person != null )
            {

                _personRepo.InsertPerson(person);
             
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }
        // POST: person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created([Bind("Id,FirstName,LastName,Phones")] Person person)
        {



            if (person != null)
            {
                //   person.Phones = person.Phones.Select(phone => new Phone { PhoneNumber = phone.PhoneNumber }).ToList();


            _personRepo.InsertPerson(person);



                return View(person);

            }
                
             
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
          
          
            var person = _personRepo.getuserid((int)id);
            if (person == null)
            {
                return NotFound();
            }

            
            return View(person);
        }

        // POST: person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phones")] Person person)
        {
          
            if (ModelState.IsValid || true)
            {
                try
                {
                    _personRepo.EditUser(person);
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _personRepo.GetUser() == null)
            {
                return NotFound();
            }

            
            var person = _personRepo.getuserid((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_personRepo.GetUser() == null)
            {
                return Problem("Entity set 'PhoneBookContext.Persons'  is null.");
            }
           
            var person = _personRepo.getuserid((int)id);
            if (person != null)
            {
                _personRepo.DeleteById(person);
               
            }
            
           
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
          return (_personRepo.GetUser()?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
