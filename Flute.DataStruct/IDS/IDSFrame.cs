using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.DataStruct.IDS
{
    public class IDSFrame
    {
        private IDSSystemCollection _systems = null;
        public IDSSystemCollection Systems
        {
            get { return _systems; }
            set { _systems = value; }
        }

        private IDSRepositoryCategoryCollection _repositoryCategories = null;
        public IDSRepositoryCategoryCollection RepositoryCategories
        {
            get { return _repositoryCategories; }
            set { _repositoryCategories = value; }
        }

        public IDSFrame()
        {
            _systems = new IDSSystemCollection();
            _repositoryCategories = new IDSRepositoryCategoryCollection();
        }
    }
}
