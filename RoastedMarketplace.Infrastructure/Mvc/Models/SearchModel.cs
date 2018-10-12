﻿using FluentValidation;
using RoastedMarketplace.Infrastructure.Mvc.Validator;

namespace RoastedMarketplace.Infrastructure.Mvc.Models
{
    public abstract class SearchModel : FoundationModel, IRequiresValidations<SearchModel>
    {
        public string SearchPhrase { get; set; }

        public int Current { get; set; } = 1;

        public int RowCount { get; set; } = 15;

        public void SetupValidationRules(ModelValidator<SearchModel> v)
        {
            v.RuleFor(x => x.Current).GreaterThan(0);
            v.RuleFor(x => x.RowCount).GreaterThan(0);
        }
    }
}