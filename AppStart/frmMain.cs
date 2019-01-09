using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;


using AppConfig;

using Flute.DataStruct.EQA;
using EQA.Data.Table;
using IDS.Data.Table;
using Flute.Data;

using Flute.Drawing;
using Flute.Drawing.EQA;
using Flute.Service;

namespace AppStart
{
    public partial class frmMain : Form
    {
        string caption = "IDS Visiter";

        public frmMain()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            this.Text = caption;

            // statusStripe
            statusMain.SizingGrip = false;

            // Menu
            ToolStripMenuItem menuExit = new ToolStripMenuItem("退出(&C)");
            ToolStripMenuItem menuOpenEQA = new ToolStripMenuItem("打开EQA文件... (&E)");
            ToolStripMenuItem menuOpenIDS = new ToolStripMenuItem("打开IDS文件... (&I)");
            ToolStripMenuItem menuCatalogSystem = new ToolStripMenuItem("文件(&F)");

            menuCatalogSystem.DropDownItems.Add(menuOpenEQA);
            menuCatalogSystem.DropDownItems.Add(menuOpenIDS);
            menuCatalogSystem.DropDownItems.Add(new ToolStripSeparator());
            menuCatalogSystem.DropDownItems.Add(menuExit);

            // ------

            ToolStripMenuItem menuMMKEquipmentListExport = new ToolStripMenuItem("MMK冷轧公辅设备表(&Q)");
            ToolStripMenuItem menuMMKCableListExport = new ToolStripMenuItem("MMK冷轧公辅电缆表(&C)");

            ToolStripMenuItem menuMMKExport = new ToolStripMenuItem("MMK冷轧公辅项目");

            ToolStripMenuItem menuLongEquipementIndentExport = new ToolStripMenuItem("龙门钢铁高炉仪表设备清单");

            ToolStripMenuItem menuLongExport = new ToolStripMenuItem("龙门钢铁高炉总承包项目");

            ToolStripMenuItem menuDrawingExport = new ToolStripMenuItem("导出EQA数据库内容");
            ToolStripMenuItem menuCatalogDrawing = new ToolStripMenuItem("图纸(&D)");
            
            menuLongExport.DropDownItems.Add(menuLongEquipementIndentExport);
            menuDrawingExport.DropDownItems.Add(menuLongExport);

            menuMMKExport.DropDownItems.Add(menuMMKEquipmentListExport);
            menuMMKExport.DropDownItems.Add(menuMMKCableListExport);
            menuDrawingExport.DropDownItems.Add(menuMMKExport);

            menuCatalogDrawing.DropDownItems.Add(menuDrawingExport);

            // ------

            menuMain.Items.Add(menuCatalogSystem);
            menuMain.Items.Add(menuCatalogDrawing);

            // Events Handler
            menuOpenEQA.Click += menuOpenEQA_Click;
            menuOpenIDS.Click += menuOpenIDS_Click;
            menuExit.Click += menuExit_Click;

            menuMMKEquipmentListExport.Click += menuMMKEquipmentListExport_Click;
            menuMMKCableListExport.Click += menuMMKCableListExport_Click;

            menuLongEquipementIndentExport.Click += menuLongEquipmentIndentExport_Click;
        }

        #region .载入EQA数据库.
        // 载入EQA数据库
        private void menuOpenEQA_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (DatabaseManager.Databases.Count > 0) {
                if (DialogResult.Cancel == Flute.Service.MessageBoxWinForm.Confirm("打开EQA数据库", "您已打开一个EQA数据库, 确认打开新的EQA数据库吗?", "")) {
                    return;
                }
            }

            OpenFileDialog openFileDlg;            

            openFileDlg = new OpenFileDialog();

            openFileDlg.Multiselect = false;
            openFileDlg.Title = "选择EQA文件";
            openFileDlg.Filter = "EQA文件 (*.EQA)|*.EQA|All Files (*.*)|*.*";

            DialogResult dlgResult;

            try {
                dlgResult = openFileDlg.ShowDialog();
            } catch (Exception ex) {
                Flute.Service.MessageBoxWinForm.Error("选择EQA数据库文件", ex.Message, "");
                return;
            }

            if (dlgResult == DialogResult.OK) {
                fileName = openFileDlg.FileName;
            } else {
                return;
            }

            DatabaseManager.Databases.Clear();

            //
            // Hard Code -- left for refactoring
            //
            DataSet ds = new DataSet();

            DatabaseConfigInfo dbConfigInfo = new DatabaseConfigInfo();
            dbConfigInfo.ConnectionString = DatabaseManager.CreateOleDbConnString(fileName, "admin", "efzo");
            dbConfigInfo.TablePrefix = "";
            dbConfigInfo.DbType = "";

            IDbProvider dbProvider = DatabaseManager.GetProvider("Flute.Data.AccessProvider");

            try {
                ds = DatabaseHelper.CreateDataSet(dbConfigInfo.ConnectionString,
                                                  dbProvider,
                                                  TblSys.TblName,
                                                  TblEqp.TblName,
                                                  TblLoop.TblName,
                                                  TblCbl.TblName);
            } catch (System.Data.Common.DbException ex) {
                Flute.Service.MessageBoxWinForm.Error("数据库EQA连接", "程序在加载数据库EQA时出错!", ex.Message + "\n\n" + ex.Source);
                return;
            }

            DatabaseManager.AddDatabase(new Database(ds, dbConfigInfo, dbProvider),fileName);
            DatabaseManager.SetCurrentKey(fileName);

