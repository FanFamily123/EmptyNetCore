using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Swift.BBS.IRepositories;
using Swift.BBS.IRepositories.Base;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Repositories;
using Swift.BBS.Services.Base;

namespace Swift.BBS.Services
{
    public class ArticleService:BaseServices<Article>,IArticleService
    {
        public ArticleService(IBaseRepository<Article> baseDal) : base(baseDal)
        {
        }
    }
}