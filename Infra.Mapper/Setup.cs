using System.Text.RegularExpressions;
using Application.Util;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Mapper;

public static class Setup
{
    public static IServiceCollection AutoMapperStartup(this IServiceCollection service)
        {
            // Obtem todas classe do projeto com sufixo profile. 
            var profiles = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.Contains("Infra.Mapper"))
                .FirstOrDefault()?.GetTypes().Where(x => x.FullName != null &&
                                                         x.Namespace != null &&
                                                         !x.IsAbstract &&
                                                         Regex.IsMatch(x.FullName, @".*Infra\.Mapper\.Profiles\..*Profile.*?") &&
                                                         !x.Name.Contains("<>c")
                ).ToList();

            
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                if (profiles == null ) return;
                
                // adiciona cada classe encontrada no config do mapper
                foreach (var profileType in profiles)
                {
                    var profile = (Profile)Activator.CreateInstance(profileType)!;
                    x.AddProfile(profile);
                }
            });

            // inicializa o mapper
            var mapper = mapperConfiguration.CreateMapper();
            MapperUtil.Mapper = mapper;
            return service;
        }
}