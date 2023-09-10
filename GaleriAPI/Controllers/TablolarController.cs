using GaleriAPI.Data;
using GaleriAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaleriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablolarController : ControllerBase
    {
        private readonly GaleriDbContext _db;
        private readonly Tablo _tablo;

        public TablolarController(GaleriDbContext db, Tablo tablo)
        {
            _db = db;
            _tablo = tablo;
        }

        [HttpGet]
        public List<Tablo> GetTablolar()
        {
            return _db.Tablolar.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Tablo> GetTablo(int id)
        {
            var tablo = _db.Tablolar.Find(id);

            if (tablo == null)
                return NotFound();

            return tablo;
        }

        [HttpPost]
        public IActionResult PostTablo(PostTabloDto tabloDto)
        {
            if (ModelState.IsValid)
            {
                _tablo.Ressam = tabloDto.Ressam;
                _tablo.ResminYapilmaTarihi = tabloDto.ResminYapilmaTarihi;

                _db.Tablolar.Add(_tablo);
                _db.SaveChanges();
            }

            return CreatedAtAction(nameof(GetTablo), new { id = _tablo.Id }, _tablo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTablo(int id)
        {
            var tablo = _db.Tablolar.Find(id);

            if (tablo == null)
                return NotFound();

            _db.Tablolar.Remove(tablo);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutTablo(int id, PutTabloDto tabloDto)
        {
            var tablo = _db.Tablolar.Find(id);
            
            if (tablo == null)
                return NotFound();

            tablo.Ressam = tabloDto.Ressam;
            tablo.ResminYapilmaTarihi = tabloDto.ResminYapilmaTarihi;

            _db.SaveChanges();

            return NoContent();
        }
    }
}
