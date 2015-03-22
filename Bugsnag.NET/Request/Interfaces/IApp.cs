﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugsnag.NET.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    public interface IApp
    {
        [JsonProperty("version")]
        string Version { get; }

        [JsonProperty("releaseStage")]
        string ReleaseStage { get; }
    }
}
