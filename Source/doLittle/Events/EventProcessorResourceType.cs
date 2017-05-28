/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Applications;

namespace doLittle.Events
{
    /// <summary>
    /// Represents a <see cref="IApplicationResourceType">application resource type</see> for 
    /// <see cref="IProcessEvents">event processors</see>
    /// </summary>
    public class EventProcessorResourceType : IApplicationResourceType
    {
        /// <inheritdoc/>
        public string Identifier => "EventProcessor";

        /// <inheritdoc/>
        public Type Type => typeof(IProcessEvents);

        /// <inheritdoc/>
        public ApplicationArea Area => ApplicationAreas.Events;
    }
}