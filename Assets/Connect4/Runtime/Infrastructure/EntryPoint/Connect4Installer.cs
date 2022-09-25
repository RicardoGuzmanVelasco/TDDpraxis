using Connect4.Runtime.Application;
using Connect4.Runtime.Infrastructure.Presentation;
using Zenject;

namespace Connect4.Runtime.Infrastructure.EntryPoint
{
    public class Connect4Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallDomain();
            InstallApplication();
            InstallPresentation();
        }

        void InstallDomain()
        {
            Container.Bind<Domain.Board>().FromInstance(new Domain.Board(6, 7));
            Container.Bind<Domain.Cursor>().FromInstance(new Domain.Cursor(6));
        }
        
        void InstallApplication()
        {
            Container.BindInterfacesAndSelfTo<TokenDrop>().FromNew().AsSingle();
        }
        
        void InstallPresentation()
        {
            Container.BindInterfacesAndSelfTo<TestPlaceholderView>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}