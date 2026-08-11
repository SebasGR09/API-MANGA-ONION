using System;
using Manga.Application.DTO;
using Manga.Domain.Entities;

namespace Manga.Application.Interfaces;
public interface IMangaService
{
    public MangaStructure Create(DTOStructureManga newManga);
    public List<MangaStructure> GetAll();
    public MangaStructure GetById(Guid id);
    public MangaStructure Update(Guid id, DTOStructureManga updateManga);
    public MangaStructure Patch(Guid id, DTOStructureManga patchManga);
    public bool Delete(Guid id);
}