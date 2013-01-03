using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrilliantIdea.Framework.Boards;


namespace BrilliantIdea.WebAPI.Controllers
{
    public class ConfigController : ApiController
    {
        // Initialize Boards Config
        public bool GetInitializeBoards()
        {
            try
            {
                var board = new Boards();
                board.InitTypeBoards();
                board.InitBoards();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

       // Get all devices
        public IEnumerable<BoardDevice> GetBoards()
        {
            var boards = new Boards();
            var result = boards.GetAllBoards();
            return result;
        }

        // Get all type boards
        public Boards.BoardTypesResult GetTypeBoards()
        {
            var boards = new Boards();
            var result = boards.GetAllBoardTypes();
            return result;
        }

        /// <summary>
        /// Create new Board Device
        /// </summary>
        /// <param name="board">Board Device Info</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage PostBoard(BoardDevice board)
        {
            if (ModelState.IsValid)
            {
                var boards = new Boards();
                var result = boards.SaveBoard(board);
                if (result)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}