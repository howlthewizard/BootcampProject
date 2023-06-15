
namespace AI.Controller
{
    public interface IRaycastable
    {
        CursorType GetCursorType();
        bool HandleRaycast(PlayerCursorController callingController);//this parameter for checking that controller calling this method
    }
}