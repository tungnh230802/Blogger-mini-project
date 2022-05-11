using BlogDAL.Models;
using System;

namespace SES.HomeServices.Data.Queries.Abstractions
{
    /// <summary>
    /// IPostQuery
    /// </summary>
    public interface IPostQuery : IQuery<Post>
    {
        /// <summary>
        /// FilterIsActive
        /// </summary>
        /// <param name="isActice"></param>
        /// <returns></returns>
        //IPostQuery FilterIsActive(bool? isActice);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActice"></param>
        /// <returns></returns>
        //IPostQuery FilterIsBooking(bool? isActice);

        /// <summary>
        /// FilterByUserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IPostQuery FilterByUserId(Guid userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Task<List<Post>> GetByUserIdAsync(string userId);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //Task<List<Post>> GetAllByUserIdAsync(string userId);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="contatId"></param>
        ///// <returns></returns>
        //Post FilterByContactId(long? contatId, string userId);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //Post FilterById(string Id, string UserId);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="childContactId"></param>
        ///// <returns></returns>
        //Task<Post> FilterDefaultAddressAsync(string userId);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="UserId"></param>
        ///// <param name="postcode"></param>
        ///// <param name="Address"></param>
        ///// <returns></returns>
        //Task<Post> FilterCheckExistAddress(string UserId, string Address);
    }
}
