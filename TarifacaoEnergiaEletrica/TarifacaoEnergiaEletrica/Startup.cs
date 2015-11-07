using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TarifacaoEnergiaEletrica.Startup))]
namespace TarifacaoEnergiaEletrica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
