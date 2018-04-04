using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Moves
{
    public class MoveSet
    {
        private string _name;
        private string _value;
        private string _beats;
        private int _intValue;

        public string Name { get => _name; set => _name = value; }
        public string Value { get => _value; set => _value = value; }
        public string Beats { get => _beats; set => _beats = value; }
        public int IntValue { get => _intValue; set => _intValue = value; }
    }

}

