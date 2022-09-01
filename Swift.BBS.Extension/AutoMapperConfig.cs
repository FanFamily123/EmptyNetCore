using AutoMapper;

namespace Swift.BBS.Extension
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                  cfg.AddProfile(new UserInfoProfile());
                cfg.AddProfile(new ArticlePorfile());
                // cfg.AddProfile(new QuestionProfile());
            });
        }
    }
}