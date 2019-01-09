using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Data;

using Flute.Service;
using EQA.Data.Table;

namespace Flute.DataStruct.EQA
{
    public static class EQAHelper
    {
        #region .Create EQA DataStructs.

        #region .生成子系统.

        /// <summary>
        /// 从SYS表和Loop表, Eqp表生成子系统集合类的实例
        /// </summary>
        /// <param name="tableEQASubSystem"></param>
        /// <param name="tableEQALoop"></param>
        /// <param name="tableEQAEquipment"></param>
        /// <returns></returns>
        public  static EQASubSystemCollectin CreateEQASubSystems(DataTable tableEQASubSystem, DataTable tableEQACable, DataTable tableEQALoop, DataTable tableEQAEquipment)
        {
            if (tableEQASubSystem == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystems", "Parameter tableEQASubSystem equals to null");

            return CreateEQASubSystems(tableEQASubSystem.Rows, tableEQACable, tableEQALoop, tableEQAEquipment);
        } 

        /// <summary>
        /// 从SYS表的多个数据行和Loop表, Eqp表生成子系统集合类的实例
        /// </summary>
        /// <param name="rowsEQASubSystem"></param>
        /// <param name="tableEQALoop"></param>
        /// <param name="tableEQAEquipment"></param>
        /// <returns></returns>
        public static EQASubSystemCollectin CreateEQASubSystems(DataRowCollection rowsEQASubSystem, DataTable tableEQACable, DataTable tableEQALoop, DataTable tableEQAEquipment)
        {
            if (rowsEQASubSystem == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystems", "Parameter rowEQASubSystem equals to null");
            if (tableEQACable == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystems", "Parameter tableEQACable equals to null");
            if (tableEQALoop == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystems", "Parameter tableEQALoop equals to null");
            if (tableEQAEquipment == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystems", "Parameter tableEQAEquipment equals to null");

            EQASubSystemCollectin subSystems = new EQASubSystemCollectin();

            if (rowsEQASubSystem.Count <= 0)
                return subSystems;

            lock (rowsEQASubSystem) {
                lock (tableEQALoop) {
                    lock (tableEQAEquipment) {
                        try {
                            foreach (DataRow rowSubSystem in rowsEQASubSystem)
                                subSystems.Add(CreateEQASubSystem(rowSubSystem, tableEQACable, tableEQALoop, tableEQAEquipment));


                        } catch (DataException ex) {
                            MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                        }
                    }
                }
            }

            return subSystems;
        }

        /// <summary>
        /// 从SYS表的数据行和Cable表, Loop表, Eqp表生成子系统类的实例
        /// </summary>
        /// <param name="rowEQASubSystem"></param>
        /// <param name="tableEQACable"></param>
        /// <param name="tableEQALoop"></param>
        /// <param name="tableEQAEquipment"></param>
        /// <returns></returns>
        public static EQASubSystem CreateEQASubSystem(DataRow rowEQASubSystem, DataTable tableEQACable, DataTable tableEQALoop, DataTable tableEQAEquipment)
        {
            if (rowEQASubSystem == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystem", "Parameter rowEQASubSystem equals to null");
            if (tableEQACable == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystem", "Parameter tableEQACable equals to null");
            if (tableEQALoop == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystem", "Parameter tableEQALoop equals to null");
            if (tableEQAEquipment == null)
                throw new System.ArgumentNullException("from function CreateEQASubSystem", "Parameter tableEQAEquipment equals to null");

            EQASubSystem subSystem = new EQASubSystem();

            lock (rowEQASubSystem) {
                try {
                    subSystem.SubSystemID = (rowEQASubSystem[TblSys.ID] as string).Trim();
                    subSystem.Name = (rowEQASubSystem[TblSys.NAME] as string).Trim();

                    lock (tableEQALoop) {
                        lock (tableEQAEquipment) {
                            foreach (DataRow rowLoop in tableEQALoop.Rows) {
                                if ((rowLoop[TblLoop.SYS_ID] as string).Trim() == subSystem.SubSystemID)
                                    subSystem.Loops.Add(CreateEQALoop(rowLoop, tableEQAEquipment));
                            }
                        }
                    }

                    lock (tableEQACable)
                    {
                        foreach (DataRow rowCable in tableEQACable.Rows) {
                            if ((rowCable[TblCbl.SYS] as string).Trim() == subSystem.SubSystemID)
                                subSystem.Cables.Add(CreateEQACable(rowCable));
                        }
                    }

                } catch (DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return subSystem;
        }

        #endregion // 生成子系统

        #region .生成电缆.

        /// <summary>
        /// 从Cbl表的多个数据行生成电缆类集合的实例
        /// </summary>
        /// <param name="rowsEQACable">Cbl表</param>
        /// <returns></returns>
        public static EQACableCollection CreateEQACables(DataRow[] rowsEQACable)
        {
            if (rowsEQACable == null)
                throw new System.ArgumentNullException("from function CreateEQACables", "Parameter rowsEQACable equals to null");

            EQACableCollection cables = new EQACableCollection();

            if (rowsEQACable.Length <= 0)
                return cables;

            lock (rowsEQACable)
            {
                try
                {
                    foreach (DataRow rowCable in rowsEQACable)
                        cables.Add(CreateEQACable(rowCable));
                }
                catch (DataException ex)
                {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return cables;
        }

        /// <summary>
        /// 从Cbl表的数据行生成电缆类实例
        /// </summary>
        /// <param name="rowEQACable">Cbl表的数据行</param>
        /// <returns></returns>
        public static EQACable CreateEQACable(DataRow rowEQACable)
        {
            if (rowEQACable == null)
                throw new System.ArgumentNullException("frome function CreateEQACable", "Parameter rowEQACable equals to null");

            EQACable cable = new EQACable();

            lock (rowEQACable)
            {
                try
                {
                    cable.SubSystemID = (rowEQACable[TblCbl.SYS] as string).Trim();
                    cable.CableNo = (rowEQACable[TblCbl.TAGNAME] as string).Trim();
                    cable.StartPosition = rowEQACable[TblCbl.SOURCE] as string;
                    cable.EndPosition = rowEQACable[TblCbl.DEST] as string;
                    if (Convert.ToString(rowEQACable[TblCbl.SPARE]).Trim() != "") {
                        cable.SpareCableCore = Convert.ToInt32(rowEQACable[TblCbl.SPARE]);
                    }
                    cable.CableLength = Convert.ToInt32(rowEQACable[TblCbl.CBL_LEN]);
                    cable.ConductLength = Convert.ToInt32(rowEQACable[TblCbl.CONDUCT_LEN]);
                    cable.CableSpec = rowEQACable[TblCbl.CBL_TYPE] as string;
                    cable.ConductSpec = rowEQACable[TblCbl.CONDUCT_TYPE] as string;
                    cable.Remark = rowEQACable[TblCbl.REMARK] as string;
                    cable.Route = rowEQACable[TblCbl.ROUTE] as string;
                }
                catch (System.Data.DataException ex)
                {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return cable;
        }

        #endregion

        #region .生成回路.

        /// <summary>
        /// 从Loop表的多个数据行和Eqp表生成回路类集合的实例
        /// </summary>
        /// <param name="tableLoop"></param>
        /// <param name="tableEQAEquipment"></param>
        /// <returns></returns>
        public static EQALoopCollection CreateEQALoops(DataRow[] rowsEQALoop, DataTable tableEQAEquipment)
        {
            if (rowsEQALoop == null)
                throw new System.ArgumentNullException("from function CreateEQALoops", "Parameter tableEQALoop equals to null");
            if (tableEQAEquipment == null)
                throw new System.ArgumentNullException("from function CreateEQALoops", "Parameter tableEQAEquipment equals to null");

            EQALoopCollection loops = new EQALoopCollection();

            if (rowsEQALoop.Length <= 0)
                return loops;

            lock (rowsEQALoop) {
                lock (tableEQAEquipment) {
                    try {
                        foreach (DataRow rowLoop in rowsEQALoop)
                            loops.Add(CreateEQALoop(rowLoop, tableEQAEquipment));
                    } catch (DataException ex) {
                        MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                    }
                }
            }

            return loops;
        }

        /// <summary>
        /// 从Loop表的数据行和Eqp表生成回路类的实例
        /// </summary>
        /// <param name="rowEQALoop">Loop表的数据行</param>
        /// <param name="tableEQAEquipment">Eqp表</param>
        /// <returns></returns>
        public static EQALoop CreateEQALoop(DataRow rowEQALoop, DataTable tableEQAEquipment)
        {
            if(rowEQALoop == null)
                throw new System.ArgumentNullException("from function CreateEQALoop", "Parameter rowEQALoop equals to null");
            if(tableEQAEquipment ==null)
                throw new System.ArgumentNullException("from function CreateEQALoop", "Parameter tableEQAEquipment equals to null");

            EQALoop loop = new EQALoop();

            lock (rowEQALoop) {
                try {
                    loop.SubSystemID = (rowEQALoop[TblLoop.SYS_ID] as string).Trim();
                    loop.LoopNo = (rowEQALoop[TblLoop.LOOP_TAGNAME] as string).Trim();
                    loop.Location = rowEQALoop[TblLoop.LOC] as string;
                    loop.ProcMedium = rowEQALoop[TblLoop.MED] as string;
                    loop.ProcParameter = rowEQALoop[TblLoop.CHR] as string;
                    loop.LowerLimit = rowEQALoop[TblLoop.LOW] as string;
                    loop.UpperLimit = rowEQALoop[TblLoop.HIGH] as string;
                    loop.Unit = rowEQALoop[TblLoop.UNIT] as string;
                    loop.HasLocalIndication = Convert.ToBoolean(rowEQALoop[TblLoop.LI]);
                    loop.HasLocalOperating = Convert.ToBoolean(rowEQALoop[TblLoop.LO]);
                    loop.HasComputerIndication = Convert.ToBoolean(rowEQALoop[TblLoop.I]);
                    loop.HasComputerOperating = Convert.ToBoolean(rowEQALoop[TblLoop.O]);
                    loop.HasRecording = Convert.ToBoolean(rowEQALoop[TblLoop.R]);
                    loop.HasAccumulating = Convert.ToBoolean(rowEQALoop[TblLoop.Q]);
                    loop.HasControlling = Convert.ToBoolean(rowEQALoop[TblLoop.C]);
                    loop.HasAlarm = Convert.ToBoolean(rowEQALoop[TblLoop.A]);
                    loop.HasInterlock = Convert.ToBoolean(rowEQALoop[TblLoop.S]);
                    loop.Description = rowEQALoop[TblLoop.DESCRIP] as string;

                    lock (tableEQAEquipment) {
                        foreach (DataRow rowEquipment in tableEQAEquipment.Rows) {
                            if ((rowEquipment[TblEqp.LOOP_TAGNAME] as string).Trim() == loop.LoopNo)
                                loop.Equipments.Add(CreateEQAEquipment(rowEquipment));
                        }
                    }
                } catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return loop;
        }

        #endregion // 生成回路

        #region .生成设备.

        /// <summary>
        /// 从Eqp表的多个数据行生成设备类集合的实例
        /// </summary>
        /// <param name="tableEquipment">Eqp表</param>
        /// <returns></returns>
        public static EQAEquipmentCollection CreateEQAEquipments(DataRow[] rowsEQAEquipment)
        {
            if(rowsEQAEquipment == null)
                throw new System.ArgumentNullException("from function CreateEQAEquipments", "Parameter tableEQAEquipment equals to null");
            
            EQAEquipmentCollection equipments = new EQAEquipmentCollection();

            if (rowsEQAEquipment.Length <= 0)
                return equipments;

            lock (rowsEQAEquipment) {
                try {
                    foreach (DataRow rowEquipment in rowsEQAEquipment)
                        equipments.Add(CreateEQAEquipment(rowEquipment));
                } catch (DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return equipments;
        }

        /// <summary>
        /// 从Eqp表的数据行生成设备类实例
        /// </summary>
        /// <param name="rowEQAEquipment">Eqp表的数据行</param>
        /// <returns></returns>
        public static EQAEquipment CreateEQAEquipment(DataRow rowEQAEquipment)
        {
            if (rowEQAEquipment == null)
                throw new System.ArgumentNullException("frome function CreateEQAEquipment", "Parameter rowEQAEquipment equals to null");

            EQAEquipment equipment = new EQAEquipment();

            lock (rowEQAEquipment) {
                try {
                    equipment.LoopNo = (rowEQAEquipment[TblEqp.LOOP_TAGNAME] as string).Trim();
                    equipment.TagNo = (rowEQAEquipment[TblEqp.TAGNAME] as string).Trim();
                    equipment.Name = rowEQAEquipment[TblEqp.NAME] as string;
                    equipment.EqpType = rowEQAEquipment[TblEqp.TYPE] as string;
                    equipment.Quantity = Convert.ToInt32(rowEQAEquipment[TblEqp.NUM]);
                    equipment.LowerLimit = rowEQAEquipment[TblEqp.LOW] as string;
                    equipment.UpperLimit = rowEQAEquipment[TblEqp.HIGH] as string;
                    equipment.Unit = rowEQAEquipment[TblEqp.UNIT] as string;
                    equipment.InputSignal = rowEQAEquipment[TblEqp.IN] as string;
                    equipment.OutputSignal = rowEQAEquipment[TblEqp.OUT] as string;
                    equipment.PowerSupply = rowEQAEquipment[TblEqp.PS] as string;
                    equipment.Spec1 = rowEQAEquipment[TblEqp.SPEC1] as string;
                    equipment.Spec2 = rowEQAEquipment[TblEqp.SPEC2] as string;
                    equipment.Spec3 = rowEQAEquipment[TblEqp.SPEC3] as string;
                    equipment.Manufacturer = rowEQAEquipment[TblEqp.MANU] as string;
                    equipment.Remark = rowEQAEquipment[TblEqp.REMARK] as string;
                    equipment.FixedPlace = rowEQAEquipment[TblEqp.LOC] as string;
                    equipment.Area = rowEQAEquipment[TblEqp.AREA] as string;
                    equipment.PlateName = rowEQAEquipment[TblEqp.PLATENAME] as string;
                    equipment.InstDrawing = rowEQAEquipment[TblEqp.INSTDWG] as string;
                    equipment.HookupDrawing = rowEQAEquipment[TblEqp.HOOKUP] as string;
                    equipment.IsEquipment = !Convert.ToBoolean(rowEQAEquipment[TblEqp.NONEQP]);
                    equipment.IsPoweredByUPS = Convert.ToBoolean(rowEQAEquipment[TblEqp.UPS]);
                    equipment.PowerSupplyCurrent = Convert.ToInt32(rowEQAEquipment[TblEqp.PS_CURRENT]);
                    equipment.PowerSupplySource = rowEQAEquipment[TblEqp.PS_SOURCE] as string;

                } catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return equipment;
        }

        #endregion // 生成设备

        #endregion // Create EQA DataStructs
    }    
}
