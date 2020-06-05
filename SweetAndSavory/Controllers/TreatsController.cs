using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetAndSavory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SweetAndSavory.Controllers
{
  
  public class TreatsController : Controller
  {
    private readonly SweetAndSavoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, SweetAndSavoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat Treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Treat.User = currentUser;
      _db.Treats.Add(Treat);
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = Treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
        .Include(Treat => Treat.Flavors)
        .ThenInclude(join => join.Flavor)
        .Include(Treat => Treat.User)
        .FirstOrDefault(Treat => Treat.TreatId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisTreat.User.Id : false;
      return View(thisTreat); // modify this for Admin access only
    }


    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat Treat, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = Treat.TreatId});
      }
      _db.Entry(Treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    // bool checkDuplicateFlavor(DataTable table, int FlavorId)
    // {
    //   Treat Treat = new Treat();
    //   foreach (DataRow row in table.Rows)
    //   {
    //     if(row[2].Equals(Treat.TreatId) && row[3].Equals(FlavorId))
    //     return true;
    //   }
    //   return false;
    // }
    //
    // if(!checkDuplicateFlavor(TreatId, FlavorId))
    //     { execute function }


    [HttpPost]
    public ActionResult AddFlavor(Treat Treat, int FlavorId)
    {
      if (FlavorId != 0 )
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = Treat.TreatId }); 
      }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
      
  }
}