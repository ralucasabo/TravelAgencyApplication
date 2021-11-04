using System;

namespace Persoane.Repository
{
    internal class ServiceBehaviorAttribute : Attribute
    {
        public object ConcurrencyMode { get; set; }
    }
}