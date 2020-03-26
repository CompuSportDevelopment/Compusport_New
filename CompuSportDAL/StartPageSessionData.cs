using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using compusport.Entities;

namespace CompuSportDAL
{
    class StartPageSessionData
    {
        StartInitialData _initialDataStart = new StartInitialData();
        StartInitialData _finalDataStart = new StartInitialData();
        StartInitialData _ModelDataStart = new StartInitialData();

        public void SetStartInitialData(DataRow drInitial)
        {

            _initialDataStart.SetdataStart(drInitial);
        }
        public void SetStartFinalData(DataRow drFinal)
        {
            _finalDataStart.SetdataStart(drFinal);
        }
        public void SetStartModelData(DataRow drModel)
        {
            _ModelDataStart.SetdataStart(drModel);
        }

        public StartInitialData StartInitialData
        {
            get
            {
                return _initialDataStart;
            }
        }
        public StartInitialData StartFinalData
        {
            get
            {
                return _finalDataStart;
            }
        }
        public StartInitialData StartModelData
        {
            get
            {
                return _ModelDataStart;
            }
        }
    }
}
