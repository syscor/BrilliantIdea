using System.Linq;
using BrilliantIdea.Persistance.Boards;

namespace BrilliantIdea.Framework.Logic
{
    public class BoardsLogic
    {
        public JsonResult GetBoardTypes()
        {
            var boards = new Boards();
            var boardsResult = boards.GetAllBoardTypes();
            boardsResult.
        }
    }
}
