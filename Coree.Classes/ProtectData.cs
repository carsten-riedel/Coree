using System.Security.Cryptography;

namespace Coree.Classes
{
    public static class ProtectData
    {
        public static byte[] Protect(byte[] userData, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            return ProtectedData.Protect(userData, optionalEntropy, scope);
        }

        public static byte[] Unprotect(byte[] encryptedData, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            return ProtectedData.Unprotect(encryptedData, optionalEntropy, scope);
        }

        public static byte[] ProtectString(string userData, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            return ProtectData.Protect(System.Text.Encoding.Unicode.GetBytes(userData), optionalEntropy, scope);
        }

        public static string UnprotectString(byte[] encryptedData, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            return System.Text.Encoding.Unicode.GetString(ProtectData.Unprotect(encryptedData, optionalEntropy, scope));
        }

        public static string ProtectStringBase64(string userData, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            var _userDataUnicodeBytes = System.Text.Encoding.Unicode.GetBytes(userData);
            var _userDataUnicodeBytesEncrypted = ProtectData.Protect(_userDataUnicodeBytes, optionalEntropy, scope);
            var _userDataUnicodeBytesEncryptedBase64 = System.Convert.ToBase64String(_userDataUnicodeBytesEncrypted);
            return _userDataUnicodeBytesEncryptedBase64;
        }

        public static string UnprotectStringBase64(string encryptedDataBase64, byte[]? optionalEntropy, DataProtectionScope scope)
        {
            var _encryptedDataBase64Bytes = System.Convert.FromBase64String(encryptedDataBase64);
            var _encryptedDataBase64BytesDecrypted = ProtectData.Unprotect(_encryptedDataBase64Bytes, optionalEntropy, scope);
            var _encryptedDataBase64BytesDecryptedUnicode = System.Text.Encoding.Unicode.GetString(_encryptedDataBase64BytesDecrypted);
            return _encryptedDataBase64BytesDecryptedUnicode;
        }


    }
}