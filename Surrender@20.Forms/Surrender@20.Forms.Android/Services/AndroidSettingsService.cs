﻿using Android.App;
using Android.Preferences;
using LeagueOfNews.Core.Interface;
using LeagueOfNews.Forms.Services;

namespace LeagueOfNews.Forms.Droid.Services
{
    public class AndroidSettingsService : FormsSettingsService
    {

        private const string LAST_POST_KEY_SURRENDER = "LAST_POST_KEY_SURRENDER";
        private const string LAST_POST_KEY_OFFICIAL = "LAST_POST_KEY_OFFICIAL";
        private const string CHECK_NEW_POSTS_FREQUENCY = "CHECK_NEW_POSTS_FREQUENCY";
        private const string THEME = "THEME";
        private const string IS_NOTIFICATIONS_ENABLED = "IS_NOTIFICATIONS_ENABLED";

        public AndroidSettingsService() : base()
        {
            TitleChanged += SaveTitle;

            WebsiteHistoryData.LastOfficialPostUrl = PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                .GetString(PageToKey(NewsWebsite.LoL), "");

            WebsiteHistoryData.LastSurrenderPostUrl = PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                .GetString(PageToKey(NewsWebsite.Surrender), "");
        }

        private void SaveTitle(PostTitleArgs args)
        {
            switch (args.Category)
            {
                case NewsWebsite.LoL: WebsiteHistoryData.LastOfficialPostUrl = args.Title; break;
                case NewsWebsite.Surrender: WebsiteHistoryData.LastSurrenderPostUrl = args.Title; break;
                default: break;
            }

            PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                 .Edit()
                 .PutString(PageToKey(args.Category), args.Title)
                 .Apply();
        }

        public override ApplicationTheme Theme
        {
            get => (ApplicationTheme)PreferenceManager.GetDefaultSharedPreferences(Application.Context).GetInt(THEME, (int)ApplicationTheme.Dark);
            set
            {
                PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                    .Edit()
                    .PutInt(THEME, (int)value)
                    .Apply();
                SetAppTheme();
            }
        }
        public override int NewPostCheckFrequency
        {
            get => PreferenceManager.GetDefaultSharedPreferences(Application.Context).GetInt(CHECK_NEW_POSTS_FREQUENCY, 2);
            set => PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                .Edit()
                .PutInt(CHECK_NEW_POSTS_FREQUENCY, value)
                .Apply();
        }
        public override bool HasNotificationsEnabled
        {
            get => PreferenceManager.GetDefaultSharedPreferences(Application.Context).GetBoolean(IS_NOTIFICATIONS_ENABLED, true);
            set => PreferenceManager.GetDefaultSharedPreferences(Application.Context)
                    .Edit()
                    .PutBoolean(IS_NOTIFICATIONS_ENABLED, value)
                    .Apply();
        }

        private string PageToKey(NewsWebsite page)
        {
            switch (page)
            {
                case NewsWebsite.Surrender: return LAST_POST_KEY_SURRENDER;
                case NewsWebsite.LoL: return LAST_POST_KEY_OFFICIAL;
            }
            return null;
        }
    }
}