using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;
namespace InfinitySettings.Notations
{

    public static class MoveVariationTree
    {
        static MoveVariationTree()
        {
            _moveVariations = new List<MoveVariation>();
        }

        static List<MoveVariation> _moveVariations;
        public static List<MoveVariation> MoveVariations
        {
            [DebuggerStepThrough]
            get { return _moveVariations; }
            [DebuggerStepThrough]
            set { _moveVariations = value; }
        }

        public static void AddMoveItem(MoveVariation parentMoveItem, MoveVariation currentMoveItem)
        {
            if (parentMoveItem == null)
            {
                if (_moveVariations == null)
                    _moveVariations = new List<MoveVariation>();

                _moveVariations.Add(currentMoveItem);
            }
            else
            {
                parentMoveItem.AddChild(currentMoveItem);
            } 
        }

        static string _movesSeparator = " ";

        public static string GetGameMovesFromCurrentNodeToRoot(MoveVariation currentMoveItem)
        {
            string gameMoves = string.Empty;
            
            if (currentMoveItem != null)
            {
                gameMoves += currentMoveItem.Move + _movesSeparator;
                GetParentMove(ref gameMoves, currentMoveItem);
            }
            return gameMoves;
        }

        private static void GetParentMove(ref string gameMoves, MoveVariation currentMoveItem)
        {
            if (currentMoveItem.Parent == null)
                return;

            gameMoves += currentMoveItem.Parent.Move + _movesSeparator;
            GetParentMove(ref gameMoves, currentMoveItem.Parent);

        } 
    }

    public class MoveVariation
    {   
        public MoveVariation(
            MoveVariation parent, int moveNumber,int variationNumber,
            bool isColor,string move,string fenNotation
            )
        {
            _parent = parent;
            _moveNumber = moveNumber;
            _variationNumber = variationNumber;
            _isColor = isColor;
            _move = move;
            _fenNotation = fenNotation;
        }

        MoveVariation _parent;
        public MoveVariation Parent
        {
            [DebuggerStepThrough]
            get { return _parent; }
        }

        int _moveNumber;
        public int MoveNumber
        {
            [DebuggerStepThrough]
            get { return _moveNumber; }
        }

        int _variationNumber;
        public int VariationNumber
        {
            [DebuggerStepThrough]
            get { return _variationNumber; }
        }

        bool _isColor;
        public bool IsColor
        {
            [DebuggerStepThrough]
            get { return _isColor; }
        }

        string _move;
        public string Move
        {
            [DebuggerStepThrough]
            get { return _move; }
        }

        string _fenNotation;
        public string FENNotation
        {
            [DebuggerStepThrough]
            get { return _fenNotation; }
        }

        List<MoveVariation> _children;
        public List<MoveVariation> Children
        {
            [DebuggerStepThrough]
            get { return _children; }
            //set { _children = value; }
        }

        public void AddChild(MoveVariation child)
        {
            if (_children == null)
                _children = new List<MoveVariation>();

            _children.Add(child);
        }
    }
}
