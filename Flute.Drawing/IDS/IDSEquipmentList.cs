using System;
using System.Collections.Generic;
using System.Text;

using Flute.Drawing;

namespace Flute.Drawing
{
    public abstract class IDSEquipmentList : IDrawing
    {
        private object _drawingData = null;
        private object _drawingKeywords = null;

        public object DrawingData { get { return _drawingData; } set { _drawingData = value; } }
        public object DrawingKeywords { get { return _drawingKeywords; } set { _drawingKeywords = value; } }

        #region IDrawing Members

        public virtual bool Export(string templatePath, string destPath)
        {
            Console.WriteLine("calling Flute.Drawing.IDS.IDSEquipmentList.Export");
            return true;
        }

        #endregion
    }
}
