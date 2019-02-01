using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.Drawing
{
    public abstract class IDSEquipmentIndent : IDrawing
    {
        private object _drawingData = null;

        public object DrawingData { get { return _drawingData; } set { _drawingData = value; } }

        #region IDrawing Members

        bool IDrawing.Export(string templatePath, string destPath, params object[] anyObjects)
        {
            Console.WriteLine("calling Flute.Drawing.IDS.IDSEquipmentIndent.Export");
            return true;
        }

        #endregion
    }
}
