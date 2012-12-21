using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrilliantIdea.WebApp.Controllers;
using BrilliantIdea.WebApp.Models.DTOs;
using RestSharp;

namespace BrilliantIdea.WebApp.Models.ViewModel
{
    public class BoardSettingsViewModel
    {
        public BoardSettingsViewModel()
        {
            Initialize();
        }

        #region Variables and Properties

        public List<BoardTypeModelDTO> BoardList { get; set; }

        public class BoardListDTO : BoardTypeModelDTO
        {
        }

        #endregion

        #region Methods
        private void Initialize()
        {
            FillBoardList();
        }

        private void FillBoardList()
        {
        }

        #endregion
    }
}