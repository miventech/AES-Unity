using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

namespace Miventech.Security.AES
{
    public static class UnityManagerAES
    {

        static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    // AES.Key = passwordBytes;
                    // AES.IV = new byte[]{
                    //     0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                    // };
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }



        /// <summary>
        /// Desencripta un string en base64 usando una clave como referencia
        /// y optener un string con la informacion original 
        /// </summary>
        /// <param name="data">Data a Desencriptar en formato base64</param>
        /// <param name="password">Clave para desencriptar la data</param>
        /// <returns>Retorna un string con la data des-encriptada </returns>
        public static string DecryptString(string data, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(data);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);
            return result;
        }
        /// <summary>
        /// Desencripta un Array Bytes usando una clave como referencia
        /// y optener un string con la informacion original 
        /// </summary>
        /// <param name="bytesToBeDecrypted">Data a Desencriptar</param>
        /// <param name="password">Clave para desencriptar la data</param>
        /// <returns>Retorna un string con la data des-encriptada</returns>
        public static string DecryptString(byte[] bytesToBeDecrypted, string password)
        {
            // Get the bytes of the string
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);
            return result;
        }


        /// <summary>
        /// Encriptar una cadena de string, en base a una clave en string.
        /// </summary>
        /// <param name="StringToEncrypt"></param>
        /// <param name="password"></param>
        /// <returns>Byte Array data</returns>
        public static byte[] EncryptToBytes(string StringToEncrypt, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(StringToEncrypt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            Debug.Log(passwordBytes.Length);
            byte[] bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
            return bytesEncrypted;
        }


        /// <summary>
        /// Encriptar una cadena de string, en base a una clave en string.
        /// </summary>
        /// <param name="StringToEncrypt"></param>
        /// <param name="password"></param>
        /// <returns>String en formato base64</returns>
        public static string EncryptToString(string StringToEncrypt, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(StringToEncrypt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            Debug.Log(passwordBytes.Length);
            byte[] bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }
    }
}
