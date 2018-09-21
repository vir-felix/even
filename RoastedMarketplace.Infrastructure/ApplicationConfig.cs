﻿namespace RoastedMarketplace.Infrastructure
{
    public static class ApplicationConfig
    {
        public const string ApiEndpointName = "api";

        public const string DefaultAuthenticationScheme = "AppAuthentication";

        public const string ApiAuthenticationScheme = "ApiAuthentication";

        public const string ExternalAuthenticationScheme = "External";

        public const string DefaultLoginUrl = "/Authentication/Login";

        public const string GlobalLanguagesDirectory = "~/App_Data/Languages";

        public const string MediaDirectory = "~/Content/Uploads";

        public const string MediaServeDirectory = "~/Content/Uploads/Serves";

        public const string DefaultImagePath = "~/Content/Uploads/_Default.jpg";

        public const string AdminAreaName = "admin";

        public const int AdminThumbnailWidth = 100;

        public const int AdminThumbnailHeight = 100;
    }
}