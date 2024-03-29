﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BusinessObject.Models;
using Microsoft.IdentityModel.Tokens;

namespace Utils.Authentication
{
    public class JwtToken
    {
        public JwtToken()
        {
        }

        public Claim[] GetClaims(User user) => new[] {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email ?? ""),
            new Claim("firstName", user.FirstName ?? ""),
            new Claim("lastName", user.LastName ?? ""),
            new Claim("phoneNumber", user.PhoneNumber ?? ""),
            new Claim("role", user.Role ?? ""),
            new Claim("address", user.Address ?? ""),
            new Claim("displayName", user.DisplayName ?? ""),
            new Claim("avatar", user.Avatar ?? ""),
            new Claim("hiddenData", user.HiddenData ?? "")
        };

        public User GetUser(IEnumerable<Claim> claims) => new User()
        {
            Id = claims.First(c => c.Type == "id").Value,
            Email = claims.First(c => c.Type == "email").Value,
            FirstName = claims.First(c => c.Type == "firstName").Value,
            LastName = claims.First(c => c.Type == "lastName").Value,
            PhoneNumber = claims.First(c => c.Type == "phoneNumber").Value,
            Role = claims.First(c => c.Type == "role").Value,
            Address = claims.First(c => c.Type == "address").Value,
            DisplayName = claims.First(c => c.Type == "displayName").Value,
            Avatar = claims.First(c => c.Type == "avatar").Value,
            HiddenData = claims.First(c => c.Type == "hiddenData").Value,
        };

        public string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvConfig.Get().ACCESS_TOKEN_SECRET);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user)),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvConfig.Get().REFRESH_TOKEN_SECRET);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user)),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User ValidateAccessToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvConfig.Get().ACCESS_TOKEN_SECRET);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return GetUser(jwtToken.Claims);
            }
            catch
            {
                return null;
            }
        }

        public User ValidateRefreshToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvConfig.Get().REFRESH_TOKEN_SECRET);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return GetUser(jwtToken.Claims);
            }
            catch
            {
                return null;
            }
        }
    }
}
