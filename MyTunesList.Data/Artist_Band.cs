using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public enum Genre
    {
        Alternative,
        Experimental_Rock,
        Punk_Rock,
        Emo,
        Goth,
        Grunge,
        Hardcore_Punk,
        Hard_Rock,
        Indie_Rock,
        Lo_Fi,
        Hi_Fi,
        Progressive_Rock,
        Shoegaze,
        Steampunk,
        New_Wave,
        Anime,
        Blues,
        Acoustic_Blues,
        Blues_Rock,
        Contemporary_Blues,
        Contemporary_R_B,
        Country_Blues,
        Delta_Blues,
        Electric_Blues,
        Folk_Blues,
        Gospel_Blues,
        Harmonica_Blues,
        Memphis_Blues,
        Piano_Blues,
        Ragtime,
        Childrens_Music,
        Classical,
        Avant_Garde,
        Ballet,
        Baroque,
        Cantata,
        Chamber_Music,
        Choral,
        Contemporary_Classical,
        Modern_Classical,
        Opera,
        Renaissance,
        Romantic,
        Comedy,
        Novelty,
        Commercial,
        Country,
        Alternative_Country,
        Americana,
        Bluegrass,
        Christian,
        Country_Pop,
        Country_Rap,
        Country_Rock,
        Psychobilly,
        Dance,
        EDM,
        Club_Dance,
        Dubstep,
        Electro_House,
        Hardcore_Dance,
        House_Dance,
        Techno,
        Trance,
        Disney,
        Easy_Listening,
        Electronic,
        Acid_Jazz,
        Electronic_Rock,
        Industrial,
        Trip_Hop,
        French_Pop,
        Folk_Music,
        Hip_Hop,
        Rap,
        Holiday,
        Indie_Pop,
        Gospel,
        Marching_Band,
        K_Pop,
        Jazz,
        Big_Band,
        Bebop,
        Contemporary_Jazz,
        Lounge,
        Latin,
        Bachata,
        Bolero,
        Bossa_Nova,
        Tango,
        Cumbia,
        Flamenco,
        Latin_Jazz,
        Pop_Latino,
        Reggaeton,
        Salsa,
        Metal,
        Heavy_Metal,
        Speed_Metal,
        Thrash_Metal,
        Death_Metal,
        Black_Metal,
        Doom_Metal,
        Progressive_Metal,
        Mathcore,
        Hardcore_Metal,
        Nu_Metal,
        Grindcore,
        Avant_Garde_Metal,
        New_Age,
        Pop,
        Britpop,
        Soft_Rock,
        Progressive,
        R_B,
        Soul,
        Reggae,
        Ska_Punk,
        Rock,
        British_Invasion,
        Hair_Metal,
        Psychedelic,
        Rockabilly,
        Surf_Rock,
        Singer_Songwriter,
        Soundtrack,
        Spoken_Word,
        Vocal,
        A_cappella,
        Barbershop,
        Standards,
        Vocal_Jazz,
        Vocal_Pop,
        World,
    }

    public class Artist_Band
    {
        [Key]
        public int Artist_BandId { get; set; }

        [Required]
        public string Name { get; set; }

        //public List<string> Discography { get; set; }
        
        [Required]
        public int FormationYear { get; set; }

        /*public double AverageRating 
        {
            get;
        }*/

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
    }
}
