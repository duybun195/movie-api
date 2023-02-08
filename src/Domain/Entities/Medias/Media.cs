using movie_basic.Domain.Enums.Medias;

namespace movie_basic.Domain.Entities.Medias;

public class Media : BaseAuditableEntity
{
    public string OriginalName { get; set; }

    public string Name { get; set; }

    public string ContentType { get; set; }

    public string Extention { get; set; }

    public string Path { get; set; }

    public MediaType Type { get; set; }

    public MediaStatus Status { get; set; }
}

