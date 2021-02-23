using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTO.Request;
using Kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireController : ControllerBase
    {
        private readonly FireDbContext _context;

        public FireController(FireDbContext context)
        {
            _context = context;
        }

        [Route("/api/firefighters/{id}/actions")]
        [HttpGet]
        public IActionResult GetFirefighter([FromRoute] int id)
        {
            ICollection<Firefighter> orders;

                orders = _context.Firefighter.Where(c=> c.IdFirefighter == id).OrderBy(c => c.IdFirefighter).ToList();


            var db = _context;
            var akcja = db.Firefighter.SingleOrDefault(x => x.IdFirefighter == id);
            if (akcja != null)
            {
                var action = (from zw in db.Firefighter_Action
                                  join w in db.Firefighter on zw.IdFirefighter equals w.IdFirefighter
                                  join z in db.Action on zw.IdAction equals z.IdAction
                                  where w.IdFirefighter == id
                                  select new
                                  {
                                      z.IdAction,
                                      z.StartTime,
                                      z.EndTime
                                  });
                return StatusCode(201, action);
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("/api/actions/1/fire-trucks")]
        [HttpPost]

        public IActionResult Action(FireTruckRequest request)
        {
            if (request.IdFireTruck == null)
            {
                return BadRequest("Nie podano id wozu");
            }
            
            else
            {
                var result = _context.FireTruck.SingleOrDefault(b => b.IdFireTruck == request.IdFireTruck);
                var action = _context.Action.SingleOrDefault(a => a.IdAction == request.IdAction);

                if (result != null)
                {
                    if (result.SpecialEquipment == action.NeedSpecialEquipment)
                    {
                        var newAction = new FireTruck_Action
                        {
                            IdFireTruck = request.IdFireTruck,
                            IdAction = request.IdAction,
                            AssigmentDate = new DateTime(2020, 6, 27, 0, 0, 0, 0, DateTimeKind.Local),
                        };
                        _context.FireTruck_Action.Add(newAction);
                    }
                    else return BadRequest("Woz nie posiada wymaganego sprzetu");
                    
                }
            }
            
            _context.SaveChanges();
            return StatusCode(201, "Przypisano");
        }
    }
}