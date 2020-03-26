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
    class HurdlePageSessionData
    {
        HurdleData _initialDataHurdle = new HurdleData();
        HurdleData _finalDataHurdle = new HurdleData();
        HurdleData _ModelDataHurdle = new HurdleData();

        public void SetHurdleInitialData(DataRow drInitial)
        {

            _initialDataHurdle.SetdataHurdle(drInitial);
        }
        public void SetHurdleFinalData(DataRow drFinal)
        {
            _finalDataHurdle.SetdataHurdle(drFinal);
        }
        public void SetHurdleModelData(DataRow drModel)
        {
            _ModelDataHurdle.SetdataHurdle(drModel);
        }

        public HurdleData HurdleInitialData
        {
            get
            {
                return _initialDataHurdle;
            }
        }
        public HurdleData HurdleFinalData
        {
            get
            {
                return _finalDataHurdle;
            }
        }
        public HurdleData HurdleModelData
        {
            get
            {
                return _ModelDataHurdle;
            }
        }
    }
}
