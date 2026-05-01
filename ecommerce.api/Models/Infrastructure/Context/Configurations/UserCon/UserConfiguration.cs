using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon
{
    public class UserConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasData(User());
        }

        private UserApp User()
        {
            var user = new UserApp
            {
                //Id = Guid.Parse("FF4DBF3C-CE20-4E35-BEFD-1F1D89BD56D5"),
                Email = "xxx@xxx.com",
                PhoneNumber = "0(000) 000 00 00",
                Name = "Xxxxxxx",
                SurName = "Xxx",
                UserName = "xxx",
                NormalizedUserName = "XXX",
                NormalizedEmail = "XXX@XXX.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Salt = CreatePasswordHash("Xxx123.").Item2,
                PasswordHash = CreatePasswordHash("Xxx123.").Item1                
            };
            return user;
        }

        private Tuple<string, string> CreatePasswordHash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return Tuple.Create(hashed, salt.ToString())!;
        }


    }
}
