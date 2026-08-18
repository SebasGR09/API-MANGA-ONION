using Manga.Application.DTO;
using Manga.Application.Interfaces;
using Manga.Application.Services;
using Manga.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manga.API.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class MangaController : ControllerBase
{
    private readonly IMangaService _services;  // Esta es una instancia del service que vamos a recibir

    public MangaController(IMangaService service)  // .net nos provee la interfaz/service que indicamos en el program
    {
        _services = service;
    }

    [HttpGet]
    public IActionResult GetMangas()
    {
        return Ok(_services.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetManga(Guid id)
    {
        var existManga = _services.GetById(id);
        if(existManga == null)
        {
            return NotFound();
        }

        return Ok(existManga);
    }

    [HttpPost]
    public IActionResult PostManga([FromBody] DTOStructureManga newManga)
    {   
        MangaStructure newRegister = _services.Create(newManga);
        return CreatedAtAction(nameof(GetManga), new {id = newRegister.Id}, newRegister);
    }

    [HttpPut("{id}")]
    public IActionResult PutManga(Guid id, [FromBody] DTOStructureManga updateManga)
    {
        var validation = _services.Update(id, updateManga);

        if(validation == null)
        {
            return NotFound();
        }

        return Ok(validation);
    }


    [HttpPatch("{id}")]
    public IActionResult PatchManga(Guid id, [FromBody] DTOStructureManga patchManga)
    {
        var validation = _services.Patch(id, patchManga);
        if(validation == null)
        {
            return NotFound();
        }

        return Ok(validation);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteManga(Guid id)
    {
        return _services.Delete(id) ? NoContent() : NotFound();
    }

}