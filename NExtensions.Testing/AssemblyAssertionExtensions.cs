using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NExtensions.Testing
{
    public static class AssemblyAssertionExtensions
    {
        //this assertion method courtesy of Phil Haack: http://haacked.com/archive/2014/11/11/async-void-methods/
        public static void AssertNoAsyncVoidMethods(this Assembly assembly)
        {
            var messages = assembly
                .GetAsyncVoidMethods()
                .Select(method =>
                    String.Format("'{0}.{1}' is an async void method.",
                        method.DeclaringType.Name,
                        method.Name))
                .ToList();
            Assert.False(messages.Any(),
                "Async void methods found!" + Environment.NewLine + String.Join(Environment.NewLine, messages));
        }         
    }
}