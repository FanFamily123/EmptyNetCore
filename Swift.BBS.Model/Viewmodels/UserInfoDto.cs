using Swift.BBS.Model.RootTKey;

namespace Swift.BBS.Model.Viewmodels
{
    public class UserInfoDto:EntityTKeyDto<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 文章数量
        /// </summary>
        public long ArticlesCount { get; set; }
        /// <summary>
        /// 问答数量
        /// </summary>
        public long QuestionsCount { get; set; } 
    }
}