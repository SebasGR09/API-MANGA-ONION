
namespace Manga.Domain.Entities;
public class MangaStructure
{
    public Guid Id {get; set;}

    private string _title;
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _title = value;
            }
            else
            {
                throw new ArgumentException("El titulo no puede estar vacio.");
            }
        }
    }

    private string _author;
    public string Author
    {
        get
        {
            return _author;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _author = value;
            }
            else
            {
                throw new ArgumentException("El autor no debe estar vacio");
            }
        }
    }

    private int _volumen;
    public int Volumen
    {
        get
        {
            return _volumen;
        }
        set
        {
            if(value >= 1)
            {
                _volumen = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El numero de volumenes no puede ser menor a 1");
            }
        }
    }


    private double _score;
    public double Score
    {
        get
        {
            return _score;
        }
        set
        {
            if(value >= 0 && value <= 10)
            {
                _score = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El puntaje no puede ser menor a 0 ni mayor a 10.");
            }
        }
    }

    public MangaStructure(Guid id, string title, string author, int volumen, double score)
    {
        Id = id;
        Title = title;
        Author = author;
        Volumen = volumen;
        Score = score;
    }

}