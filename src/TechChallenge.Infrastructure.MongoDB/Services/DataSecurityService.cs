using MongoDB.Bson;
using System.Security.Cryptography;
using System.Text;
using TechChallenge.Infrastructure.MongoDB.Settings;

namespace TechChallenge.Infrastructure.MongoDB.Services;

public class DataSecurityService(DataSecuritySettings settings)
{
    private const int TAG_SIZE = 16;
    private readonly DataSecuritySettings _settings = settings;

    public BsonBinaryData Encrypt(string plainText)
    {
        var key = Convert.FromBase64String(_settings.EncryptionKey!);
        var iv = new byte[12];
        var tag = new byte[TAG_SIZE];

        RandomNumberGenerator.Fill(iv);

        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var cipher = new byte[plainBytes.Length];

        using AesGcm aesGcm = new(key, TAG_SIZE);
        aesGcm.Encrypt(iv, plainBytes, cipher, tag);

        var buffer = new byte[iv.Length + tag.Length + cipher.Length];
        Buffer.BlockCopy(iv, 0, buffer, 0, iv.Length);
        Buffer.BlockCopy(tag, 0, buffer, iv.Length, tag.Length);
        Buffer.BlockCopy(cipher, 0, buffer, iv.Length + tag.Length, cipher.Length);

        return new BsonBinaryData(buffer, BsonBinarySubType.Encrypted);
    }

    public string Decrypt(BsonBinaryData encryptedData)
    {
        var iv = encryptedData.Bytes[..12];
        var tag = encryptedData.Bytes[12..28];
        var cipher = encryptedData.Bytes[28..];

        var decryptedBytes = new byte[cipher.Length];

        using AesGcm aesGcm = new(Convert.FromBase64String(_settings.EncryptionKey!), TAG_SIZE);
        aesGcm.Decrypt(iv, cipher, tag, decryptedBytes);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
