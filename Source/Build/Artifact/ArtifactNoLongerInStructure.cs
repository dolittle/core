/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Runtime.Serialization;

namespace Dolittle.Build.Artifact
{
    internal class ArtifactNoLongerInStructure : Exception
    {
        public ArtifactNoLongerInStructure() : base("Found artifacts that doesn't exist anymore. Since we have not formalized artifact migration yet the build has to fail")
        {
        }
    }
}