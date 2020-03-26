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
    public class SessionData
    {
        SprintData _initialData = new SprintData();
        SprintData _finalData = new SprintData();
        SprintData _ModelData = new SprintData();

        public void SetInitialData(DataRow drInitial)
        {

            _initialData.Setdata(drInitial);
        }

        public void SetFinalData(DataRow drFinal)
        {
            _finalData.Setdata(drFinal);
        }
        public void SetModelData(DataRow drModel)
        {
            _ModelData.SetOnTrackModeldata(drModel);
        }


        public SprintData InitialData
        {
            get
            {
                return _initialData;
            }
        }

        public SprintData FinalData
        {
            get
            {
                return _finalData;
            }
        }
        public SprintData ModelData
        {
            get
            {
                return _ModelData;
            }
        }
    }
}
