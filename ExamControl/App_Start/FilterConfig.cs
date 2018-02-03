namespace ExamControl
{
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="FilterConfig" />
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// The RegisterGlobalFilters
        /// </summary>
        /// <param name="filters">The <see cref="GlobalFilterCollection"/></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
