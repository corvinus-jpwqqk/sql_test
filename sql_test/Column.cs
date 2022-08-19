using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_test
{
    class Column
    {
        private int _objId;
        private int _colId;
        private int _typeId;
        private int _maxLength;
        private string _name;
        public Column(int objId_, int colId_, int typeId_, int maxLength_, string name_)
        {
            _objId = objId_;
            _colId = colId_;
            _typeId = typeId_;
            _maxLength = maxLength_;
            _name = name_;
        }
        public int getObjId()
        {
            return _objId;
        }
        public int getColId()
        {
            return _colId;
        }
        public int getTypeId()
        {
            return _typeId;
        }
        public int getMaxLength()
        {
            return _maxLength;
        }
        public string getName()
        {
            return _name;
        }

    }
}
