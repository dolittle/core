﻿#region License
//
// Copyright (c) 2008-2012, DoLittle Studios AS and Komplett ASA
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// With one exception :
//   Commercial libraries that is based partly or fully on Bifrost and is sold commercially, 
//   must obtain a commercial license.
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://bifrost.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Execution;

namespace Bifrost.Security
{
    /// <summary>
    /// Represents an implementation of <see cref="ISecurityManager"/>
    /// </summary>
    public class SecurityManager : ISecurityManager
    {
        readonly ITypeDiscoverer _typeDiscoverer;
        readonly IContainer _container;
        IEnumerable<ISecurityDescriptor> _securityDescriptors;

        /// <summary>
        /// Initializes a new instance of <see cref="SecurityManager"/>
        /// </summary>
        /// <param name="typeDiscoverer"><see cref="ITypeDiscoverer"/> to discover any <see cref="SecurityDescriptor">security descriptors</see></param>
        /// <param name="container"><see cref="IContainer"/> to instantiate instances of <see cref="ISecurityDescriptor"/></param>
        public SecurityManager(ITypeDiscoverer typeDiscoverer, IContainer container)
        {
            _typeDiscoverer = typeDiscoverer;
            _container = container;

            PopulateSecurityDescriptors();
        }

        void PopulateSecurityDescriptors()
        {
            var securityDesciptorTypes = _typeDiscoverer.FindMultiple<ISecurityDescriptor>();
            var instances = new List<ISecurityDescriptor>();
            instances.AddRange(securityDesciptorTypes.Select(t => _container.Get(t) as ISecurityDescriptor));
            _securityDescriptors = instances;
        }

#pragma warning disable 1591 // Xml Comments
        public bool IsAuthorized<T>(object target) where T : ISecurityAction
        {
            if (!_securityDescriptors.Any())
                return true;

            var applicableSecurityDescriptors = _securityDescriptors.Where(sd => sd.CanAuthorize<T>(target));

            return !applicableSecurityDescriptors.Any() || applicableSecurityDescriptors.All(sd => sd.Authorize(target).IsAuthorized);
        }
#pragma warning restore 1591 // Xml Comments
    }
}
