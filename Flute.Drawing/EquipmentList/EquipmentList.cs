using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.Drawing
{
    public abstract class EquipmentList : IDrawing
    {
        private object _drawingData = null;

        public object DrawingData { get { return _drawingData; } set { _drawingData = value; } } 

        #region IDrawing Members

        bool IDrawing.Export(string templatePath, string destPath)
        {
            return true;
        }

        #endregion
    }
}
