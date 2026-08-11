using Manga.Application.DTO;
using Manga.Application.Interfaces;
using Manga.Domain.Entities;

namespace Manga.Application.Services;
public class MangaServices : IMangaService
{
    private static List<MangaStructure> _listManga = new List<MangaStructure>();

    public MangaStructure Create(DTOStructureManga newManga)
    {
        MangaStructure newRegistreManga = new MangaStructure(
            Guid.NewGuid(), newManga.Title, newManga.Author, newManga.Volumen.Value, newManga.Score.Value
        );

        _listManga.Add(newRegistreManga);
        
        return newRegistreManga;
    }

    public bool Delete(Guid id)
    {
        var existManga = _listManga.FirstOrDefault(man => man.Id == id);
        if (existManga == null)
        {
            return false;
        }
        _listManga.Remove(existManga);

        return true;
    }

    public List<MangaStructure> GetAll()
    {
        return _listManga;
    }

    public MangaStructure? GetById(Guid id)
    {
        return _listManga.FirstOrDefault(man => man.Id == id);
    }

    public MangaStructure? Patch(Guid id, DTOStructureManga patchManga)
    {
        var existManga = _listManga.FirstOrDefault(man => man.Id == id);
        if(existManga == null)
        {
            return null;
        }

        if(patchManga.Title != null)
        {
            existManga.Title = patchManga.Title;
        }
        if(patchManga.Author != null)
        {
            existManga.Author = patchManga.Author;
        }
        if(patchManga.Volumen != null)
        {
            existManga.Volumen = patchManga.Volumen.Value;
        }
        if(patchManga.Score != null)
        {
            existManga.Score = patchManga.Score.Value;
        }

        return existManga;

    }

    public MangaStructure? Update(Guid id, DTOStructureManga updateManga)
    {
        var existManga = _listManga.FirstOrDefault(man => man.Id == id);
        if(existManga == null)
        {
            return null;
        }

        existManga.Title = updateManga.Title;
        existManga.Author = updateManga.Author;
        existManga.Volumen = updateManga.Volumen.Value;
        existManga.Score = updateManga.Score.Value;

        return existManga;
    }



}