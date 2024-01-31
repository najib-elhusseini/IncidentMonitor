using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class NotificationUsersHelper : EntityHelper<NotificationUser, int>
    {
        private byte[] IV => new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        private string _key = "UwVQBuUMvI/7rLnFnYGD7w==";
        private byte[] _keyBuffer => Convert.FromBase64String(_key);
        private string _passPhrase = "Hoist-pass-1234-12";

        public NotificationUsersHelper(DataContext context) : base(context)
        {
        }

        public override async Task<NotificationUser> Find(int key)
        {
            var result = await Connection
                .QueryAsync<NotificationUser>("SELECT * FROM NotificationUser WHERE Id=@id", key);
            if (result == null || !result.Any())
            {
                return null;
            }
            var user = result[0];
            if (user.AppPassword != null)
            {                
                user.AppPassword = await DecryptAsync(user.AppPassword);
            }
            return user;

        }



        public override async Task<List<NotificationUser>> GetAllAsync()
        {
            var users = await base.GetAllAsync();
            var su = users.FirstOrDefault(u => u.Email == "su");
            if (su == null)
            {
                // IsActive is used for sending notifications and not for 
                // the activation state of a user 

                var appPassword = EncryptAsync("123456").Result;
                var appPasswordString = Convert.ToBase64String(appPassword);
                su = new NotificationUser()
                {
                    FirstName = "Super",
                    LastName = "User",
                    Email = "su",
                    AppPassword = appPasswordString,
                    IsSuperUser = true,
                    IsActive = true,
                    ReceivesNotifications = false,
                };
                await InsertAsync(su);
                users.Add(su);
            }

            return users;
        }

        public async Task<IEnumerable<NotificationUser>> GetUsersToNotifyAsync()
        {
            var users = await GetAllAsync();
            users = users.Where(u => u.CanReceiveEmailNotifications)
                .ToList();
            return users;
        }

        public async Task<List<NotificationUser>> GetLoginUsersAsync()
        {
            var users = await GetAllAsync();
            users = users.Where(u => u.CanLogin == true).ToList();
            return users;
        }

        public async Task<NotificationUser?> GetUserByEmailAsync(string email, bool decryptPassword)
        {
            var result = await Connection
                .QueryAsync<NotificationUser>("SELECT * FROM NotificationUser WHERE Email=@email", email);
            if (result == null || !result.Any())
            {
                return null;
            }
            var user = result[0];
            if (decryptPassword && user.AppPassword != null)
            {
                user.AppPassword = await DecryptAsync(user.AppPassword);
            }
            return user;
        }



        #region  Encryption methods

        private byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }

        public async Task<byte[]> EncryptAsync(string clearText)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(_passPhrase);
            aes.IV = IV;

            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();

            return output.ToArray();
        }

        public async Task<string> DecryptAsync(byte[] encrypted)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(_passPhrase);
            aes.IV = IV;

            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);

            return Encoding.Unicode.GetString(output.ToArray());
        }

        public async Task<string> DecryptAsync(string base64String)
        {
            var buffer = Convert.FromBase64String(base64String);
            return await DecryptAsync(buffer);
        }


        #endregion



    }
}
