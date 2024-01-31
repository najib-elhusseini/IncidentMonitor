using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
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
        private byte[] _iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        private string _password = "Hoist@leb123!#$";

        public NotificationUsersHelper(DataContext context) : base(context)
        {
        }

        public override async Task<List<NotificationUser>> GetAllAsync()
        {
            var users = await base.GetAllAsync();
            var su = users.FirstOrDefault(u => u.Email == "su");
            if (su == null)
            {
                // IsActive is used for sending notifications and not for 
                // the activation state of a user 

                var appPassword = await EncryptAndEncodeAsync("123456");
                su = new NotificationUser()
                {
                    FirstName = "Super",
                    LastName = "User",
                    Email = "su",
                    AppPassword = appPassword,
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
                user.AppPassword = await DecryptEncodedAsync(user.AppPassword);
            }
            return user;
        }


        public async Task<string> EncryptAndEncodeAsync(string clearText)
        {
            var bytes = await EncryptPasswordAsync(clearText);
            return Encoding.Unicode.GetString(bytes);
        }

        public async Task<string> DecryptEncodedAsync(string encrypted)
        {
            var bytes = Encoding.Unicode.GetBytes(encrypted);
            return await DecryptAsync(bytes);
        }

        #region Private Encryption methods
        private async Task<byte[]> EncryptPasswordAsync(string clearText)
        {
            using Aes aes = Aes.Create();
            aes.IV = _iv;
            aes.Key = DeriveKeyFromPassword();
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream crypto = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await crypto.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await crypto.FlushFinalBlockAsync();

            var result = memoryStream.ToArray();
            return result ?? ""u8.ToArray();

        }

        private async Task<string> DecryptAsync(byte[] encrypted)
        {
            using Aes aes = Aes.Create();
            aes.IV = _iv;
            aes.Key = DeriveKeyFromPassword();
            //aes.IV = IV;
            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.Unicode.GetString(output.ToArray());
        }
        private byte[] DeriveKeyFromPassword()
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(_password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }
        #endregion



    }
}
