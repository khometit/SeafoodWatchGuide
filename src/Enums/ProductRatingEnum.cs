﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This is the ENUM class for seafood ratings, which are displayed on each card and dictate
/// which section of the guide the fish card is displayed on.
/// </summary>
namespace ContosoCrafts.WebSite.Data
{
    /// <summary>
    /// Method declares the ENUMs for our product ratings
    /// </summary>
    public enum ProductRating
    {
        // EnumMember value is intened to convert the numerical ratings
        // in the JSON file to their respective ENUM. Still not working, bug logged
        UNKNOWN = 0,
        BEST_CHOICE = 1,
        GOOD_ALTERNATIVE = 2,
        AVOID = 3
    }
}