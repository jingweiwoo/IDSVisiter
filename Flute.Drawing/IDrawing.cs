using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace Flute.Drawing
{
    public interface IDrawing
    {
        /// <summary>
        /// 图纸生成
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="destPath"></param>
        /// <returns></returns>
        bool Export(string templatePath, string destPath);
    }
}
