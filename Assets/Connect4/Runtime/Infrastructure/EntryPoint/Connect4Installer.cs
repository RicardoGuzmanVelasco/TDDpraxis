using Connect4.Runtime.Application;
using Connect4.Runtime.Infrastructure.Presentation;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.EntryPoint
{
    public class Connect4Installer : MonoInstaller
    {
        [SerializeField] Vector2Int boardSize = new Vector2Int(6, 7);
        
        public override void InstallBindings()
        {
            InstallDomain();
            InstallApplication();
            InstallPresentation();
        }

        void InstallDomain()
        {
            Container.Bind<Domain.Board>().FromInstance(new Domain.Board(boardSize.x, boardSize.y));
            Container.Bind<Domain.Cursor>().FromInstance(new Domain.Cursor(boardSize.y));
        }
        
        void InstallApplication()
        {
            Container.Bind<TokenDrop>().FromNew().AsSingle();
            Container.Bind<CursorMovement>().FromNew().AsSingle();
        }
        
        void InstallPresentation()
        {
            var cursor = FindObjectOfType<Presentation.Cursor>();
            Container.Bind<CursorView>().FromInstance(cursor).AsSingle();
                
            Container.BindInterfacesAndSelfTo<TestPlaceholderView>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}