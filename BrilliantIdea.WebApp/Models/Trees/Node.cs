using System.Collections.Generic;

namespace BrilliantIdea.WebApp.Models.Trees
{
    public class Node
    {
        public enum NodeMode
        {
            Navigation,
            PlainDisplay
        }

        #region Constants and Fields

        private readonly List<Node> _children = new List<Node>();

        private string _addClass;

        #endregion

        #region Public Properties

        public Node()
        {
            Searchable = true;
        }

        public bool Activate { get; set; }

        public string AddClass
        {
            get
            {
                return _addClass;
            }

            set
            {
                _addClass += " " + value;
            }
        }

        public List<Node> Children
        {
            get
            {
                return _children;
            }
        }

        public bool Expand { get; set; }

        public bool Focus { get; set; }

        public bool HideCheckbox { get; set; }

        public string Icon { get; set; }

        public int ID { get; set; }

        public bool IsFolder { get; set; }

        public bool IsLazy { get; set; }

        public string Key { get; set; }

        public string NodeType { get; protected internal set; }

        public bool RenderChildren { get; set; }

        public bool Searchable { get; set; }

        public bool Select { get; set; }

        public string Title { get; set; }

        public string Tooltip { get; set; }

        public bool Unselectable { get; set; }

        public string URL { get; set; }

        #endregion

    }
}