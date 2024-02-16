using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace UI.Controllers
{
    public class PhoneController : Controller
    {
        

   
        private readonly BLL.PhoneRepository _phoneRepo;
        private readonly BLL.PersonRepository _personRepo;

        public PhoneController(PhoneBookContext context)
        {
            _phoneRepo = new BLL.PhoneRepository();
            _personRepo = new BLL.PersonRepository();


        }

        // GET: Phone
        public async Task<IActionResult> Index()
        {
            var phones= _phoneRepo.GetAll() ;
            return View(phones);
        }

        // GET: Phone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var phones = _phoneRepo.GetAll();
            if (id == null || phones == null)
            {
                return NotFound();
            }

          
            var phone = _phoneRepo.getPhoneByid((int)id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phone/Create
        public IActionResult Create(int? id)
        {

           if(id != null)
            {
                ViewData["PersonId"] = id;
            }
            
          
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhoneNumber,Type,PersonId")] Phone phone)
        {
            var phones = _phoneRepo.GetAll();
            if (phone != null)
            {
                if(phone.PhoneNumber == null)
                {
                    return RedirectToAction(nameof(PhonesWithPersonId), new { id = phone.PersonId });

                }
                _phoneRepo.InsertPhone(phone);
             
                return RedirectToAction(nameof(PhonesWithPersonId), new { id = phone.PersonId });

            }
            ViewData["PersonId"] = phone.PersonId;
           return View(phone);
        }

        // GET: Phone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var phones = _phoneRepo.GetAll();
            if (id == null || phones == null)
            {
                return NotFound();
            }

            var phone = _phoneRepo.getPhoneByid((int)id);

            if (phone == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = phone.PersonId;
        
            return View(phone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNumber,Type,PersonId")] Phone phone)
        {
           
            if (id == null || phone.PersonId == null)
            {
                return NotFound();
            }
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (phone !=null)
            {
                try
                {
                    _phoneRepo.EditPhone(phone);
             
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PhonesWithPersonId), new { id = phone.PersonId });
             
            }
            ViewData["PersonId"] = id;
            return View(phone);
        }

        // GET: Phone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var phones = _phoneRepo.GetAll();
            if (id == null || phones == null)
            {
                return NotFound();
            }

            var phone = _phoneRepo.getPhoneByid((int) id);
            var pId = phone.PersonId;
            if (phone == null)
            {
                return NotFound();
            }
          
            if (_phoneRepo.GetAll() == null)
            {
                return Problem("Entity set 'PhoneBookContext.Phones'  is null.");
            }
           
    
            if (phone != null)
            {
                _phoneRepo.Delete(phone);
              
            }

     
            //return View(phone);
            return RedirectToAction(nameof(PhonesWithPersonId), new { id = pId ,noadd = false});

        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phones = _phoneRepo.GetAll();
            if (phones == null)
            {
                return Problem("Entity set 'PhoneBookContext.Phones'  is null.");
            }
            var phone = _phoneRepo.getPhoneByid(id);
           // int personId = phone.PersonId;
            if (phone != null)
            {
                _phoneRepo.Delete(phone);
             
            }
     
           return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {

            var phone = _phoneRepo.getPhoneByid(id);
            if(phone != null)
            {
                return true;
            }
            return false;
        }
        // POST: Phone/PhonesWithPersonId
        [HttpGet]
        [ActionName("PhonesWithPersonId")]
        public async Task<IActionResult> PhonesWithPersonId(int? id,bool? noAdd=true)
        {
            
                var phoneBooks = _phoneRepo.GetAll();
            
            if (id == null)
            {
                return NotFound();
            }
            var person = _personRepo.getuserid((int)id); // Replace 'personId' with the actual ID
            if (person == null)
            {
                return NotFound();
            }
            // Next, explicitly load the Phones navigation property
     
            var phones = person.Phones;


            if( phones.Count == 0 && noAdd ==true)
            {
                return RedirectToAction(nameof(Create), new { id = id });

            }
            if(phones.Count == 0 && noAdd == false)
            {
             
                return RedirectToAction("Index", "Person");
            }
           
                ViewData["PersonId"] = id;

                
            return View(phones);
        
    }

    }
}
