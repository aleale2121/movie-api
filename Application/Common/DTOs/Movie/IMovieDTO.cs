using System;
using System.Collections.Generic;

using Application.Common.DTOs.Common;

namespace Application.Common.DTOs.Movie;

public interface IMovieDTO {
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseYear { get; set; }
}