            this.Text = System.IO.Path.GetFileName(fileName) + " -- " + caption;
            Flute.Service.MessageBoxWinForm.Info("成功", "成功载入EQA数据库文件", "路径:\n" + fileName);         
        }
        #endregion

        #region .载入IDS数据库.
        // 载入IDS数据库
        private void menuOpenIDS_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (DatabaseManager.Databases.Count > 0)
            {
                if (DialogResult.Cancel == Flute.Service.MessageBoxWinForm.Confirm("打开IDS数据库", "您已打开一个IDS数据库, 确认打开新的IDS数据库吗?", ""))
                {
                    return;
                }
            }

            OpenFileDialog openFileDlg;

            openFileDlg = new OpenFileDialog();

            openFileDlg.Multiselect = false;
            openFileDlg.Title = "选择IDS文件";
            openFileDlg.Filter = "IDS文件 (*.IDS)|*.IDS|All Files (*.*)|*.*";

            DialogResult dlgResult;

            try
            {
                dlgResult = openFileDlg.ShowDialog();
            }
            catch (Exception ex)
            {
                Flute.Service.MessageBoxWinForm.Error("选择IDS数据库文件", ex.Message, "");
                return;
            }

            if (dlgResult == DialogResult.OK)
            {
                fileName = openFileDlg.FileName;
            }
            else
            {
                return;
            }

            DatabaseManager.Databases.Clear();

            //
            // Hard Code -- left for refactoring
            //
            DataSet ds = new DataSet();

            DatabaseConfigInfo dbConfigInfo = new DatabaseConfigInfo();
            dbConfigInfo.ConnectionString = DatabaseManager.CreateOleDbConnString(fileName, "", "");
            dbConfigInfo.TablePrefix = "";
            dbConfigInfo.DbType = "";

            IDbProvider dbProvider = DatabaseManager.GetProvider("Flute.Data.AccessProvider");

            try
            {
                ds = DatabaseHelper.CreateDataSet(dbConfigInfo.ConnectionString,
                                                  dbProvider,
                                                  TblIDSEquipment.TblName,
                                                  TblIDSSubEquipment.TblName,
                                                  TblIDSRepository.TblName,
                                                  TblIDSHierarchy.TblName,
                                                  TblIDSProcessLoop.TblName,
                                                  TblIDSCabinetEquipment.TblName);
            }
            catch (System.Data.Common.DbException ex)
            {
                Flute.Service.MessageBoxWinForm.Error("数据库IDS连接", "程序在加载数据库IDS时出错!", ex.Message + "\n\n" + ex.Source);
                return;
            }

            DatabaseManager.AddDatabase(new Database(ds, dbConfigInfo, dbProvider), fileName);
            DatabaseManager.SetCurrentKey(fileName);

            this.Text = System.IO.Path.GetFileName(fileName) + " -- " + caption;
            Flute.Service.MessageBoxWinForm.Info("成功", "成功载入IDS数据库文件", "路径:\n" + fileName);
        }
        #endregion

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region .EQA数据库内容导出.
        void menuMMKEquipmentListExport_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.Databases.Count <= 0) {
                Flute.Service.MessageBoxWinForm.Error("设备表导出", "程序还没有载入任何EQA数据库.", "");
                return;
            }

            DataSet dataSet = DatabaseManager.Databases[DatabaseManager.CurrentKey].DatabaseSource;
            EQASubSystemCollectin subSystems = EQAHelper.CreateEQASubSystems(dataSet.Tables[TblSys.TblName],
                                                                       dataSet.Tables[TblCbl.TblName],
                                                                       dataSet.Tables[TblLoop.TblName],
                                                                       dataSet.Tables[TblEqp.TblName]);

            Flute.Drawing.EQA.MMKEquipmentList inMMKEquipmentList = new MMKEquipmentList(subSystems);
        
            inMMKEquipmentList.Export("");

            return;
        }

        void menuMMKCableListExport_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.Databases.Count <= 0)
            {
                Flute.Service.MessageBoxWinForm.Error("电缆表导出", "程序还没有载入任何EQA数据库.", "");
                return;
            }

            DataSet dataSet = DatabaseManager.Databases[DatabaseManager.CurrentKey].DatabaseSource;
            EQASubSystemCollectin subSystems = EQAHelper.CreateEQASubSystems(dataSet.Tables[TblSys.TblName],
                                                                       dataSet.Tables[TblCbl.TblName],
                                                                       dataSet.Tables[TblLoop.TblName],
                                                                       dataSet.Tables[TblEqp.TblName]);

            Flute.Drawing.EQA.MMKCableList inMMKCableList = new MMKCableList(subSystems);

            inMMKCableList.Export("");

            return;
        }

        void menuLongEquipmentIndentExport_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.Databases.Count <= 0) {
                Flute.Service.MessageBoxWinForm.Error("设备清单导出", "程序还没有载入任何EQA数据库.", "");
                return;
            }

            DataSet dataSet = DatabaseManager.Databases[DatabaseManager.CurrentKey].DatabaseSource;
            EQASubSystemCollectin subSystems = EQAHelper.CreateEQASubSystems(dataSet.Tables[TblSys.TblName],
                                                                       dataSet.Tables[TblCbl.TblName],
                                                                       dataSet.Tables[TblLoop.TblName],
                                                                       dataSet.Tables[TblEqp.TblName]);

            Flute.Drawing.EQA.LongEquipmentIndent inLongEquipmentIndent = new LongEquipmentIndent(subSystems);

            if (inLongEquipmentIndent.Export("")) {
                this.Activate();
                Flute.Service.MessageBoxWinForm.Info("设备清单导出成功", "设备清单已成功导出!", "");
            }

            return;
        }
        #endregion
    }
}
