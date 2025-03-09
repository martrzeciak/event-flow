using Bogus;
using EventFlow.Domain.Entities;
using EventFlow.Persistence.Models;
using System.Text.Json;

namespace EventFlow.Persistence.Data;

public static class DataGenerator
{
    private readonly static ICollection<CategoryJson> categories_;
    private readonly static ICollection<BandNameJson> bandNames_;
    static DataGenerator()
    {
        Randomizer.Seed = new Random(420);
        categories_ = LoadCategoriesFromJson();
        bandNames_ = LoadBandNamesFromJson();
    }

    private static ICollection<CategoryJson> LoadCategoriesFromJson()
    {
        var jsonString = File.ReadAllText("./../EventFlow.Persistence/Data/SeedData/music_categories.json");

        return JsonSerializer.Deserialize<ICollection<CategoryJson>>(jsonString, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    private static ICollection<BandNameJson> LoadBandNamesFromJson()
    {
        var jsonString = File.ReadAllText("./../EventFlow.Persistence/Data/SeedData/band_names.json");

        return JsonSerializer.Deserialize<ICollection<BandNameJson>>(jsonString,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public static Faker<Address> AddressFaker { get; } = new Faker<Address>()
        .RuleFor(a => a.Id, f => Guid.NewGuid())
        .RuleFor(a => a.Line1, f => f.Address.StreetAddress())
        .RuleFor(a => a.City, f => f.Address.City())
        .RuleFor(a => a.State, f => f.Address.StateAbbr())
        .RuleFor(a => a.PostalCode, f => f.Address.ZipCode())
        .RuleFor(a => a.Country, f => f.Address.Country());

    public static Faker<Venue> VenueFaker { get; } = new Faker<Venue>()
        .RuleFor(v => v.Id, f => Guid.NewGuid())
        .RuleFor(v => v.Name, f => f.Company.CompanyName())
        .RuleFor(v => v.Capacity, f => f.Random.Int(100, 10000))
        .RuleFor(v => v.Address, f => AddressFaker.Generate());

    public static Faker<EventOrganizer> OrganizerFaker { get; } = new Faker<EventOrganizer>()
        .RuleFor(o => o.Id, f => Guid.NewGuid())
        .RuleFor(o => o.Name, f => f.Person.FullName)
        .RuleFor(o => o.ContactInfo, f => f.Internet.Email());

    public static Faker<Event> EventFaker { get; } = new Faker<Event>()
        .RuleFor(e => e.Id, f => Guid.NewGuid())
        .RuleFor(e => e.Name, f => f.PickRandom(bandNames_).Name)
        .RuleFor(e => e.Date, f => f.Date.Future())
        .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
        .RuleFor(e => e.Categories, f => f.PickRandom(categories_, 2).Select(c => c.Name).ToList())
        .RuleFor(e => e.Venue, f => VenueFaker.Generate())
        .RuleFor(e => e.Organizers, f => new List<EventOrganizer> { OrganizerFaker.Generate() });
}
