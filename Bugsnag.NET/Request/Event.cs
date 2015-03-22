﻿using Bugsnag.NET.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugsnag.NET.Request
{
    class Event : IEvent
    {
        public Event(Exception ex)
        {
            Errors = ex.Unwrap().Select(e => new Error(e));
            GroupingHash = ex.GetType().Name;
            Context = string.Format("{0}::{1}",
                ex.TargetSite.DeclaringType,
                ex.TargetSite.Name);
        }

        string _payloadVersion = "2";

        public string PayloadVersion
        {
            get { return _payloadVersion; }
            set { _payloadVersion = value; }
        }

        IEnumerable<IError> _errors;

        public IEnumerable<IError> Errors
        {
            get { return _errors ?? Enumerable.Empty<IError>(); }
            set { _errors = value; }
        }

        IEnumerable<IThread> _threads;

        public IEnumerable<IThread> Threads
        {
            get { return _threads ?? Enumerable.Empty<IThread>(); }
            set { _threads = value; }
        }

        public string Context { get; set; }

        public string GroupingHash { get; set; }

        public string Severity { get; set; }

        public IUser User { get; set; }

        public IApp App { get; set; }

        public IDevice Device { get; set; }

        public object MetaData { get; set; }
    }
}
