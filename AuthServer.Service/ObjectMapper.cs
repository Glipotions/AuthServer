using AutoMapper;

namespace AuthServer.Service
{
    public class ObjectMapper
    {
        /// <summary>
        /// LazyLoading sadece ihtiyaç olduğu anda yani çağırıldığında yükler.
        /// Geç initialize işlemi sağlar yani..
        /// </summary>
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapperProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
