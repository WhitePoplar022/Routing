﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Routing
{
    /// <summary>
    /// Constrains a route by several child constraints.
    /// </summary>
    public class CompoundRouteConstraint : IRouteConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundRouteConstraint" /> class.
        /// </summary>
        /// <param name="constraints">The child constraints that must match for this constraint to match.</param>
        public CompoundRouteConstraint([NotNull] IList<IRouteConstraint> constraints)
        {
            Constraints = constraints;
        }

        /// <summary>
        /// Gets the child constraints that must match for this constraint to match.
        /// </summary>
        public IEnumerable<IRouteConstraint> Constraints { get; private set; }

        /// <inheritdoc />
        public bool Match([NotNull]HttpContext httpContext, [NotNull]IRouter route, [NotNull]string routeKey, [NotNull]IDictionary<string, object> values, RouteDirection routeDirection)
        {
            foreach (var constraint in Constraints)
            {
                if (!constraint.Match(httpContext, route, routeKey, values, routeDirection))
                {
                    return false;
                }
            }

            return true;
        }
    }
}