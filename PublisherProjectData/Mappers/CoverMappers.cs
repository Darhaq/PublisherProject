using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherProjectData.DTOs.Cover;
using PublisherProjectData.Models;

namespace PublisherProjectData.Mappers
{
    public static class CoverMappers
    {
        public static Cover ToCoverFromRequestCreateDto(this RequestCreateCoverDto createDto)
        {
            return new Cover
            {
                DesignIdeas = createDto.DesignIdeas,
                DigitalOnly = createDto.DigitalOnly
            };
        }

        public static Cover ToCoverFromRequestUpdateDto(this RequestUpdateCoverDto updateDto)
        {
            return new Cover
            {
                CoverId = updateDto.CoverId,
                DesignIdeas = updateDto.DesignIdeas,
                DigitalOnly = updateDto.DigitalOnly
            };
        }

        public static CoverDto ToCoverDto(this Cover cover)
        {
            return new CoverDto
            {
                CoverId = cover.CoverId,
                DesignIdeas = cover.DesignIdeas,
                DigitalOnly = cover.DigitalOnly
            };
        }
    }
}
