using MovieApp.Domain;

namespace MovieApp.Data;

public class Seed
{
    public void SeedData(MovieDbContext context)
    {
        context.Genres.Add(new Genre
        {
            Id = 1,
            Title = "Bilim Kurgu",
            Description = "Bilim kurgu filmleri, genellikle gelecekte veya farklı bir dünyada geçen, teknolojinin ileri düzeyde kullanıldığı ve bilimsel kavramların merkezde olduğu yapımlardır."
        });
        context.Genres.Add(new Genre
        {
            Id = 2,
            Title = "Komedi",
            Description = "Güldürücü olaylar, komik karakterler ve mizahi diyaloglarla dolu yapımlar."
        });
        context.Genres.Add(new Genre
        {
            Id = 3,
            Title = "Gerilim",
            Description = "İzleyiciyi koltuğunuza yapıştıracak sürprizler, gizemler ve heyecan dolu anlar sunan yapımlar."
        });

        context.Movies.Add(new Movie
        {
            Id = 1,
            GenreId = 1,
            Title = "Inception",
            Description = " Bir hırsızlık ekibi bilinçaltına girip fikirleri çalmak için tehlikeli yöntemler kullanırken, başka bir iş teklifiyle gerçeklik ile rüya dünyası arasında karmaşık bir yolculuğa çıkarlar.",
            ImbdPoint = 8.8,
            ReleaseDate = DateTime.SpecifyKind(new DateTime(2010, 10, 16), DateTimeKind.Utc),
            TotalRevenue = 828M
        });

        context.Movies.Add(new Movie
        {
            Id = 2,
            GenreId = 1,
            Title = "Blade Runner 2049",
            Description = "Bir yapay zeka dedektifi olan Blade Runner izini sürdüğü eski bir Blade Runner'ı keşfetmesinin ardından daha büyük bir gizem ve komployu çözmek için maceraya atılır.",
            ImbdPoint = 8.0,
            ReleaseDate = DateTime.SpecifyKind(new DateTime(2017, 9, 6), DateTimeKind.Utc),
            TotalRevenue = 260.5M
        });

        context.Movies.Add(new Movie
        {
            Id = 3,
            GenreId = 1,
            Title = "Interstellar",
            Description = "Gelecekte dünya çiftlik arazileriyle boşalan bir hale dönüşürken bir grup kaşif insan yaşamının devamı için başka bir güneş sistemine seyahat etmeye çalışır ve yeni bir yuva arayışında uzayda derin bir yolculuğa çıkar.",
            ImbdPoint = 8.6,
            ReleaseDate = DateTime.SpecifyKind(new DateTime(2014, 11, 7), DateTimeKind.Utc),
            TotalRevenue = 677.5M
        });

        context.SaveChanges();
    }
}