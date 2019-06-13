﻿using System.Collections.Generic;
using EvenCart.Core.Services;
using EvenCart.Data.Entity.Common;

namespace EvenCart.Services.Common
{
    public interface ICustomLabelService : IFoundationEntityService<CustomLabel>
    {
        IEnumerable<CustomLabel> Get(IList<CustomLabelType> enumTypes, out int totalResults, int page = 1,
            int count = int.MaxValue);

        IEnumerable<CustomLabel> GetCustomLabels(CustomLabelType enumType, out int totalResults, string searchText = null, int page = 1,
            int count = int.MaxValue);
    }
}