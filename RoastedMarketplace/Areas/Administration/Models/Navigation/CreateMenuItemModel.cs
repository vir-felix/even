﻿using System.Collections.Generic;
using FluentValidation;
using RoastedMarketplace.Infrastructure.Mvc.Models;
using RoastedMarketplace.Infrastructure.Mvc.Validator;

namespace RoastedMarketplace.Areas.Administration.Models.Navigation
{
    public class CreateMenuItemModel : FoundationModel, IRequiresValidations<CreateMenuItemModel>
    {
        public IList<int> CategoryIds { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IList<int> ContentPageIds { get; set; }

        public int MenuId { get; set; }

        public int ParentMenuItemId { get; set; }

        public bool IsGroup { get; set; }

        public void SetupValidationRules(ModelValidator<CreateMenuItemModel> v)
        {
            v.RuleFor(x => x.MenuId).GreaterThan(0);
        }
    }
}