namespace Mvc.Scripts.Controllers.Interfaces
{
    public interface IController<T>
    {
        void Execute(T poco);
    }

    public interface IController
    {
        void Execute();
    }
}