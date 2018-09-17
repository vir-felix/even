﻿#region Author Information
// IRequiresValidation.cs
// 
// (c) 2016 Apexol Technologies. All Rights Reserved.
// 
#endregion

namespace RoastedMarketplace.Infrastructure.Mvc.Validator
{
    public interface IRequiresValidations<T>
    {
        void SetupValidationRules(ModelValidator<T> v);
    }
}