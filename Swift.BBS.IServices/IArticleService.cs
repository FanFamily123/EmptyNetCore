using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Swift.BBS.Model.Models;

namespace Swift.BBS.IServices
{
    public interface IArticleService:IBaseServices<Article>
    {
        // void Add(Article model);
        //
        // void Delete(Article model);
        // void Update(Article model);
        // List<Article> Query(Expression<Func<Article, bool>> whereExpression);
    }
}