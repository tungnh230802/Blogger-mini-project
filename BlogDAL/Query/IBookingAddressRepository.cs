using BlogDAL.Models;
using SES.HomeServices.Data.Queries.Abstractions;
using System;

namespace SES.HomeServices.Data.Repositories.Abstractions
{
    /// <summary>
    /// IPostRepository
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Build Booking Address query
        /// </summary>
        /// <returns></returns>
        IPostQuery BuildQuery();
    }
}
