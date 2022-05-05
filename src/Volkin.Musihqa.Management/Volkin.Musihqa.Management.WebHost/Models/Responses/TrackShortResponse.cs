﻿using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.WebHost.Models.Responses
{
    public class TrackShortResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TrackShortResponse(Track track)
        {
            Id = track.Id;
            Name = track.Name;
        }
    }
}
