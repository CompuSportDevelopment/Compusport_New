using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CompuSportDAL
{
    public class VariableData
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        #region[SprintVariable]
        public int _lessonId { get; set; }
        public decimal _groundTimeLeft { get; set; }
        public decimal _groundTimeRight { get; set; }
        public decimal _airTimeLeftToRight { get; set; }
        public decimal _airTimeRightToLeft { get; set; }
        public decimal _timeToUpperLegFullFlexionLeft { get; set; }
        public decimal _timeToUpperLegFullFlexionRight { get; set; }
        public decimal _strideLengthLeftToRight { get; set; }
        public decimal _strideLengthRightToLeft { get; set; }
        public decimal _kSATouchDownLeft { get; set; }
        public decimal _kSATouchDownRight { get; set; }
        public decimal _trunkAngleAtTouchdownLeft { get; set; }
        public decimal _trunkAngleAtTouchdownRight { get; set; }
        public decimal _kneeSeperationAtTouchdownLeft { get; set; }
        public decimal _kneeSeperationAtTouchdownRight { get; set; }
        public int _touchDownDistanceLeft { get; set; }
        public int _touchDownDistanceRight { get; set; }
        public int _upperLegFullExtentionAngleLeft { get; set; }
        public int _upperLegFullExtentionAngleRight { get; set; }
        public int _lowerLegAngleAtTakeOfLeft { get; set; }
        public int _lowerLegAngleAtTakeOfRight { get; set; }
        public int _lowerLegFullFlexionAngleLeft { get; set; }
        public int _lowerLegFullFlexionAngleRight { get; set; }
        public int _upperLegFullFlexionAngleLeft { get; set; }
        public int _upperLegFullFlexionAngleRight { get; set; }
       

        #endregion[SprintVariable]
        decimal convertToDecimal(object data)
        {
            decimal value = 0;
            if (data != null && data.ToString() != string.Empty)
            {
                value = Convert.ToDecimal(data);
            }
            return value;
        }
        int convertToInt(object data)
        {
            int value = 0;
            if (data != null && data.ToString() != string.Empty)
            {
                value = Convert.ToInt32(data);
            }
            return value;
        }

        public void Setdata(DataRow drData)
        {
            //_lessonId =Convert.ToInt16(drData["LessonId"]);
            _groundTimeLeft = convertToDecimal(drData["Ground Time Left"]);
            _groundTimeRight = convertToDecimal(drData["Ground Time Right"]);
            _airTimeLeftToRight = convertToDecimal(drData["Air Time Left to Right"]);
            _airTimeRightToLeft = convertToDecimal(drData["Air Time Right to Left"]);
            _timeToUpperLegFullFlexionLeft = convertToDecimal(drData["Time to Upper Leg Full Flexion Left"]);
            _timeToUpperLegFullFlexionRight = convertToDecimal(drData["Time to Upper Leg Full Flexion Right"]);
            _strideLengthLeftToRight = convertToDecimal(drData["Stride Length Left to Right"]);
            _strideLengthRightToLeft = convertToDecimal(drData["Stride Length Right to Left"]);
            _kneeSeperationAtTouchdownLeft = convertToDecimal(drData["KSATouchDownLeft"]);
            _kneeSeperationAtTouchdownRight = convertToDecimal(drData["KSATouchDownRight"]);
            _trunkAngleAtTouchdownLeft = convertToDecimal(drData["Touchdown Distance Left"]);
            _trunkAngleAtTouchdownRight = convertToDecimal(drData["Touchdown Distance Right"]);
            _touchDownDistanceLeft = convertToInt(drData["TAATouchDownLeft"]);
            _touchDownDistanceRight = convertToInt(drData["TAATouchDownRight"]);
            _upperLegFullFlexionAngleLeft = convertToInt(drData["Upper Leg Full Extension Angle Left"]);
            _upperLegFullFlexionAngleRight = convertToInt(drData["Upper Leg Full Extension Angle Right"]);
            _upperLegFullExtentionAngleLeft = convertToInt(drData["Upper Leg Full Flexion Angle Left"]);
            _upperLegFullExtentionAngleRight = convertToInt(drData["Upper Leg Full Flexion Angle Right"]);
            _lowerLegAngleAtTakeOfLeft = convertToInt(drData["Lower Leg Angle at Takeoff Left"]);
            _lowerLegAngleAtTakeOfRight = convertToInt(drData["Lower Leg Angle at Takeoff Right"]);
            _lowerLegFullFlexionAngleLeft = convertToInt(drData["Lower Leg Full Flexion Angle Left"]);
            _lowerLegFullFlexionAngleRight = convertToInt(drData["Lower Leg Full Flexion Angle Right"]);
        }

        public short LessonId { get; set; }
    }
}
