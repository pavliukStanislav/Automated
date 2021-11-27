using Automated.Configurations.Binders;
using Automated.Configurations.DTOs;
using System;

namespace Automated.Configurations
{
    public static class Credentials
    {
        public static readonly UserData Data = new UserData
        {
            User = CredentialsConfiguration.UserData.User ?? new UserData.Credentials
            {
                Email = Environment.GetEnvironmentVariable("userEmail"),
                Password = Environment.GetEnvironmentVariable("userPassword")                
            },

            Admin = CredentialsConfiguration.UserData.Admin ?? new UserData.Credentials 
            {
                Email = Environment.GetEnvironmentVariable("adminEmail"),
                Password = Environment.GetEnvironmentVariable("adminPassword")
            }
        };
    }
}