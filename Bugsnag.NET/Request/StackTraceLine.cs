﻿using Bugsnag.NET.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bugsnag.NET.Request
{
    public class StackTraceLine : IStackTraceLine
    {
        public static IEnumerable<IStackTraceLine> Build(Exception ex)
        {
            foreach (var line in ex.ToLines())
            {
                yield return new StackTraceLine
                {
                    File = line.ParseFile(),
                    LineNumber = line.ParseLineNumber(),
                    Method = line.ParseMethodName()
                };
            }
        }

        public string File { get; private set; }

        public int LineNumber { get; private set; }

        public int? ColumnNumber { get; private set; }

        public string Method { get; private set; }

        public bool InProject { get; private set; }
    }
}
