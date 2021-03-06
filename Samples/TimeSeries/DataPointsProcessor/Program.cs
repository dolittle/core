﻿// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Heads;

namespace PullConnector
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Bootloader.Start();
        }
    }
}