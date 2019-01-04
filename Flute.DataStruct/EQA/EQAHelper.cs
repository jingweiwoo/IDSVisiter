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
        /// <param name="tableSubSystem"></param>
        /// <param name="tableLoop"></param>
        /// <param name="tableEquipment"></param>
        /// <returns></returns>
        public  static SubSystemCollectin CreateSubSystems(DataTable tableSubSystem, DataTable tableCable, DataTable tableLoop, DataTable tableEquipment)
        {
            if (tableSubSystem == null)
                throw new System.ArgumentNullException("from function CreateSubSystems", "Parameter tableSubSystem equals to null");

            return CreateSubSystems(tableSubSystem.Rows, tableCable, tableLoop, tableEquipment);
        } 

        /// <summary>
        /// 从SYS表的多个数据行和Loop表, Eqp表生成子系统集合类的实例
        /// </summary>
        /// <param name="rowsSubSystem"></param>
        /// <param name="tableLoop"></param>
        /// <param name="tableEquipment"></param>
        /// <returns></returns>
        public static SubSystemCollectin CreateSubSystems(DataRowCollection rowsSubSystem, DataTable tableCable, DataTable tableLoop, DataTable tableEquipment)
        {
            if (rowsSubSystem == null)
                throw new System.ArgumentNullException("from function CreateSubSystems", "Parameter rowSubSystem equals to null");
            if (tableCable == null)
                throw new System.ArgumentNullException("from function CreateSubSystems", "Parameter tableCable equals to null");
            if (tableLoop == null)
                throw new System.ArgumentNullException("from function CreateSubSystems", "Parameter tableLoop equals to null");
            if (tableEquipment == null)
                throw new System.ArgumentNullException("from function CreateSubSystems", "Parameter tableEquipment equals to null");

            SubSystemCollectin subSystems = new SubSystemCollectin();

            if (rowsSubSystem.Count <= 0)
                return subSystems;

            lock (rowsSubSystem) {
                lock (tableLoop) {
                    lock (tableEquipment) {
                        try {
                            foreach (DataRow rowSubSystem in rowsSubSystem)
                                subSystems.Add(CreateSubSystem(rowSubSystem, tableCable, tableLoop, tableEquipment));


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
        /// <param name="rowSubSystem"></param>
        /// <param name="tableCable"></param>
        /// <param name="tableLoop"></param>
        /// <param name="tableEquipment"></param>
        /// <returns></returns>
        public static SubSystem CreateSubSystem(DataRow rowSubSystem, DataTable tableCable, DataTable tableLoop, DataTable tableEquipment)
        {
            if (rowSubSystem == null)
                throw new System.ArgumentNullException("from function CreateSubSystem", "Parameter rowSubSystem equals to null");
            if (tableCable == null)
                throw new System.ArgumentNullException("from function CreateSubSystem", "Parameter tableCable equals to null");
            if (tableLoop == null)
                throw new System.ArgumentNullException("from function CreateSubSystem", "Parameter tableLoop equals to null");
            if (tableEquipment == null)
                throw new System.ArgumentNullException("from function CreateSubSystem", "Parameter tableEquipment equals to null");

            SubSystem subSystem = new SubSystem();

            lock (rowSubSystem) {
                try {
                    subSystem.SubSystemID = (rowSubSystem[TblSys.ID] as string).Trim();
                    subSystem.Name = (rowSubSystem[TblSys.NAME] as string).Trim();

                    lock (tableLoop) {
                        lock (tableEquipment) {
                            foreach (DataRow rowLoop in tableLoop.Rows) {
                                if ((rowLoop[TblLoop.SYS_ID] as string).Trim() == subSystem.SubSystemID)
                                    subSystem.Loops.Add(CreateLoop(rowLoop, tableEquipment));
                            }
                        }
                    }

                    lock (tableCable)
                    {
                        foreach (DataRow rowCable in tableCable.Rows) {
                            if ((rowCable[TblCbl.SYS] as string).Trim() == subSystem.SubSystemID)
                                subSystem.Cables.Add(CreateCable(rowCable));
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
        /// <param name="rowsCable">Cbl表</param>
        /// <returns></returns>
        public static CableCollection CreateCables(DataRow[] rowsCable)
        {
            if (rowsCable == null)
                throw new System.ArgumentNullException("from function CreateCables", "Parameter rowsCable equals to null");

            CableCollection cables = new CableCollection();

            if (rowsCable.Length <= 0)
                return cables;

            lock (rowsCable)
            {
                try
                {
                    foreach (DataRow rowCable in rowsCable)
                        cables.Add(CreateCable(rowCable));
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
        /// <param name="rowCable">Cbl表的数据行</param>
        /// <returns></returns>
        public static Cable CreateCable(DataRow rowCable)
        {
            if (rowCable == null)
                throw new System.ArgumentNullException("frome function CreateCable", "Parameter rowCable equals to null");

            Cable cable = new Cable();

            lock (rowCable)
            {
                try
                {
                    cable.SubSystemID = (rowCable[TblCbl.SYS] as string).Trim();
                    cable.CableNo = (rowCable[TblCbl.TAGNAME] as string).Trim();
                    cable.StartPosition = rowCable[TblCbl.SOURCE] as string;
                    cable.EndPosition = rowCable[TblCbl.DEST] as string;
                    if (Convert.ToString(rowCable[TblCbl.SPARE]).Trim() != "") {
                        cable.SpareCableCore = Convert.ToInt32(rowCable[TblCbl.SPARE]);
                    }
                    cable.CableLength = Convert.ToInt32(rowCable[TblCbl.CBL_LEN]);
                    cable.ConductLength = Convert.ToInt32(rowCable[TblCbl.CONDUCT_LEN]);
                    cable.CableSpec = rowCable[TblCbl.CBL_TYPE] as string;
                    cable.ConductSpec = rowCable[TblCbl.CONDUCT_TYPE] as string;
                    cable.Remark = rowCable[TblCbl.REMARK] as string;
                    cable.Route = rowCable[TblCbl.ROUTE] as string;
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
        /// <param name="tableEquipment"></param>
        /// <returns></returns>
        public static LoopCollection CreateLoops(DataRow[] rowsLoop, DataTable tableEquipment)
        {
            if (rowsLoop == null)
                throw new System.ArgumentNullException("from function CreateLoops", "Parameter tableLoop equals to null");
            if (tableEquipment == null)
                throw new System.ArgumentNullException("from function CreateLoops", "Parameter tableEquipment equals to null");

            LoopCollection loops = new LoopCollection();

            if (rowsLoop.Length <= 0)
                return loops;

            lock (rowsLoop) {
                lock (tableEquipment) {
                    try {
                        foreach (DataRow rowLoop in rowsLoop)
                            loops.Add(CreateLoop(rowLoop, tableEquipment));
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
        /// <param name="rowLoop">Loop表的数据行</param>
        /// <param name="tableEquipment">Eqp表</param>
        /// <returns></returns>
        public static Loop CreateLoop(DataRow rowLoop, DataTable tableEquipment)
        {
            if(rowLoop == null)
                throw new System.ArgumentNullException("from function CreateLoop", "Parameter rowLoop equals to null");
            if(tableEquipment ==null)
                throw new System.ArgumentNullException("from function CreateLoop", "Parameter tableEquipment equals to null");

            Loop loop = new Loop();

            lock (rowLoop) {
                try {
                    loop.SubSystemID = (rowLoop[TblLoop.SYS_ID] as string).Trim();
                    loop.LoopNo = (rowLoop[TblLoop.LOOP_TAGNAME] as string).Trim();
                    loop.Location = rowLoop[TblLoop.LOC] as string;
                    loop.ProcMedium = rowLoop[TblLoop.MED] as string;
                    loop.ProcParameter = rowLoop[TblLoop.CHR] as string;
                    loop.LowerLimit = rowLoop[TblLoop.LOW] as string;
                    loop.UpperLimit = rowLoop[TblLoop.HIGH] as string;
                    loop.Unit = rowLoop[TblLoop.UNIT] as string;
                    loop.HasLocalIndication = Convert.ToBoolean(rowLoop[TblLoop.LI]);
                    loop.HasLocalOperating = Convert.ToBoolean(rowLoop[TblLoop.LO]);
                    loop.HasComputerIndication = Convert.ToBoolean(rowLoop[TblLoop.I]);
                    loop.HasComputerOperating = Convert.ToBoolean(rowLoop[TblLoop.O]);
                    loop.HasRecording = Convert.ToBoolean(rowLoop[TblLoop.R]);
                    loop.HasAccumulating = Convert.ToBoolean(rowLoop[TblLoop.Q]);
                    loop.HasControlling = Convert.ToBoolean(rowLoop[TblLoop.C]);
                    loop.HasAlarm = Convert.ToBoolean(rowLoop[TblLoop.A]);
                    loop.HasInterlock = Convert.ToBoolean(rowLoop[TblLoop.S]);
                    loop.Description = rowLoop[TblLoop.DESCRIP] as string;

                    lock (tableEquipment) {
                        foreach (DataRow rowEquipment in tableEquipment.Rows) {
                            if ((rowEquipment[TblEqp.LOOP_TAGNAME] as string).Trim() == loop.LoopNo)
                                loop.Equipments.Add(CreateEquipment(rowEquipment));
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
        public static EquipmentCollection CreateEquipments(DataRow[] rowsEquipment)
        {
            if(rowsEquipment == null)
                throw new System.ArgumentNullException("from function CreateEquipments", "Parameter tableEquipment equals to null");
            
            EquipmentCollection equipments = new EquipmentCollection();

            if (rowsEquipment.Length <= 0)
                return equipments;

            lock (rowsEquipment) {
                try {
                    foreach (DataRow rowEquipment in rowsEquipment)
                        equipments.Add(CreateEquipment(rowEquipment));
                } catch (DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return equipments;
        }

        /// <summary>
        /// 从Eqp表的数据行生成设备类实例
        /// </summary>
        /// <param name="rowEquipment">Eqp表的数据行</param>
        /// <returns></returns>
        public static Equipment CreateEquipment(DataRow rowEquipment)
        {
            if (rowEquipment == null)
                throw new System.ArgumentNullException("frome function CreateEquipment", "Parameter rowEquipment equals to null");

            Equipment equipment = new Equipment();

            lock (rowEquipment) {
                try {
                    equipment.LoopNo = (rowEquipment[TblEqp.LOOP_TAGNAME] as string).Trim();
                    equipment.TagNo = (rowEquipment[TblEqp.TAGNAME] as string).Trim();
                    equipment.Name = rowEquipment[TblEqp.NAME] as string;
                    equipment.EqpType = rowEquipment[TblEqp.TYPE] as string;
                    equipment.Quantity = Convert.ToInt32(rowEquipment[TblEqp.NUM]);
                    equipment.LowerLimit = rowEquipment[TblEqp.LOW] as string;
                    equipment.UpperLimit = rowEquipment[TblEqp.HIGH] as string;
                    equipment.Unit = rowEquipment[TblEqp.UNIT] as string;
                    equipment.InputSignal = rowEquipment[TblEqp.IN] as string;
                    equipment.OutputSignal = rowEquipment[TblEqp.OUT] as string;
                    equipment.PowerSupply = rowEquipment[TblEqp.PS] as string;
                    equipment.Spec1 = rowEquipment[TblEqp.SPEC1] as string;
                    equipment.Spec2 = rowEquipment[TblEqp.SPEC2] as string;
                    equipment.Spec3 = rowEquipment[TblEqp.SPEC3] as string;
                    equipment.Manufacturer = rowEquipment[TblEqp.MANU] as string;
                    equipment.Remark = rowEquipment[TblEqp.REMARK] as string;
                    equipment.FixedPlace = rowEquipment[TblEqp.LOC] as string;
                    equipment.Area = rowEquipment[TblEqp.AREA] as string;
                    equipment.PlateName = rowEquipment[TblEqp.PLATENAME] as string;
                    equipment.InstDrawing = rowEquipment[TblEqp.INSTDWG] as string;
                    equipment.HookupDrawing = rowEquipment[TblEqp.HOOKUP] as string;
                    equipment.IsEquipment = !Convert.ToBoolean(rowEquipment[TblEqp.NONEQP]);
                    equipment.IsPoweredByUPS = Convert.ToBoolean(rowEquipment[TblEqp.UPS]);
                    equipment.PowerSupplyCurrent = Convert.ToInt32(rowEquipment[TblEqp.PS_CURRENT]);
                    equipment.PowerSupplySource = rowEquipment[TblEqp.PS_SOURCE] as string;

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
