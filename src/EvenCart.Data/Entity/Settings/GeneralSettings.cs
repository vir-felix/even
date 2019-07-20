﻿using EvenCart.Core.Config;

namespace EvenCart.Data.Entity.Settings
{
    public class GeneralSettings : ISettingGroup
    {
        /// <summary>
        /// The domain where public website has been installed
        /// </summary>
        public string StoreDomain { get; set; }

        /// <summary>
        /// Default timezone to be used for network
        /// </summary>
        public string DefaultTimeZoneId { get; set; }

        /// <summary>
        /// The logo id of the website
        /// </summary>
        public int LogoId { get; set; }
      
        public int FaviconId { get; set; }

        public string StoreName { get; set; }

        public bool EnableBreadcrumbs { get; set; }

        public int PrimaryNavigationId { get; set; }

        public bool EnableJsBundling { get; set; }

        public bool EnableCssBundling { get; set; }

        public bool EnableHtmlMinification { get; set; }

        public string DefaultPageTitle { get; set; }

        public string DefaultMetaKeywords { get; set; }

        public string DefaultMetaDescription { get; set; }

        public string ActiveTheme { get; set; }
    }
}