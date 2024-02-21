using MongoDB.Bson.Serialization;
using TechChallenge.Infrastructure.MongoDB.Mappings;
using TechChallenge.Infrastructure.MongoDB.Services;

namespace TechChallenge.Infrastructure.MongoDB.Settings;

public static class CustomClassMappings
{
    public static void RegisterCustomClassMappings(DataSecurityService dataSecurityService)
    {
        EncryptedStringSerializerService serializer = new(dataSecurityService);

        BsonClassMap.RegisterClassMap<AddressCollection>(c =>
        {
            c.AutoMap();
            c.MapMember(p => p.Street).SetSerializer(serializer);
            c.MapMember(p => p.Number).SetSerializer(serializer);
            c.SetIgnoreExtraElements(true);
        });

        BsonClassMap.RegisterClassMap<CustomerCollection>(c =>
        {
            c.AutoMap();
            c.MapProperty(p => p.Name).SetSerializer(serializer);
            c.SetIgnoreExtraElements(true);
        });
    }
}
