using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrilliantIdea.Persistance.Boards;

namespace BrilliantIdea.Framework.Utils
{
    public class DBInitialization
    {
        public void Initialize()
        {
           
            var boards = new Boards();
            boards.InitTypeBoards(boardTypeModel);
            
        }
    }
}
