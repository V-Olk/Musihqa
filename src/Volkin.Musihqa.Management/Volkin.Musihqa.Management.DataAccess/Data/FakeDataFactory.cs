using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static List<Album> Albums
        {
            get
            {
                var artist = new Artist()
                {
                    Id = Guid.Parse("071ac86c-db64-4548-8e24-9af58d036084"),
                    Name = "Korn",
                    Description = String.Empty
                };

                return new()
                {
                    new Album
                    {
                        Id = Guid.Parse("e17f299f-92d7-459f-896e-078ed53ef99c"),
                        Name = "Requiem",
                        CoverLink = "https://upload.wikimedia.org/wikipedia/ru/4/48/Korn_%E2%80%94_Requiem.jpg",

                        PrimaryArtist = artist,

                        Tracks = new List<Track>()
                        {
                            new Track()
                            {
                                Id = Guid.Parse("b63de284-a032-4c4f-9d51-37ff409b15ae"),
                                Name = "Forgotten",
                                PrimaryArtist = artist

                            },

                            new Track()
                            {
                                Id = Guid.Parse("e38efa45-f61c-404c-aebc-7eaef33abc3c"),
                                Name = "Let the Dark Do the Rest",
                                PrimaryArtist = artist
                            },

                            new Track()
                            {
                                Id = Guid.Parse("480d8f9a-64c2-4da4-a158-0b04ea3fab45"),
                                Name = "Start the Healing",
                                PrimaryArtist = artist
                            }
                        }
                    },

                    //new Album()
                    //{
                    //    Artist = new Artist()
                    //    {
                    //        Id = Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                    //        Name = "Slipknot",
                    //    }


                    //},
                };
            }
        }
    }
}
