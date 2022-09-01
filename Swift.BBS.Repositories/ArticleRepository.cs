using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Swift.BBS.IRepositories;
using Swift.BBS.Model.Models;
using Swift.BBS.Repositories.Base;
using Swift.BBS.Repositories.EfContext;

namespace Swift.BBS.Repositories
{
    public class ArticleRepository :BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(SwiftCodeBbsContext context) : base(context)
        {
        }
    }
}