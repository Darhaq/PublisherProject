using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherProjectData.DTOs.Artist;
using PublisherProjectData.Models;

namespace PublisherProjectData.Mappers
{
    public static class ArtistMappers
    {
        public static Artist ToArtistFromRequestCreateDto(this RequestCreateArtistDto createDto)
        {
            return new Artist
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName
            };
        }

        public static Artist ToArtistFromRequestUpdateDto(this RequestUpdateArtistDto updateDto)
        {
            return new Artist
            {
                ArtistId = updateDto.ArtistId,
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName
            };
        }

        public static ArtistDto ToArtistDto(this Artist artist)
        {
            return new ArtistDto
            {
                ArtistId = artist.ArtistId,
                FirstName = artist.FirstName,
                LastName = artist.LastName
            };
        }
    }
}
