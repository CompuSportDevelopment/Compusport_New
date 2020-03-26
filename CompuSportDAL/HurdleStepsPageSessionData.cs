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
    class HurdleStepsPageSessionData
    {
        HurdleStepsData _initialDataHurdleSteps = new HurdleStepsData();
        HurdleStepsData _finalDataHurdleSteps = new HurdleStepsData();
        HurdleStepsData _ModelDataHurdleSteps = new HurdleStepsData();

        public void SetHurdleStepsInitialData(DataRow drInitial)
        {

            _initialDataHurdleSteps.SetHurdleStepData(drInitial);
        }
        public void SetHurdleStepsFinalData(DataRow drFinal)
        {
            _finalDataHurdleSteps.SetHurdleStepData(drFinal);
        }
        public void SetHurdleStepsModelData(DataRow drModel)
        {
            _ModelDataHurdleSteps.SetHurdleStepData(drModel);
        }

        public HurdleStepsData HurdleStepsInitialData
        {
            get
            {
                return _initialDataHurdleSteps;
            }
        }
        public HurdleStepsData HurdleStepsFinalData
        {
            get
            {
                return _finalDataHurdleSteps;
            }
        }
        public HurdleStepsData HurdleStepsModelData
        {
            get
            {
                return _ModelDataHurdleSteps;
            }
        }

    }
}

