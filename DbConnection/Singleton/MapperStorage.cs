using AutoMapper;

namespace DbConnection.Singleton
{
    public class MapperStorage
    {
        private static IMapper? _mapper;
        public static IMapper Mapper
        {
            get
            {
                _mapper ??= MapperConfig.InitializeAutomapper();
                return _mapper;
            }
        }
    }
}
