﻿namespace Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";
        public MongoDbSettings MongoDbSettings { get; set; }
        public SecuritySettings SecuritySettings { get; set; }
    }
}