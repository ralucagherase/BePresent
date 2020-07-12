using System.Collections.Generic;

namespace BePresent.Repository.Interface
{
    public interface IPaginate<T>
    {
        /// <summary>
        /// Page selected
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Number of itemes per page
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Total itemes
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        int Pages { get; set; }

        /// <summary>
        /// List of items
        /// </summary>
        IList<T> Items { get; set; }

        /// <summary>
        /// If has previos page
        /// </summary>
        bool HasPrevios { get; set; }

        /// <summary>
        /// If has next page
        /// </summary>
        bool HasNext { get; set; }

    }
}
