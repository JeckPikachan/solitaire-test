namespace SolitaireUndo.Commands
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }
}