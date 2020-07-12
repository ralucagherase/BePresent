using BePresent.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BePresent.Repository.Implementation.Paging
{
    public class Paginate<T> : IPaginate<T>
    {
        internal Paginate()
        {
            Items = new T[0];
        }
        internal Paginate(IQueryable<T> source, int page, int size)
        {
            if (page <= 0)
            {
                throw new ArgumentException("Page must be greather than 1");
            }
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greather than 1");
            }

            Page = page;

            Size = size;

            TotalCount = source.Count();

            Pages = (int)Math.Ceiling(TotalCount / (double)size);

            Items = source.Skip((page - 1) * size).Take(size).ToList();

            HasPrevios = page == 1 ? false : true;
            HasNext = page < Pages ? true : false;
        }

        public int Page { get; set; }

        public int Size { get; set; }

        public int TotalCount { get; set; }

        public int Pages { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPrevios { get; set; }

        public bool HasNext { get; set; }
    }
}
