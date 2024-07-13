using Google.Cloud.Kms.V1;
using Google.Protobuf;
using System.IO;
using System.Text;
using System;

namespace SampleMvcApp.KMS
{
    public class DecryptDataExample
    {
        public string DecryptSymmetric(
     string base64Ciphertext, string projectId = "lofty-psyche-429104-r5", string locationId = "global", string keyRingId = "Seguridad", string keyId = "SeguridadClave")
        {
            string credentialFileName = "lofty-psyche-429104-r5-9aabfb67e5fb.json";
            string CredentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", credentialFileName);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the Base64 string to byte array
            byte[] ciphertext = Convert.FromBase64String(base64Ciphertext);

            // Call the API.
            DecryptResponse result = client.Decrypt(keyName, ByteString.CopyFrom(ciphertext));

            // Get the plaintext. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = result.Plaintext.ToByteArray();

            // Return the result.
            return Encoding.UTF8.GetString(plaintext);
        }

    }
}
