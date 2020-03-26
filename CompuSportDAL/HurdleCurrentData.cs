﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CompuSportDataAccess
{
    public class HurdleCurrentData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["compusport.Data.ConnectionString"].ToString();

        # region Variables 
        public int _HurdleCurrentDataId;
        public int _LessonId;
        public int _GroundTimeOff;
        public int _GroundTimeInto;
        public int _AirTimeOver;
        public int _StrideLengthInto;
        public int _StrideLengthOff;
        public int _Velocity;
        public int _COGDistanceInto;
        public int _COGDistanceOff;
        public int _ULAngleTDInto;
        public int _ULAngleTOInto;
        public int _ULAngleTDOff;
        public int _LeadLegMinimumAngle;
        public int _LeadLegAngleAC;
        public int _LLAngleTDOff;
        public int _LLAngleTOOff;
        # endregion Variables

        # region Properties
        public int HurdleCurrentDataId
        {
            get { return _HurdleCurrentDataId; }
            set { _HurdleCurrentDataId = value; }
        }
        public int LessonId
        {
            get { return _LessonId; }
            set { _LessonId = value; }
        }
        public int GroundTimeInto
        {
            get { return _GroundTimeInto; }
            set { _GroundTimeInto = value; }
        }
        public int GroundTimeOff
        {
            get { return _GroundTimeOff; }
            set { _GroundTimeOff = value; }
        }
        public int AirTimeOver
        {
            get { return _AirTimeOver; }
            set { _AirTimeOver = value; }
        }
        public int StrideLengthInto
        {
            get { return _StrideLengthInto; }
            set { _StrideLengthInto = value;}
        }
        public int StrideLengthOff
        {

            get { return _StrideLengthOff;}
            set { _StrideLengthOff = value; }
        }
        public int Velocity
        {
            get { return _Velocity; }
            set { _Velocity = value; }
        }
        public int COGDistanceInto
        {
            get { return _COGDistanceInto; }
            set { _COGDistanceInto = value; }
        
        }
        public int COGDistanceOff
        {
            get { return _COGDistanceOff; }
            set { _COGDistanceOff = value; }
        }
        public int ULAngleTDInto
        {
            get { return _ULAngleTDInto; }
            set { _ULAngleTDInto = value; }
        }
        public int ULAngleTOInto
        {
            get { return _ULAngleTOInto;}
            set { _ULAngleTOInto = value; }
        }

        public int ULAngleTDOff
        {
            get { return _ULAngleTDOff;}
            set { _ULAngleTDOff = value;}
        }
        public int LeadLegMinimumAngle
        {
            get { return _LeadLegMinimumAngle; }
            set { _LeadLegMinimumAngle = value; }
        }
        public int LeadLegAngleAC
        {
            get { return _LeadLegAngleAC; }
            set { _LeadLegAngleAC = value; }
        }
        public int LLAngleTDOff
        {
            get { return _LLAngleTDOff; }
            set { _LLAngleTDOff = value; }
        }
        public int LLAngleTOOff
        {
            get { return _LLAngleTOOff; }
            set { _LLAngleTOOff = value; }
        }
        # endregion Properties
    }
}
