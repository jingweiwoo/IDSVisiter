using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.Drawing
{
    public abstract class EQAEquipmentList : IDrawing
    {
        private object _drawingData = null;

        public object DrawingData { get { return _drawingData; } set { _drawingData = value; } } 

        #region IDrawing Members

        bool IDrawing.Export(string templatePath, string destPath, params object[] anyObjects)
        {
            return true;
        }

        #endregion
    }
}
