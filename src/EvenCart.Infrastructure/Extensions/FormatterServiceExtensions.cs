﻿using EvenCart.Core.Infrastructure;
using EvenCart.Data.Extensions;
using EvenCart.Services.Formatter;

namespace EvenCart.Infrastructure.Extensions
{
    public static class FormatterServiceExtensions
    {
        public static string FormatCurrency(this IFormatterService formatterService, decimal amount, bool includeSymbol = true)
        {
            if (ApplicationEngine.IsAdmin())
                return formatterService.FormatCurrency(amount, ApplicationEngine.BaseCurrency.CultureCode,
                    includeSymbol, ApplicationEngine.BaseCurrency.CustomFormat);
            return formatterService.FormatCurrency(amount, ApplicationEngine.CurrentCurrency.CultureCode, includeSymbol, ApplicationEngine.BaseCurrency.CustomFormat);
        }

        public static string ToCurrency(this decimal amount)
        {
            var formatterService = DependencyResolver.Resolve<IFormatterService>();
            return formatterService.FormatCurrency(amount);
        }

        public static string ToCurrency(this decimal amount, string code)
        {
            if (code.IsNullEmptyOrWhiteSpace())
                return amount.ToCurrency();
            var formatterService = DependencyResolver.Resolve<IFormatterService>();
            return formatterService.FormatCurrencyFromIsoCode(amount, code);
        }

        public static string ToCurrency(this decimal? amount)
        {
            return ToCurrency(amount ?? 0);
        }
    }
}