AutoMapper
==========
Setup
-----
class FooProfile : AutoMapper.Profile {}
var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new FooProfile());
    cfg.CreateMap<Foo, Bar>();
});
var mapper = mapperConfiguration.CreateMapper();

Usage
-----
mapper.Map<ToType>(inputObj);


CreateMap<Foo, Bar>().ForMember(x => x.Blarg, opt => opt.Ignore());



ValueInjector
=============
