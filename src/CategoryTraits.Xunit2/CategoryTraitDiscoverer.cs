// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryTraitDiscoverer.cs" company="Wes Day">
//   The MIT License (MIT)
//   
//   Copyright (c) 2015 Wes Day
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of
//   this software and associated documentation files (the "Software"), to deal in
//   the Software without restriction, including without limitation the rights to
//   use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//   the Software, and to permit persons to whom the Software is furnished to do so,
//   subject to the following conditions:
//   
//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//   FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CategoryTraits.Xunit2
{
    using System.Collections.Generic;

    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    /// This class discovers all of the xUnit tests and test classes that have
    /// applied the TraitDiscoverer attribute for this trait discoverer.
    /// This class is referenced for example by the Visual Studio test explorer to discover test traits such as unit tests or integration tests.
    /// Originally derived from the <a href="https://github.com/xunit/samples.xunit/tree/master/TraitExtensibility">xUnit TraitExtensibility Sample</a>.
    /// </summary>
    public class CategoryTraitDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The namespace of this class
        /// </summary>
        internal const string Namespace = nameof(CategoryTraits) + "." + nameof(Xunit2);

        /// <summary>
        /// The fully qualified name of this class
        /// </summary>
        internal const string FullyQualifiedName = Namespace + "." + nameof(CategoryTraitDiscoverer);

        /// <summary>
        /// Gets the trait values from the Category attribute.
        /// </summary>
        /// <param name="traitAttribute">
        /// The trait attribute containing the trait values.
        /// </param>
        /// <returns>
        /// The trait values.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var categoryValue = traitAttribute.GetNamedArgument<string>("Category");

            if (!string.IsNullOrWhiteSpace(categoryValue))
            {
                yield return new KeyValuePair<string, string>("Category", categoryValue);
            }
        }
    }
}
