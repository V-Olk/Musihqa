using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static List<Album> Albums
        {
            get
            {
                var artist = new Artist(id: Guid.Parse("071ac86c-db64-4548-8e24-9af58d036084")
                    , name: "Korn"
                    , description: String.Empty);

                return new()
                {
                    new Album(id: Guid.Parse("e17f299f-92d7-459f-896e-078ed53ef99c")
                        , name: "Requiem"
                        , coverLink: "https://upload.wikimedia.org/wikipedia/ru/4/48/Korn_%E2%80%94_Requiem.jpg"
                        , releaseDate: new DateTime(2022, 2, 4, 0, 0, 0, DateTimeKind.Utc)
                        , primaryArtist: artist
                        , tracks: new List<Track>()
                        {
                            new(Guid.Parse("b63de284-a032-4c4f-9d51-37ff409b15ae")
                                , "Forgotten"
                                , artist),

                            new(Guid.Parse("e38efa45-f61c-404c-aebc-7eaef33abc3c"),
                                "Let the Dark Do the Rest",
                                artist),

                            new(Guid.Parse("480d8f9a-64c2-4da4-a158-0b04ea3fab45"),
                                "Start the Healing",
                                artist)
                        })
                };
            }
        }
    }
}
