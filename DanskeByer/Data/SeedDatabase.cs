using DanskeByer.Data;
using DanskeByer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TODO: Ret namespace så det afspejler, det namespace du bruger i dit projekt
namespace DanskeByer
{
    public class SeedDatabase
    {
        // TODO: Tjek at din context også hedder CityContext - ellers skal du rette typen her
        private CityContext context;
        private ILogger<SeedDatabase> logger;

        // TODO: Tjek at din context også hedder CityContext - ellers skal du rette typen her
        public SeedDatabase(CityContext context, ILogger<SeedDatabase> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        private static Dictionary<String, int> data = new Dictionary<string, int>()
        {
            { "København", 623404 },
            { "Frederiksberg", 103960 },
            { "Dragør", 14270 },
            { "Tårnby", 42984 },
            { "Albertslund", 27877 },
            { "Ballerup", 48458 },
            { "Brøndby", 35397 },
            { "Gentofte", 75176 },
            { "Gladsaxe", 69681 },
            { "Glostrup", 22615 },
            { "Herlev", 28786 },
            { "Hvidovre", 53416 },
            { "Høje-Taastrup", 50686 },
            { "Ishøj", 22946 },
            { "Lyngby-Taarbæk", 55790 },
            { "Rødovre", 40052 },
            { "Vallensbæk", 16654 },
            { "Allerød", 25646 },
            { "Egedal", 43335 },
            { "Fredensborg", 40819 },
            { "Frederikssund", 45332 },
            { "Furesø", 41069 },
            { "Gribskov", 41195 },
            { "Halsnæs", 31271 },
            { "Helsingør", 62567 },
            { "Hillerød", 50998 },
            { "Hørsholm", 25007 },
            { "Rudersdal", 56509 },
            { "Bornholm", 39572 },
            { "Christiansø", 90 },
            { "Greve", 50267 },
            { "Køge", 60675 },
            { "Lejre", 27775 },
            { "Roskilde", 87577 },
            { "Solrød", 23065 },
            { "Faxe", 36513 },
            { "Guldborgsund", 60930 },
            { "Holbæk", 71297 },
            { "Kalundborg", 48681 },
            { "Lolland", 41615 },
            { "Næstved", 82991 },
            { "Odsherred", 33122 },
            { "Ringsted", 34725 },
            { "Slagelse", 79073 },
            { "Sorø", 29834 },
            { "Stevns", 22782 },
            { "Vordingborg", 45816 },
            { "Assens", 41212 },
            { "Faaborg-Midtfyn", 51809 },
            { "Kerteminde", 23773 },
            { "Langeland", 12560 },
            { "Middelfart", 38553 },
            { "Nordfyns", 29693 },
            { "Nyborg", 32042 },
            { "Odense", 204182 },
            { "Svendborg", 58599 },
            { "Ærø", 6058 },
            { "Billund", 26629 },
            { "Esbjerg", 115652 },
            { "Fanø", 3404 },
            { "Fredericia", 51427 },
            { "Haderslev", 55857 },
            { "Kolding", 92893 },
            { "Sønderborg", 74561 },
            { "Tønder", 37587 },
            { "Varde", 50129 },
            { "Vejen", 42863 },
            { "Vejle", 114830 },
            { "Aabenraa", 59035 },
            { "Favrskov", 48374 },
            { "Hedensted", 46747 },
            { "Horsens", 90370 },
            { "Norddjurs", 37680 },
            { "Odder", 22675 },
            { "Randers", 97909 },
            { "Samsø", 3684 },
            { "Silkeborg", 93054 },
            { "Skanderborg", 61974 },
            { "Syddjurs", 42768 },
            { "Aarhus", 345332 },
            { "Herning", 88917 },
            { "Holstebro", 58504 },
            { "Ikast-Brande", 41282 },
            { "Lemvig", 19998 },
            { "Ringkøbing-Skjern", 56930 },
            { "Skive", 46224 },
            { "Struer", 21143 },
            { "Viborg", 97113 },
            { "Brønderslev", 36370 },
            { "Frederikshavn", 59987 },
            { "Hjørring", 64665 },
            { "Jammerbugt", 38460 },
            { "Læsø", 1806 },
            { "Mariagerfjord", 42055 },
            { "Morsø", 20403 },
            { "Rebild", 29916 },
            { "Thisted", 43660 },
            { "Vesthimmerlands", 37121 },
            { "Aalborg", 215312 }
        };
        public void SeedData()
        {
            context.Database.Migrate();
            if (context.City.Count() > 0)
            {
                logger.LogInformation("Der ligger allerede data i databasen");
                return;
            }

            logger.LogInformation("By-tabellen er tom. Jeg indsætter data");

            foreach (KeyValuePair<string, int> entry in data)
            {
                City c = new City();
                c.Name = entry.Key;
                c.Population = entry.Value;
                context.Add(c);

            }
            context.SaveChanges();
            logger.LogInformation("Data indsat i databasen");

        }
    }

}