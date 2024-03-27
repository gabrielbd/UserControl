using Microsoft.Extensions.DependencyInjection;
using UserControl.Application.Interfaces;
using UserControl.Application.Services;
using UserControl.Domain.Services;
using UserControl.Domain.Interfaces.Services;
using UserControl.Domain.Interfaces.Repositories;
using UserControl.Infra.Repositories;


namespace UserControl.Infra.IoC
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //Application
            svcCollection.AddTransient(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
            svcCollection.AddTransient<IUserControlAppService, UserControlAppService>();

            //Domain
            svcCollection.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
            svcCollection.AddTransient<IUserControlDomainService, UserControlDomainService>();

            //Repository
            svcCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            svcCollection.AddTransient<IUserControlRepository, UserControlRepository>();
        }
    }
}
