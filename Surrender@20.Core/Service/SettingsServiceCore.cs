﻿using Surrender_20.Core.Interface;
using System.Collections.Generic;

namespace Surrender_20.Core.Service
{
    public abstract class AbstractSettingsService : ISettingsService
    {
        protected readonly Dictionary<NewsCategory, CategoryData> categories;

        protected delegate void OnTitleChange(PostTitleArgs args);
        protected event OnTitleChange TitleChanged;

        public AbstractSettingsService()
        {
            categories = new Dictionary<NewsCategory, CategoryData>();

            WebsiteHistoryData = new WebsiteHistoryData();

            this[NewsCategory.None] = new CategoryData { Title = "Settings" };

            this[NewsCategory.SurrenderHome] = new CategoryData { Title = "Home", CategoryURL = "https://www.surrenderat20.net/", Website = NewsWebsite.Surrender };
            this[NewsCategory.PBE] = new CategoryData { Title = "PBE", CategoryURL = "https://www.surrenderat20.net/search/label/PBE/", Website = NewsWebsite.Surrender };
            this[NewsCategory.Releases] = new CategoryData { Title = "Releases", CategoryURL = "https://www.surrenderat20.net/search/label/Releases", Website = NewsWebsite.Surrender };
            this[NewsCategory.RedPosts] = new CategoryData { Title = "Red Posts", CategoryURL = "https://www.surrenderat20.net/search/label/Red%20Posts", Website = NewsWebsite.Surrender };
            this[NewsCategory.Rotations] = new CategoryData { Title = "Rotations", CategoryURL = "https://www.surrenderat20.net/search/label/Rotations", Website = NewsWebsite.Surrender };
            this[NewsCategory.ESports] = new CategoryData { Title = "E-Sports", CategoryURL = "https://www.surrenderat20.net/search/label/Esports", Website = NewsWebsite.Surrender };
            this[NewsCategory.Official] = new CategoryData { Title = "League of Legends Official", CategoryURL = "https://eune.leagueoflegends.com/en/news", Website = NewsWebsite.LoL };
            this[NewsCategory.Dev] = new CategoryData { Title = "Dev", CategoryURL = "https://eune.leagueoflegends.com/en/news", Website = NewsWebsite.LoL };
        }

        public CategoryData this[NewsCategory Category]
        {
            get => categories.TryGetValue(Category, out CategoryData value) ? value : null;
            set => categories.Add(Category, value);
        }

        public abstract ApplicationTheme Theme { get; set; }
        public abstract int NewPostCheckFrequency { get; set; }
        public abstract bool HasNotificationsEnabled { get; set; }
        public WebsiteHistoryData WebsiteHistoryData { get; set; }

        protected class PostTitleArgs
        {
            public NewsWebsite Category { get; set; }
            public string Title { get; set; }
        }
    }
}