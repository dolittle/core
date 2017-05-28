﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Applications;

namespace doLittle.Events
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventSourceVersions"/>
    /// </summary>
    public class NullEventSourceVersions : IEventSourceVersions
    {
        /// <inheritdoc/>
        public EventSourceVersion GetFor(IApplicationResourceIdentifier eventSource, EventSourceId eventSourceId)
        {
            return EventSourceVersion.Zero;
        }

        /// <inheritdoc/>
        public void SetFor(IApplicationResourceIdentifier eventSource, EventSourceId eventSourceId, EventSourceVersion version)
        {
        }
    }
}