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

        #region .CreateIDSSubEquipment.

        #region .CreateIDSRepository.
        public static IDSRepository CreateIDSRepository(DataRow rowIDSRepository)
        {
            if (rowIDSRepository == null)
                throw new System.ArgumentNullException("frome function CreateIDSRepository", "Parameter rowIDSRepository equals to null");

            IDSRepository repository = new IDSRepository();
           
            lock (rowIDSRepository) {
                try {
                    repository.RepositoryID = (rowIDSRepository[TblIDSRepository.RepositoryID] as string).Trim();
                    repository.Type = (rowIDSRepository[TblIDSRepository.Type] as string).Trim();
                    repository.Version = (rowIDSRepository[TblIDSRepository.Version] as string).Trim();
                    repository.Attribute = (rowIDSRepository[TblIDSRepository.Attribute] as string).Trim();
                    repository.Name = (rowIDSRepository[TblIDSRepository.Name] as string).Trim();
                    repository.Usage = (rowIDSRepository[TblIDSRepository.Usage] as string).Trim();
                    repository.ModelNumber = (rowIDSRepository[TblIDSRepository.ModelNumber] as string).Trim();
                    repository.NameSuffix = (rowIDSRepository[TblIDSRepository.NameSuffix] as string).Trim();
                    repository.TerminalDefinition = (rowIDSRepository[TblIDSRepository.TerminalDefinition] as string).Trim();
                    repository.QuantityUnit = (rowIDSRepository[TblIDSRepository.QuantityUnit] as string).Trim();
                    repository.NotPrintOut = Convert.ToBoolean(rowIDSRepository[TblIDSRepository.NotPrintOut]);

                    repository.Text01 = (rowIDSRepository[TblIDSRepository.Text01] as string).Trim();
                    repository.Text02 = (rowIDSRepository[TblIDSRepository.Text02] as string).Trim();
                    repository.Text03 = (rowIDSRepository[TblIDSRepository.Text03] as string).Trim();
                    repository.Text04 = (rowIDSRepository[TblIDSRepository.Text04] as string).Trim();
                    repository.Text05 = (rowIDSRepository[TblIDSRepository.Text05] as string).Trim();
                    repository.Text06 = (rowIDSRepository[TblIDSRepository.Text06] as string).Trim();
                    repository.Text07 = (rowIDSRepository[TblIDSRepository.Text07] as string).Trim();
                    repository.Text08 = (rowIDSRepository[TblIDSRepository.Text08] as string).Trim();
                    repository.Text09 = (rowIDSRepository[TblIDSRepository.Text09] as string).Trim();
                    repository.Text10 = (rowIDSRepository[TblIDSRepository.Text10] as string).Trim();
                    repository.Text11 = (rowIDSRepository[TblIDSRepository.Text11] as string).Trim();
                    repository.Text12 = (rowIDSRepository[TblIDSRepository.Text12] as string).Trim();
                    repository.Text13 = (rowIDSRepository[TblIDSRepository.Text13] as string).Trim();
                    repository.Text14 = (rowIDSRepository[TblIDSRepository.Text14] as string).Trim();
                    repository.Text15 = (rowIDSRepository[TblIDSRepository.Text15] as string).Trim();
                    repository.Text16 = (rowIDSRepository[TblIDSRepository.Text16] as string).Trim();
                    repository.Text17 = (rowIDSRepository[TblIDSRepository.Text17] as string).Trim();
                    repository.Text18 = (rowIDSRepository[TblIDSRepository.Text18] as string).Trim();
                    repository.Text19 = (rowIDSRepository[TblIDSRepository.Text19] as string).Trim();
                    repository.Text20 = (rowIDSRepository[TblIDSRepository.Text20] as string).Trim();
                    repository.Text21 = (rowIDSRepository[TblIDSRepository.Text21] as string).Trim();
                    repository.Text22 = (rowIDSRepository[TblIDSRepository.Text22] as string).Trim();
                    repository.Text23 = (rowIDSRepository[TblIDSRepository.Text23] as string).Trim();
                    repository.Text24 = (rowIDSRepository[TblIDSRepository.Text24] as string).Trim();
                    repository.Text25 = (rowIDSRepository[TblIDSRepository.Text25] as string).Trim();
                    repository.Text26 = (rowIDSRepository[TblIDSRepository.Text26] as string).Trim();
                    repository.Text27 = (rowIDSRepository[TblIDSRepository.Text27] as string).Trim();
                    repository.Text28 = (rowIDSRepository[TblIDSRepository.Text28] as string).Trim();

                    repository.Remark01 = (rowIDSRepository[TblIDSRepository.Remark01] as string).Trim();
                    repository.Remark02 = (rowIDSRepository[TblIDSRepository.Remark02] as string).Trim();
                    repository.Remark03 = (rowIDSRepository[TblIDSRepository.Remark03] as string).Trim();

                    repository.Value01 = (rowIDSRepository[TblIDSRepository.Value01] as string).Trim();
                    repository.Value02 = (rowIDSRepository[TblIDSRepository.Value02] as string).Trim();
                    repository.Value03 = (rowIDSRepository[TblIDSRepository.Value03] as string).Trim();
                    repository.Value04 = (rowIDSRepository[TblIDSRepository.Value04] as string).Trim();
                    repository.Value05 = (rowIDSRepository[TblIDSRepository.Value05] as string).Trim();
                    repository.Value06 = (rowIDSRepository[TblIDSRepository.Value06] as string).Trim();
                    repository.Value07 = (rowIDSRepository[TblIDSRepository.Value07] as string).Trim();
                    repository.Value08 = (rowIDSRepository[TblIDSRepository.Value08] as string).Trim();
                    repository.Value09 = (rowIDSRepository[TblIDSRepository.Value09] as string).Trim();
                    repository.Value10 = (rowIDSRepository[TblIDSRepository.Value10] as string).Trim();
                    repository.Value11 = (rowIDSRepository[TblIDSRepository.Value11] as string).Trim();
                    repository.Value12 = (rowIDSRepository[TblIDSRepository.Value12] as string).Trim();
                    repository.Value13 = (rowIDSRepository[TblIDSRepository.Value13] as string).Trim();
                    repository.Value14 = (rowIDSRepository[TblIDSRepository.Value14] as string).Trim();
                    repository.Value15 = (rowIDSRepository[TblIDSRepository.Value15] as string).Trim();
                    repository.Value16 = (rowIDSRepository[TblIDSRepository.Value16] as string).Trim();
                    repository.Value17 = (rowIDSRepository[TblIDSRepository.Value17] as string).Trim();
                    repository.Value18 = (rowIDSRepository[TblIDSRepository.Value18] as string).Trim();
                    repository.Value19 = (rowIDSRepository[TblIDSRepository.Value19] as string).Trim();
                    repository.Value20 = (rowIDSRepository[TblIDSRepository.Value20] as string).Trim();
                    repository.Value21 = (rowIDSRepository[TblIDSRepository.Value21] as string).Trim();
                    repository.Value22 = (rowIDSRepository[TblIDSRepository.Value22] as string).Trim();
                    repository.Value23 = (rowIDSRepository[TblIDSRepository.Value23] as string).Trim();
                    repository.Value24 = (rowIDSRepository[TblIDSRepository.Value24] as string).Trim();
                    repository.Value25 = (rowIDSRepository[TblIDSRepository.Value25] as string).Trim();
                    repository.Value26 = (rowIDSRepository[TblIDSRepository.Value26] as string).Trim();
                    repository.Value27 = (rowIDSRepository[TblIDSRepository.Value27] as string).Trim();
                    repository.Value28 = (rowIDSRepository[TblIDSRepository.Value28] as string).Trim();

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
    }
}
