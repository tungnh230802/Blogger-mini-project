using BlogDAL.Models;
using SES.HomeServices.Data.Queries.Abstractions;
using System;
using System.Linq;

namespace SES.HomeServices.Data.Queries
{
    public class PostQuery : QueryBase<Post>, IPostQuery
    {
        private readonly BlogContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name = "masterDataQuery" ></ param >
        /// < param name="dbContext"></param>
        public PostQuery(IQueryable<Post> PostQuery, BlogContext dbContext) : base(PostQuery)
        { _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); }



        /// <summary>
        /// FilterByUserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IPostQuery FilterByUserId(Guid userId)
        {
            Query = Query.Where(type => type.authorId == userId);
            return this;
        }

        //public async Task<Post> FilterDefaultAddressAsync(Guid userId)
        //{
        //    Query = Query.Where(type => type.IsActive == true
        //                              && type.IsDefault == true
        //                              && type.UserId == userId
        //                              && (type.IsUsed == true || type.IsUsed == null));
        //    return await Query.FirstOrDefaultAsync().ConfigureAwait(false);
        //}

        /// <summary>
        /// FilterIsActive
        /// </summary>
        /// <param name="isActice"></param>
        /// <returns></returns>
        //public IPostQuery FilterIsActive(bool? isActice)
        //{
        //    Query = Query.Where(type => isActice == null || type.IsActive == isActice);
        //    return this;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //public Post FilterById(Guid Id, Guid userId)
        //{

        //    Query = Query.Where(type => type.id == Id
        //                                && type.authorId == userId
        //                                && (type.IsUsed == true || type.IsUsed == null));
        //    return Query.FirstOrDefault();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contatId"></param>
        /// <returns></returns>
        //public Post FilterByContactId(long? contatId, string userId)
        //{
        //    Query = Query.Where(type => type.ChildContactId == contatId
        //                                && type.IsActive == true
        //                                && type.UserId == userId
        //                                && (type.IsUsed == true || type.IsUsed == null));
        //    return Query.FirstOrDefault();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public async Task<List<Post>> GetByUserIdAsync(string userId)
        //{
        //    Query = Query.Where(type => type.UserId == userId
        //                                && type.IsActive == true
        //                                && (type.IsUsed == true || type.IsUsed == null));
        //    return await Query.OrderByDescending(x => x.CreatedAt).ToListAsync().ConfigureAwait(false);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public async Task<List<Post>> GetAllByUserIdAsync(string userId)
        //{
        //    Query = Query.Where(type => type.UserId == userId
        //                                && type.IsActive == true);
        //    return await Query.OrderByDescending(x => x.CreatedAt).ToListAsync().ConfigureAwait(false);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="postcode"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        //public async Task<Post> FilterCheckExistAddress(string UserId, string Address)
        //{
        //    Query = Query.Where(type => type.UserId == UserId
        //                                && type.Address == Address);
        //    //&& (type.IsActive == true || type.IsActive == false || type.IsActive == null)
        //    //&& (type.IsDeleted == true || type.IsDeleted == false || type.IsDeleted == null)
        //    //&& type.HouseNumber == houseNumber
        //    //&& type.City == city
        //    //&& type.Street == street);
        //    return await Query.FirstOrDefaultAsync().ConfigureAwait(false);
        //}

        //public IPostQuery FilterIsBooking(bool? isActice)
        //{
        //    Query = Query.Where(type => type.IsBooking == isActice);
        //    return this;
        //}
    }
}
