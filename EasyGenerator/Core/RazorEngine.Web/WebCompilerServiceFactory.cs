namespace RazorEngine.Web
{
    using System;
    using System.Web.Razor.Parser;

    using Compilation;
    using CSharp;
    using VisualBasic;

    /// <summary>
    /// Provides a compiler service factory for web compiler services.
    /// </summary>
    public class WebCompilerServiceFactory : ICompilerServiceFactory
    {
        #region Methods
        /// <summary>
        /// Creates an instance of a compiler service.
        /// </summary>
        /// <param name="language">The language to support in templates.</param>
        /// <param name="strictMode">Strict mode forces parsing exceptions to be thrown.</param>
        /// <param name="markupParser">The markup parser to use.</param>
        /// <returns>An instance of <see cref="ICompilerService"/>.</returns>
        public ICompilerService CreateCompilerService(Language language = Language.CSharp, bool strictMode = false, MarkupParser markupParser = null)
        {
            switch (language)
            {
                case Language.CSharp:
                    return new CSharpWebCompilerService(strictMode, markupParser);
                case Language.VisualBasic:
                    return new VBWebCompilerService(strictMode, markupParser);
            }

            throw new ArgumentException("The language '" + language + "' is not supported.");
        }
        #endregion
    }
}
