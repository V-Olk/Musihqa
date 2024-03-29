﻿using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.WebHost.Models.Responses
{
    public class ArtistShortResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ArtistShortResponse(Artist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
        }
    }
}
