using System.Collections;

namespace Application.Util;

public static class MapperUtil
{
    public static AutoMapper.IMapper Mapper;
    public static IList<TDestiny> ToMap<TDestiny>(this IList current)
    {
        return Mapper.Map<IList<TDestiny>>(current)!;
    }
        
    public static TDestiny ToMap<TDestiny>(this object current)
    {
        return Mapper.Map<TDestiny>(current)!;
    }
    
    public static TDestiny ToMap<TDestiny>(this object current, TDestiny value)
    {
        return Mapper.Map(current, value)!;
    }
        
    public static object ToMap(this object current, Type typeDestiny)
    {
        return Mapper.Map(current, current.GetType(), typeDestiny)!;
    }
}