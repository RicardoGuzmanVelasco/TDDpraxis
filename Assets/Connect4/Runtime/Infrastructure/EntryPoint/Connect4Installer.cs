using Connect4.Runtime.Application;
using Connect4.Runtime.Infrastructure.Presentation;
using UnityEngine;
using Zenject;

namespace Connect4.Runtime.Infrastructure.EntryPoint
{
    public class Connect4Installer : MonoInstaller
    {
        static readonly Vector2Int BoardSize = new(6, 7);
        
        public override void InstallBindings()
        {
            InstallDomain();
            InstallApplication();
            InstallPresentation();
        }

        void InstallDomain()
        {
            Container.Bind<Domain.Board>().FromInstance(new Domain.Board(BoardSize.x, BoardSize.y));
            Container.Bind<Domain.Cursor>().FromInstance(new Domain.Cursor(BoardSize.y));
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

            var board = FindObjectOfType<SlotAsTokenNaiveBoard>();
            Container.Bind<BoardView>().FromInstance(board).AsSingle();
                
            Container.BindInterfacesAndSelfTo<TestPlaceholderView>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}