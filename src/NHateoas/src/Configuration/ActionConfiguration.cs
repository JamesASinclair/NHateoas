﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using NHateoas.Routes;
using NHateoas.Routes.RouteNameBuilders;
using NHateoas.Routes.RoutesBuilders;

namespace NHateoas.Configuration
{
    internal class ActionConfiguration
    {
        private readonly List<MappingRule> _mappingRules = new List<MappingRule>();
        private IRouteNameBuilder _routeNameBuilder = null;
        private IRoutesBuilder _routesBuilder = null;
        public void AddMappingRule(MappingRule rule)
        {
            _mappingRules.Add(rule);
        }

        public IEnumerable<MappingRule> MappingRules
        {
            get { return _mappingRules; }
        }

        public IRouteNameBuilder RouteNameBuilder
        {
            get { return _routeNameBuilder ?? (_routeNameBuilder = new DefaultRouteNameBuilder()); }
            set { _routeNameBuilder = value; }
        }

        public IRoutesBuilder RoutesBuilder
        {
            get { return _routesBuilder ?? (_routesBuilder = new DefaultRoutesBuilder()); }
            set { _routesBuilder = value; }
        }

        public bool RulesHasBeenBuilt
        {
            get { return _mappingRules.Any(rule => rule.HasUrls()); }
        }
    }
}
