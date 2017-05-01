namespace hLib.DAL.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<hLib.DAL.HLibDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\Migrations";
        }

        protected override void Seed(hLib.DAL.HLibDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

            context.Nationalities.AddOrUpdate(x => x.NationalityName,
                   new Nationality() { NationalityName = "Srbija" },
                   new Nationality() { NationalityName = "Velika Britanija" },
                   new Nationality() { NationalityName = "Nemačka" },
                   new Nationality() { NationalityName = "Danska" },
                   new Nationality() { NationalityName = "Austrija" },
                   new Nationality() { NationalityName = "Rumunija" },
                   new Nationality() { NationalityName = "Bugarska" },
                   new Nationality() { NationalityName = "Rusija" },
                   new Nationality() { NationalityName = "Portugal" },
                   new Nationality() { NationalityName = "Španija" },
                   new Nationality() { NationalityName = "Luksemburg" },
                   new Nationality() { NationalityName = "Holandija" },
                   new Nationality() { NationalityName = "Sjedinjene Američke Države" }
                   );

            context.SaveChanges();

            context.Languages.AddOrUpdate(x => x.LanguageName,
                   new Language() { LanguageName = "Srpski" },
                   new Language() { LanguageName = "Engleski" },
                   new Language() { LanguageName = "Nemački" },
                   new Language() { LanguageName = "Danski" },
                   new Language() { LanguageName = "Rumunski" },
                   new Language() { LanguageName = "Bugarski" },
                   new Language() { LanguageName = "Ruski" },
                   new Language() { LanguageName = "Portugalski" },
                   new Language() { LanguageName = "Španski" },
                   new Language() { LanguageName = "Makedonski" },
                   new Language() { LanguageName = "Grčki" },
                   new Language() { LanguageName = "Turski" }
                   );

            context.SaveChanges();

            context.Genres.AddOrUpdate(x => x.GenreName,
                   new Genre() { GenreName = "roman" },
                   new Genre() { GenreName = "autobiografija" },
                   new Genre() { GenreName = "drama" },
                   new Genre() { GenreName = "poezija" },
                   new Genre() { GenreName = "novela" },
                   new Genre() { GenreName = "pripovetka" },
                   new Genre() { GenreName = "bajka" },
                   new Genre() { GenreName = "esej" },
                   new Genre() { GenreName = "putopis" },
                   new Genre() { GenreName = "enciklopedija" },
                   new Genre() { GenreName = "rečnik" }
                   );

            context.SaveChanges();

            context.Authors.AddOrUpdate(x => x.AuthorLastName,
                   new Author() { AuthorFirstName = "Ivo", AuthorLastName = "Andrić", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Danilo", AuthorLastName = "Kiš", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Borislav", AuthorLastName = "Pekić", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Vladimir", AuthorLastName = "Kecmanović", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Dejan", AuthorLastName = "Stojiljković", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Branislav", AuthorLastName = "Nušić", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Milan", AuthorLastName = "Šipka", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Ivan", AuthorLastName = "Klajn", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Mirko", AuthorLastName = "Kovač", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Srbija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Fjodor", AuthorMiddleName = "Mihajlovič", AuthorLastName = "Dostojevski", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Rusija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Lav", AuthorMiddleName = "Nikolajevič", AuthorLastName = "Tolstoj", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Rusija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Anton", AuthorMiddleName = "Pavlovič", AuthorLastName = "Čehov", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Rusija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Ivan", AuthorMiddleName = "Sergejevič", AuthorLastName = "Turgenjev", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Rusija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Aleksandar", AuthorMiddleName = "Sergejevič", AuthorLastName = "Puškin", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Rusija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Čarls", AuthorLastName = "Dikens", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Velika Britanija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Vilijam", AuthorLastName = "Šekspir", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Velika Britanija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Radjard", AuthorLastName = "Kipling", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Velika Britanija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Oldus", AuthorLastName = "Haksli", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Velika Britanija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Džordž", AuthorLastName = "Orvel", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Velika Britanija").Single().NationalityId },
                   new Author() { AuthorFirstName = "Ernest", AuthorLastName = "Hemingvej", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Sjedinjene Američke Države").Single().NationalityId },
                   new Author() { AuthorFirstName = "Vilijam", AuthorLastName = "Fokner", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Sjedinjene Američke Države").Single().NationalityId },
                   new Author() { AuthorFirstName = "Mark", AuthorLastName = "Tven", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Sjedinjene Američke Države").Single().NationalityId },
                   new Author() { AuthorFirstName = "Timoti", AuthorLastName = "Liri", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Sjedinjene Američke Države").Single().NationalityId },
                   new Author() { AuthorFirstName = "Čarls", AuthorLastName = "Bukovski", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Sjedinjene Američke Države").Single().NationalityId },
                    new Author() { AuthorFirstName = "Hans", AuthorMiddleName = "Kristijan", AuthorLastName = "Andersen", NationalityId = context.Nationalities.Where(a => a.NationalityName == "Danska").Single().NationalityId }
                   );

            context.SaveChanges();

            context.Books.AddOrUpdate(x => x.Title,
                new Book()
                {
                    Title = "Bašta, pepeo",
                    ISBN = "978-86-523-0002-0",
                    LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                    GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                    Description = "Najpoznatiji roman Danila Kiša, veliko delo o detinjstvu i odrastanju. " +
                                    "Uzbudljiva slika jednog sveta data u moćnoj lirskoj svetlosti i u suočenju s najvećim izazovima svog postojanja.",
                    Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Kiš").Single() }
                },
            new Book()
            {
                Title = "Kajnov ožiljak",
                ISBN = "978-86-521-1619-5",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                Description = "Roman Kainov ožiljak je istovremeno uzbudljiv politički triler, priča o nemogućoj ljubavi, potresna istorijska drama, " +
                                "parabola o ljudskosti u dehumanizovanom svetu, partija karata sa đavolom, faustovska dilema jednog velikog pisca i hipoteza " +
                                "o tome kako je nastao Andrićev roman Prokleta avlija.",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Stojiljković").Single(), context.Authors.Where(a => a.AuthorLastName == "Kecmanović").Single() }
            },
            new Book()
            {
                Title = "Mala sirena",
                ISBN = "978-86-521-1081-0",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "bajka").Single().GenreId,
                Description = "Mala sirena čezne da vidi svet iznad talasa. Hoće li mi vetar mrsiti kosu?, pita se. Hoće li mi sunce poljubiti obraz? Na svoj petnaesti rođendan to će i otkriti... " +
                                "a život će joj se zauvek promeniti. Korak po korak je serijal namenjen deci koja tek otkrivaju čarobni svet knjiga. " ,
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Andersen").Single() }
            },
            new Book()
            {
                Title = "Za kim zvono zvoni",
                ISBN = "978-86-89203-39-4",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                Description = "1937. godina, u toku je Španski građanski rat. Američki dobrovoljac Robert Džordan pridružio se gerilskim snagama na strani republikanaca i njegov zadatak je da minira most. " +
                                "U knjizi Za kim zvono zvoni Hemingvej je opisao samo tri dana ovog katastrofalnog sukoba, " +
                                "ali je pokazao kompleksnost jedne epohe i sudbine ljudi. ",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Hemingvej").Single() }
            },
            new Book()
            {
                Title = "Veliki rečnik stranih reči i izraza",
                ISBN = "978-86-515-0717-8",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "rečnik").Single().GenreId,
                Description = "Veliki rečnik stranih reči i izraza, na 1.600 strana, najsveobuhvatniji je rečnik u kojem se nalaze sve dosad zabeležene novije pozajmljenice i novi pojmovi koji su proteklih decenija ušli u naš jezik iz raznih oblasti (medicina, tehnologija, film, muzika, računari, novi mediji).",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Šipka").Single(), context.Authors.Where(a => a.AuthorLastName == "Klajn").Single() }
            },
            new Book()
            {
                Title = "1984",
                ISBN = "86-83725-06-5",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                Description =   "1984 je postao ne samo najpoznatiji Orwellov roman, nego jedno od klasičnih djela distopije i jedan od najuticajnijih "+
                                "romana 20.veka.Temeljen na autorovim iskustvima vezanim uz španski građanski, odnosno drugi svjetski rat i "+
                                "ideologije fašizma i komunizma, roman je shvaćen kao upozorenje budućim generacijama, odnosno inspiracija “+”brojnim književnicima, filozofima i političkim teoretičarima.",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Orvel").Single() }
            },
            new Book()
            {
                Title = "Dok ležah na samrti",
                ISBN = "8-427-04742-X",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Engleski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                Description =   "U tuđoj sobi morate u sebi stvoriti prazninu da biste zaspali. A pre nego sto ste stvorili u sebi prazninu za san, sta ste vi. "+
                                "A kad stvorite u sebi prazninu za san, vi niste. A kad ste ispunjeni snom, vas nikad nije bilo. Ja ne znam sta sam ja. Ne znam da li ja jesem ili nisam.",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Fokner").Single() }
            },
            new Book()
            {
                Title = "Svetilište",
                ISBN = "978-86-636-9057-8",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Engleski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                Description =   "Svetilište je najkontroverzniji roman nobelovca Vilijama Foknera. U njemu je slika američkog juga i mitske pokrajine Joknapatofa "+
                                "uzavrela od najtamnijih strasti ljudske duše. Gangsteri, podmitljivi političari, mlada nimfomanka, bolesno dijete, usamljeni advokat, "+
                                "crnačka sirotinja. – Foknerova vizija ljudske sudbine je nemilosrdna.",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Fokner").Single() }
            },
             new Book()
             {
                 Title = "Buka i bes",
                 ISBN = "978-86-173-2070-4",
                 LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                 GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                 Description =  "“Buka i bes”, verovatno najbolji Foknerov roman, može se opisati kao porodična istorija u četiri verzije, "+
                                "ispričana od strane protagonista tužne priče o finansijskom propadanju jedne ugledne bele porodice i njenoj moralnoj degradaciji.",
                 Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Fokner").Single() }
             },
            new Book()
            {
                Title = "Vrijeme koje se udaljava",
                ISBN = "978-86-521-1985-1",
                LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                GenreId = context.Genres.Where(a => a.GenreName == "autobiografija").Single().GenreId,
                Description =   "Mirko Kovač, poslednji veliki pisac velike potonule Jugoslavije, daruje nam, evo, svoje poslednje napisane stranice, "+
                                "svoj književni testament. Zahvaljujući njemu vreme koje se udaljava postalo je vreme koje nije izgubljeno u maglama i tami prošlosti, "+
                                "postalo je vreme koje nam je blisko, vreme koje se vraća. Mirko Kovač, pisac sa harizmom, pisac velikog dara, izvornog talenta, "+
                                "nastavlja da živi u svojoj literaturi, zajedno sa svojim čudesnim i fascinantnim likovima.",
                Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Kovač").Single() }
            },
             new Book()
             {
                 Title = "Najlepša žena u gradu",
                 ISBN = "978-86-766-2120-0",
                 LanguageId = context.Languages.Where(a => a.LanguageName == "Engleski").Single().LanguageId,                 
                 Description =  "Karneval groteske u režiji Bukovskog doseže vrhunac ovom zbirkom kratkih priča koje vas vode putevima pića, "+
                                "devojaka, budžacima punih bubašvaba i tamnom stranom života. Bukovski banalizuje očaj čineći ga istovremeno smešnim, strašnim i opštim mestom...",
                 Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Bukovski").Single() }
             },
             new Book()
             {
                 Title = "Braća Karamazovi",
                 ISBN = "978-86-767-4097-0",
                 LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                 GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,           
                 Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Dostojevski").Single() }
             },
             new Book()
             {
                 Title = "Idiot",
                 LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                 GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                 Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Dostojevski").Single() }
             },
              new Book()
              {
                  Title = "Zločin i kazna",
                  ISBN = "978-86-784-4131-8",
                  LanguageId = context.Languages.Where(a => a.LanguageName == "Srpski").Single().LanguageId,
                  GenreId = context.Genres.Where(a => a.GenreName == "roman").Single().GenreId,
                  Description = "Najpoznatiji i najpopularniji roman Dostojevskog, verovatno zbog vešto razrađene kriminalističke intrige ukomponovane u ideološki siže. "+
                                "Prvi među velikim romanima koji su Dostojevskom doneli svetsku slavu, najpoznatiji je i najpopularniji, verovatno zbog lepo razrađene "+
                                "kriminalističke intrige (ubistva zelenašice i puta koji ubicu vodi do priznanja), ukomponovane u ideološki siže.",
                  Authors = new List<Author> { context.Authors.Where(a => a.AuthorLastName == "Dostojevski").Single() }
              }
            );
            context.SaveChanges();
        }
    }
}
