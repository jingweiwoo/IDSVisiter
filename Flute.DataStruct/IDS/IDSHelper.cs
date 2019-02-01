using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Flute.Service;
using IDS.Data.Table;

namespace Flute.DataStruct.IDS
{
    public static class IDSHelper
    {
        #region .Create Design Info.

        public static IDSDesignInfo CreateIDSDesignInfo(DataTable tableDesignInfo)
        {
            if (tableDesignInfo == null)
                throw new System.ArgumentNullException("frome function CreateIDSDesignInfo", "Parameter tableDesignInfo equals to null");

            if (tableDesignInfo.Rows.Count > 0) {
                return CreateIDSDesignInfo(tableDesignInfo.Rows[0]);
            }

            return new IDSDesignInfo();
        }

        public static IDSDesignInfo CreateIDSDesignInfo(DataRow rowDesignInfo)
        {
            if (rowDesignInfo == null)
                throw new System.ArgumentNullException("frome function CreateIDSDesignInfo", "Parameter rowDesignInfo equals to null");

            IDSDesignInfo designInfo = new IDSDesignInfo();

            lock (rowDesignInfo) {
                try {
                    designInfo.ProjectName = (rowDesignInfo[TblDesignInfo.ProjectName] as string).Trim();
                    designInfo.ProjectID = (rowDesignInfo[TblDesignInfo.ProjectID] as string).Trim();
                    designInfo.DrawingID = (rowDesignInfo[TblDesignInfo.DrawingID] as string).Trim();
                    designInfo.DesignPhase = (rowDesignInfo[TblDesignInfo.DesignPhase] as string).Trim();
                    designInfo.Speciality = (rowDesignInfo[TblDesignInfo.Speciality] as string).Trim();
                    designInfo.DesignedBy = (rowDesignInfo[TblDesignInfo.DesignedBy] as string).Trim();

                    designInfo.RevisionVersion = (rowDesignInfo[TblDesignInfo.RevisionVersion] as string).Trim();
                    designInfo.Date = (rowDesignInfo[TblDesignInfo.Date] as string).Trim();

                    designInfo.CheckedBy = (rowDesignInfo[TblDesignInfo.CheckedBy] as string).Trim();
                    designInfo.ApprovedBy = (rowDesignInfo[TblDesignInfo.ApprovedBy] as string).Trim();

                    designInfo.AppendDrawingID = (rowDesignInfo[TblDesignInfo.AppendDrawingID] as string).Trim();
                    designInfo.AppendDrawingIDNumber = Convert.ToInt32(rowDesignInfo[TblDesignInfo.AppendDrawingIDNumber]);
                    
                } catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return designInfo;
        }

        #endregion // Create Design Info


        #region .Create IDS Data Struct

        #region .创建系统.

        #region .CreateIDSSystems.

        public static IDSSystemCollection CreateIDSSystems(DataTable tableLoop,
                                                            DataTable tableHierarchy,
                                                            DataTable tableEquipment,
                                                            DataTable tableSubEquipment,
                                                            DataTable tableRepositories,
                                                            DataTable tableCable,
                                                            DataTable tableMountingScheme)
        {
            if (tableLoop == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableLoop equals to null");

            if (tableHierarchy == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableHierarchy equals to null");

            if (tableEquipment == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableEquipment equals to null");

            if (tableSubEquipment == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableSubEquipment equals to null");

            if (tableRepositories == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableRepositories equals to null");

            if (tableCable == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableCable equals to null");

            if (tableMountingScheme == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter tableMountingScheme equals to null");

            IDSSystemCollection systems = new IDSSystemCollection();

            if (tableHierarchy.Rows.Count <= 0) {
                return systems;
            }

            foreach (DataRow rowSystem in tableHierarchy.Rows) {
                if (IDSEnumSystemType.System == Convert.ToString(rowSystem[TblIDSHierarchy.Type]).Trim())
                    systems.Add(CreateIDSSystem(rowSystem,
                                                tableLoop,
                                                tableHierarchy,
                                                tableEquipment,
                                                tableSubEquipment,
                                                tableRepositories,
                                                tableCable,
                                                tableMountingScheme));
            }

            return systems;
        }

        public static IDSSystemCollection CreateIDSSystems(DataRow[] rowSystems,
                                                            DataTable tableLoop,
                                                            DataTable tableHierarchy,
                                                            DataTable tableEquipment,
                                                            DataTable tableSubEquipment,
                                                            DataTable tableRepositories,
                                                            DataTable tableCable,
                                                            DataTable tableMountingScheme)
        {
            if (rowSystems == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystems", "Parameter rowSystems equals to null");

            IDSSystemCollection systems = new IDSSystemCollection();

            if (rowSystems.Length <= 0) {
                return systems;
            }

            foreach (DataRow rowSystem in rowSystems) {
                systems.Add(CreateIDSSystem(rowSystem,
                                            tableLoop,
                                            tableHierarchy,
                                            tableEquipment,
                                            tableSubEquipment,
                                            tableRepositories,
                                            tableCable,
                                            tableMountingScheme));
            }

            return systems;
        }


        #endregion

        #region .CreateIDSSystem.

        public static IDSSystem CreateIDSSystem(DataRow rowSystem,
                                                DataTable tableLoop,
                                                DataTable tableHierarchy,
                                                DataTable tableEquipment,
                                                DataTable tableSubEquipment,
                                                DataTable tableRepositories,
                                                DataTable tableCable,
                                                DataTable tableMountingScheme)
        {
            if (rowSystem == null)
                throw new System.ArgumentNullException("frome function CreateIDSSystem", "Parameter rowSystem equals to null");

            IDSSystem system = new IDSSystem();

            lock (rowSystem) {
                try {
                    system.ID = Convert.ToString(rowSystem[TblIDSHierarchy.ID]).Trim();
                    system.ParentID = Convert.ToString(rowSystem[TblIDSHierarchy.ParentID]).Trim();

                    system.Code = (rowSystem[TblIDSHierarchy.Code] as string).Trim();
                    system.Name = (rowSystem[TblIDSHierarchy.Name] as string).Trim();

                    system.Phase = (rowSystem[TblIDSHierarchy.Phase] as string).Trim();
                    system.SerialNumber = Convert.ToString(rowSystem[TblIDSHierarchy.SerialNumber]).Trim();
                    system.Description = (rowSystem[TblIDSHierarchy.Description] as string).Trim();

                    system.SubSystems.Clear();
                    lock (tableHierarchy) {
                        foreach (DataRow rowSubSystem in tableHierarchy.Rows) {
                            if (Convert.ToString(rowSubSystem[TblIDSHierarchy.ParentID]).Trim() == system.ID
                                    && Convert.ToString(rowSubSystem[TblIDSHierarchy.Type]).Trim() == IDSEnumSystemType.SubSystem)
                                system.SubSystems.Add(CreateIDSSubSystem(rowSubSystem,
                                                                    system.Code,
                                                                    tableLoop,
                                                                    tableHierarchy,
                                                                    tableEquipment,
                                                                    tableSubEquipment,
                                                                    tableRepositories,
                                                                    tableCable,
                                                                    tableMountingScheme));
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return system;
        }

        #endregion

        #endregion


        #region .创建子系统.

        #region .CreateIDSSubSystem.

        public static IDSSubSystem CreateIDSSubSystem(DataRow rowSubSystem,
                                                        string systemCode,
                                                        DataTable tableLoop,
                                                        DataTable tableHierarchy,
                                                        DataTable tableEquipment,
                                                        DataTable tableSubEquipment,
                                                        DataTable tableRepositories,
                                                        DataTable tableCable,
                                                        DataTable tableMountingScheme)
        {
            if (rowSubSystem == null)
                throw new System.ArgumentNullException("frome function CreateIDSSubSystem", "Parameter rowSubSystem equals to null");

            IDSSubSystem subSystem = new IDSSubSystem();

            lock (rowSubSystem) {
                try {
                    subSystem.ID = Convert.ToString(rowSubSystem[TblIDSHierarchy.ID]).Trim();
                    subSystem.ParentID = Convert.ToString(rowSubSystem[TblIDSHierarchy.ParentID]).Trim();

                    subSystem.Code = (rowSubSystem[TblIDSHierarchy.Code] as string).Trim();
                    subSystem.Name = (rowSubSystem[TblIDSHierarchy.Name] as string).Trim();

                    subSystem.IsNameInLoop = Convert.ToBoolean(rowSubSystem[TblIDSHierarchy.IsNameInLoop]);
                    subSystem.Phase = (rowSubSystem[TblIDSHierarchy.Phase] as string).Trim();
                    subSystem.SerialNumber = Convert.ToString(rowSubSystem[TblIDSHierarchy.SerialNumber]).Trim();
                    subSystem.Description = (rowSubSystem[TblIDSHierarchy.Description] as string).Trim();

                    subSystem.Loops.Clear();
                    lock (tableLoop) {
                        foreach (DataRow rowLoop in tableLoop.Rows) {
                            if (Convert.ToString(rowLoop[TblIDSLoop.ParentID]).Trim() == subSystem.ID)
                                subSystem.Loops.Add(CreateIDSLoop(rowLoop,
                                                                    subSystem.Code,
                                                                    systemCode,
                                                                    tableHierarchy,
                                                                    tableEquipment,
                                                                    tableSubEquipment,
                                                                    tableRepositories,
                                                                    tableCable,
                                                                    tableMountingScheme));
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return subSystem;
        }

        #endregion

        #endregion


        #region .创建回路.

        #region .CreateIDSLoop.

        public static IDSLoop CreateIDSLoop(DataRow rowLoop,
                                            string subSystemCode,
                                            string systemCode,
                                            DataTable tableHierarchy,
                                            DataTable tableEquipment,
                                            DataTable tableSubEquipment,
                                            DataTable tableRepositories,
                                            DataTable tableCable,
                                            DataTable tableMountingScheme)
        {
            if (rowLoop == null)
                throw new System.ArgumentNullException("frome function CreateIDSLoop", "Parameter rowLoop equals to null");

            IDSLoop loop = new IDSLoop();

            lock (rowLoop) {
                try {
                    loop.ID = Convert.ToString(rowLoop[TblIDSLoop.ID]).Trim();
                    loop.ParentID = Convert.ToString(rowLoop[TblIDSLoop.ParentID]).Trim();

                    loop.LoopType = (rowLoop[TblIDSLoop.LoopType] as string).Trim();
                    loop.SerialNumber = (rowLoop[TblIDSLoop.SerialNumber] as string).Trim();
                    loop.Suffix = (rowLoop[TblIDSLoop.Suffix] as string).Trim();

                    loop.Tag = systemCode + "." + loop.LoopType + "-" + subSystemCode + loop.SerialNumber + loop.Suffix;

                    loop.Location = (rowLoop[TblIDSLoop.Location] as string).Trim();
                    loop.Medium = (rowLoop[TblIDSLoop.Medium] as string).Trim();
                    loop.Parameter = (rowLoop[TblIDSLoop.Parameter] as string).Trim();
                    loop.NormalTemperature = (rowLoop[TblIDSLoop.NormalTemperature] as string).Trim();
                    loop.UplimitTemperature = (rowLoop[TblIDSLoop.UplimitTemperature] as string).Trim();
                    loop.NormalPressure = (rowLoop[TblIDSLoop.NormalPressure] as string).Trim();
                    loop.UplimitPressure = (rowLoop[TblIDSLoop.UplimitPressure] as string).Trim();
                    loop.PressureUnit = (rowLoop[TblIDSLoop.PressureUnit] as string).Trim();
                    loop.PipeMaterial = (rowLoop[TblIDSLoop.PipeMaterial] as string).Trim();
                    loop.DN = (rowLoop[TblIDSLoop.DN] as string).Trim();
                    loop.ContainerMaterial = (rowLoop[TblIDSLoop.ContainerMaterial] as string).Trim();
                    loop.HasInnerLining = Convert.ToBoolean(rowLoop[TblIDSLoop.HasInnerLining]);
                    loop.AmbientTemperature = (rowLoop[TblIDSLoop.AmbientTemperature] as string).Trim();
                    loop.AmbientExLevel = (rowLoop[TblIDSLoop.AmbientExLevel] as string).Trim();
                    loop.MediumExLevel = (rowLoop[TblIDSLoop.MediumExLevel] as string).Trim();
                    loop.MeasurementRange = (rowLoop[TblIDSLoop.MeasurementRange] as string).Trim();
                    loop.ProcessRange = (rowLoop[TblIDSLoop.ProcessRange] as string).Trim();
                    loop.Unit = (rowLoop[TblIDSLoop.Unit] as string).Trim();
                    loop.Function = (rowLoop[TblIDSLoop.Function] as string).Trim();
                    loop.Description = (rowLoop[TblIDSLoop.Description] as string).Trim();
                    loop.Source = (rowLoop[TblIDSLoop.Source] as string).Trim();

                    loop.SubLoops.Clear();
                    lock (tableHierarchy) {
                        foreach (DataRow rowSubLoop in tableHierarchy.Rows) {
                            if (Convert.ToString(rowSubLoop[TblIDSHierarchy.ParentID]).Trim() == loop.ID
                                    && Convert.ToString(rowSubLoop[TblIDSHierarchy.Type]).Trim() == IDSEnumSystemType.SubLoop)
                                loop.SubLoops.Add(CreateIDSSubLoop(rowSubLoop,
                                                                    loop.LoopType,
                                                                    loop.SerialNumber,
                                                                    loop.Suffix,
                                                                    subSystemCode,
                                                                    systemCode,
                                                                    loop.Location,
                                                                    tableEquipment,
                                                                    tableSubEquipment,
                                                                    tableRepositories,
                                                                    tableCable,
                                                                    tableMountingScheme));
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return loop;
        }

        #endregion

        #endregion


        #region .创建子回路.

        #region .CreateIDSSubLoop.
        public static IDSSubLoop CreateIDSSubLoop(DataRow rowSubLoop,
                                                    string loopType,
                                                    string loopSerialNumber,
                                                    string loopSuffix,
                                                    string subSystemCode,
                                                    string systemCode,
                                                    string location,
                                                    DataTable tableEquipment,
                                                    DataTable tableSubEquipment,
                                                    DataTable tableRepositories,
                                                    DataTable tableCable,
                                                    DataTable tableMountingScheme)
        {
            if (rowSubLoop == null)
                throw new System.ArgumentNullException("frome function CreateIDSSubLoop", "Parameter rowSubLoop equals to null");

            IDSSubLoop subLoop = new IDSSubLoop();

            lock (rowSubLoop) {
                try {
                    subLoop.ID = Convert.ToString(rowSubLoop[TblIDSHierarchy.ID]).Trim();
                    subLoop.ParentID = Convert.ToString(rowSubLoop[TblIDSHierarchy.ParentID]).Trim();

                    subLoop.Code = (rowSubLoop[TblIDSHierarchy.Code] as string).Trim();
                    subLoop.Name = (rowSubLoop[TblIDSHierarchy.Name] as string).Trim();

                    subLoop.IsNameInSubLoop = Convert.ToBoolean(rowSubLoop[TblIDSHierarchy.IsNameInLoop]);
                    subLoop.IsNameInFront = Convert.ToBoolean(rowSubLoop[TblIDSHierarchy.IsNameInFront]);
                    subLoop.Phase = (rowSubLoop[TblIDSHierarchy.Phase] as string).Trim();
                    subLoop.SerialNumber = Convert.ToString(rowSubLoop[TblIDSHierarchy.SerialNumber]).Trim();
                    subLoop.Description = (rowSubLoop[TblIDSHierarchy.Description] as string).Trim();

                    subLoop.Equipments.Clear();
                    lock (tableEquipment) {
                        foreach (DataRow rowEquipment in tableEquipment.Rows) {
                            if (Convert.ToString(rowEquipment[TblIDSEquipment.ParentID]).Trim() == subLoop.ID)
                                subLoop.Equipments.Add(CreateIDSEquipment(rowEquipment,
                                                                            loopType,
                                                                            loopSerialNumber,
                                                                            loopSuffix,
                                                                            subSystemCode,
                                                                            systemCode,
                                                                            location,
                                                                            tableSubEquipment,
                                                                            tableRepositories,
                                                                            tableCable,
                                                                            tableMountingScheme));
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return subLoop;
        }

        #endregion

        #endregion


        #region .创建设备.

        #region .CreateIDSEquipment.
        public static IDSEquipment CreateIDSEquipment(DataRow rowIDSEquipment,
                                                        string loopType,
                                                        string loopSerialNumber,
                                                        string loopSuffix,
                                                        string subSystemCode,
                                                        string systemCode,
                                                        string location,
                                                        DataTable tableSubEquipment,
                                                        DataTable tableRepositories,
                                                        DataTable tableCable,
                                                        DataTable tableMountingScheme)
        {
            if (rowIDSEquipment == null)
                throw new System.ArgumentNullException("frome function CreateIDSEquipment", "Parameter rowIDSEquipment equals to null");

            IDSEquipment equipment = new IDSEquipment();

            lock (rowIDSEquipment) {
                try {
                    equipment.ID = Convert.ToString(rowIDSEquipment[TblIDSEquipment.ID]).Trim();
                    equipment.ParentID = Convert.ToString(rowIDSEquipment[TblIDSEquipment.ParentID]).Trim();

                    equipment.FunctionCode = (rowIDSEquipment[TblIDSEquipment.Function] as string).Trim();

                    equipment.Tag = (rowIDSEquipment[TblIDSEquipment.Tag] as string).Trim();
                    equipment.Suffix = (rowIDSEquipment[TblIDSEquipment.Suffix] as string).Trim();
                    if (IDSEnumWayToGenerateSymbol.AutoGenerate == equipment.Tag)
                        equipment.Tag = systemCode + "." + loopType + equipment.FunctionCode + "-" + subSystemCode + loopSerialNumber + loopSuffix + equipment.Suffix;
                                  
                    equipment.EquipmentCatagory = (rowIDSEquipment[TblIDSEquipment.EquipmentCatagory] as string).Trim();
                    equipment.SpecificInfo1 = (rowIDSEquipment[TblIDSEquipment.SpecificeInfo1] as string).Trim();
                    equipment.SpecificInfo2 = (rowIDSEquipment[TblIDSEquipment.SpecificeInfo2] as string).Trim();
                    equipment.Quantity = Convert.ToInt32(rowIDSEquipment[TblIDSEquipment.Quantity]);
                    equipment.Remark = (rowIDSEquipment[TblIDSEquipment.Remark] as string).Trim();

                    string repositoryName = Convert.ToString(rowIDSEquipment[TblIDSEquipment.EquipmentRepositoryID]).Trim();

                    if (repositoryName != null && repositoryName != "")
                        lock (tableRepositories) {
                            foreach (DataRow rowRepository in tableRepositories.Rows) {
                                if (Convert.ToString(rowRepository[TblIDSRepository.RepositoryID]) == repositoryName) {
                                    equipment.EquipmentRepository = CreateIDSRepository(rowRepository);
                                    break;
                                }
                            }
                        }
                    
                    equipment.SubEquipments.Clear();
                    lock (tableSubEquipment) {
                        foreach (DataRow rowSubEquipment in tableSubEquipment.Rows) {
                            if (Convert.ToString(rowSubEquipment[TblIDSSubEquipment.ParentID]).Trim() == equipment.ID)
                                equipment.SubEquipments.Add(CreateIDSSubEquipment(rowSubEquipment, 
                                                                                    equipment.Tag,
                                                                                    location,
                                                                                    tableCable,
                                                                                    tableMountingScheme));
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return equipment;
        }
        #endregion

        #endregion


        #region .创建子设备.
               
        #region .CreateIDSSubEquipment.
        public static IDSSubEquipment CreateIDSSubEquipment(DataRow rowIDSSubEquipment, 
                                                            string equipmentTag, 
                                                            string location,
                                                            DataTable tableIDSCable,
                                                            DataTable tableIDSMountingScheme)
        {
            if (rowIDSSubEquipment == null)
                throw new System.ArgumentNullException("frome function CreateIDSSubEquipment", "Parameter rowIDSSubEquipment equals to null");

            IDSSubEquipment subEquipment = new IDSSubEquipment();

            lock (rowIDSSubEquipment) {
                try {
                    subEquipment.ID = Convert.ToString(rowIDSSubEquipment[TblIDSSubEquipment.ID]);
                    subEquipment.ParentID = Convert.ToString(rowIDSSubEquipment[TblIDSSubEquipment.ParentID]);

                    subEquipment.Tag = (rowIDSSubEquipment[TblIDSSubEquipment.Tag] as string);
                    if (IDSEnumWayToGenerateSymbol.AutoGenerate == subEquipment.Tag)
                        subEquipment.Tag = equipmentTag;

                    subEquipment.FunctionCode = (rowIDSSubEquipment[TblIDSSubEquipment.FunctionCode] as string).Trim();
                    subEquipment.Suffix = (rowIDSSubEquipment[TblIDSSubEquipment.Suffix] as string).Trim();
                    subEquipment.NameSuffix = (rowIDSSubEquipment[TblIDSSubEquipment.NameSuffix] as string).Trim();
                    subEquipment.MountingType = (rowIDSSubEquipment[TblIDSSubEquipment.MountingType] as string).Trim();

                    subEquipment.MountingLocation = (rowIDSSubEquipment[TblIDSSubEquipment.MountingLocation] as string).Trim();
                    if (IDSEnumLocationSymbol.On == subEquipment.MountingLocation)
                        subEquipment.MountingLocation = location;
                    else if (IDSEnumLocationSymbol.OnTheSide == subEquipment.MountingLocation)
                        subEquipment.MountingLocation = location + "旁";

                    subEquipment.DataPlate = (rowIDSSubEquipment[TblIDSSubEquipment.DataPlate] as string).Trim();
                    subEquipment.PowerSupply = (rowIDSSubEquipment[TblIDSSubEquipment.PowerSupply] as string).Trim();
                    subEquipment.SwitchTag = (rowIDSSubEquipment[TblIDSSubEquipment.MountingLocation] as string).Trim();
                    subEquipment.ActingCurrent = (rowIDSSubEquipment[TblIDSSubEquipment.ActingCurrent] as string).Trim();

                    string mountingSchemeID = (rowIDSSubEquipment[TblIDSSubEquipment.MountingSchemeID] as string).Trim();

                    subEquipment.Cables.Clear();
                    lock (tableIDSCable) {
                        foreach (DataRow rowCable in tableIDSCable.Rows) {
                            if (Convert.ToString(rowCable[TblIDSCable.ParentID]).Trim() == subEquipment.ID)
                                subEquipment.Cables.Add(CreateIDSCable(rowCable));
                        }
                    }

                    if (mountingSchemeID != null) {
                        lock (tableIDSMountingScheme) {
                            foreach (DataRow rowMountingScheme in tableIDSMountingScheme.Rows) {
                                if (Convert.ToString(rowMountingScheme[TblIDSMountingScheme.ParentID]).Trim() == subEquipment.ID) {
                                    subEquipment.MountingScheme = CreateIDSMountingScheme(rowMountingScheme);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }
            
            return subEquipment;
        }
        #endregion

        #endregion


        #region .创建电缆 - 未完成.

        #region .CreateIDSCable.
        public static IDSCable CreateIDSCable(DataRow rowIDSCable)
        {
            return new IDSCable();
        }

        #endregion

        #endregion


        #region .创建安装方案 - 未完成.

        #region .CreateIDSMountingScheme.
        public static IDSMountingScheme CreateIDSMountingScheme(DataRow rowIDSMountingScheme)
        {
            return new IDSMountingScheme();
        }

        #endregion

        #endregion


        #region .创建库设备.

        #region .CreateIDSRepositories.
        public static IDSRepositoryCollection CreateIDSRepositories(DataRow[] rowIDSRepositories)
        {
            if (rowIDSRepositories == null)
                throw new System.ArgumentNullException("from function CreateIDSRepositories", "Parameter rowIDSRepository equals to null");

            IDSRepositoryCollection repositories = new IDSRepositoryCollection();

            if (rowIDSRepositories.Length <= 0)
                return repositories;

            lock (rowIDSRepositories) {
                try {
                    foreach (DataRow rowRepository in rowIDSRepositories)
                        repositories.Add(CreateIDSRepository(rowRepository));
                }
                catch (DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return repositories;
        }
        #endregion

        #region .CreateIDSRepository.
        public static IDSRepository CreateIDSRepository(DataRow rowIDSRepository)
        {
            if (rowIDSRepository == null)
                throw new System.ArgumentNullException("frome function CreateIDSRepository", "Parameter rowIDSRepository equals to null");

            IDSRepository repository = new IDSRepository();
           
            lock (rowIDSRepository) {
                try {
                    repository.ID = Convert.ToString(rowIDSRepository[TblIDSRepository.ID]);
                    repository.ParentID = Convert.ToString(rowIDSRepository[TblIDSRepository.ParentID]);

                    repository.RepositoryID = (rowIDSRepository[TblIDSRepository.RepositoryID] as string);
                    repository.Type = (rowIDSRepository[TblIDSRepository.Type] as string);
                    repository.Version = (rowIDSRepository[TblIDSRepository.Version] as string);
                    repository.Attribute = Convert.ToString(rowIDSRepository[TblIDSRepository.Attribute]);
                    repository.Name = Convert.ToString(rowIDSRepository[TblIDSRepository.Name]);
                    repository.Usage = (rowIDSRepository[TblIDSRepository.Usage] as string);
                    repository.ModelNumber = (rowIDSRepository[TblIDSRepository.ModelNumber] as string);

                    Int32 indexOfSymbol = repository.RepositoryID.LastIndexOf("__");
                    Int32 repositoryIDLength = repository.RepositoryID.Length;
                    repository.Supplier = indexOfSymbol != -1 ? repository.RepositoryID.Substring(indexOfSymbol + 2) : "";

                    repository.NameSuffix = Convert.ToString(rowIDSRepository[TblIDSRepository.NameSuffix]);
                    repository.TerminalDefinition = Convert.ToString(rowIDSRepository[TblIDSRepository.TerminalDefinition]);
                    repository.QuantityUnit = Convert.ToString(rowIDSRepository[TblIDSRepository.QuantityUnit]);
                    repository.NotPrintOut = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.NotPrintOut]);

                    if (repository.Usage.Length > 3) {
                        //if (repository.Usage[0] == '/' && repository.Usage[1] == '/' && repository.Usage[2] == '/')
                        if(repository.Usage.Substring(0,3) == "///")
                            repository.ExportAllowed = false;
                        else
                            repository.ExportAllowed = true;
                    } else {
                        repository.ExportAllowed = true;
                    }

                    repository.Text01 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text01]).Trim();
                    repository.Text02 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text02]).Trim();
                    repository.Text03 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text03]).Trim();
                    repository.Text04 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text04]).Trim();
                    repository.Text05 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text05]).Trim();
                    repository.Text06 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text06]).Trim();
                    repository.Text07 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text07]).Trim();
                    repository.Text08 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text08]).Trim();
                    repository.Text09 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text09]).Trim();
                    repository.Text10 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text10]).Trim();
                    repository.Text11 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text11]).Trim();
                    repository.Text12 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text12]).Trim();
                    repository.Text13 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text13]).Trim();
                    repository.Text14 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text14]).Trim();
                    repository.Text15 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text15]).Trim();
                    repository.Text16 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text16]).Trim();
                    repository.Text17 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text17]).Trim();
                    repository.Text18 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text18]).Trim();
                    repository.Text19 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text19]).Trim();
                    repository.Text20 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text20]).Trim();
                    repository.Text21 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text21]).Trim();
                    repository.Text22 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text22]).Trim();
                    repository.Text23 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text23]).Trim();
                    repository.Text24 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text24]).Trim();
                    repository.Text25 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text25]).Trim();
                    repository.Text26 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text26]).Trim();
                    repository.Text27 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text27]).Trim();
                    repository.Text28 = Convert.ToString(rowIDSRepository[TblIDSRepository.Text28]).Trim();

                    repository.Remark01 = Convert.ToString(rowIDSRepository[TblIDSRepository.Remark01]).Trim();
                    repository.Remark02 = Convert.ToString(rowIDSRepository[TblIDSRepository.Remark02]).Trim();
                    repository.Remark03 = Convert.ToString(rowIDSRepository[TblIDSRepository.Remark03]).Trim();

                    repository.Value01 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value01]);
                    repository.Value02 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value02]);
                    repository.Value03 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value03]);
                    repository.Value04 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value04]);
                    repository.Value05 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value05]);
                    repository.Value06 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value06]);
                    repository.Value07 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value07]);
                    repository.Value08 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value08]);
                    repository.Value09 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value09]);
                    repository.Value10 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value10]);
                    repository.Value11 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value11]);
                    repository.Value12 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value12]);
                    repository.Value13 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value13]);
                    repository.Value14 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value14]);
                    repository.Value15 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value15]);
                    repository.Value16 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value16]);
                    repository.Value17 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value17]);
                    repository.Value18 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value18]);
                    repository.Value19 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value19]);
                    repository.Value20 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value20]);
                    repository.Value21 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value21]);
                    repository.Value22 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value22]);
                    repository.Value23 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value23]);
                    repository.Value24 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value24]);
                    repository.Value25 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value25]);
                    repository.Value26 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value26]);
                    repository.Value27 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value27]);
                    repository.Value28 = Convert.ToInt32(rowIDSRepository[TblIDSRepository.Value28]);

                    repository.YesOrNo01 = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.YesOrNo01]);
                    repository.YesOrNo02 = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.YesOrNo02]);
                    repository.YesOrNo03 = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.YesOrNo03]);
                    repository.YesOrNo04 = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.YesOrNo04]);
                    repository.YesOrNo05 = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.YesOrNo05]);

                    repository.ProtectionEnabled = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.ProtectionEnabled]);
                }
                catch (System.Data.DataException ex) {
                    MessageBoxWinForm.Info("数据访问错误", ex.Message, "");
                }
            }

            return repository;
        }
        #endregion

        #endregion

        #endregion // Create IDS Data Struct
    }
}
