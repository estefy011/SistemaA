namespace SampleMvcApp.KMS
{
    using Google.Cloud.Kms.V1;
    using Google.Protobuf;
    using System;
    using System.IO;
    using System.Text;

    public class EncryptDataExample
    {
        public string EncryptSymmetric(
         string message = "Este es un mensaje cifrado",
       string projectId = "lofty-psyche-429104-r5", string locationId = "global", string keyRingId = "Seguridad", string keyId = "SeguridadClave")
        {
            string credentialFileName = "lofty-psyche-429104-r5-9aabfb67e5fb.json";
            string CredentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", credentialFileName);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

            // Create the client.
            KeyManagementServiceClient client = KeyManagementServiceClient.Create();

            // Build the key name.
            CryptoKeyName keyName = new CryptoKeyName(projectId, locationId, keyRingId, keyId);

            // Convert the message into bytes. Cryptographic plaintexts and ciphertexts are always byte arrays.
            byte[] plaintext = Encoding.UTF8.GetBytes(message);

            // Call the API.
            EncryptResponse result = client.Encrypt(keyName, ByteString.CopyFrom(plaintext));

            // Convert the ciphertext to a Base64 string.
            string encryptedMessage = Convert.ToBase64String(result.Ciphertext.ToByteArray());

            return encryptedMessage;
        }

    }

}
