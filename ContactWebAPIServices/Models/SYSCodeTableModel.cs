using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ContactWebAPIServices.Models
{
    /// <summary>
    /// SYSCode - This classis mapped with SYS_CODE table and
    /// contains fields which are directly mapped to table columns of system code.
    /// </summary>
    [Table("SYS_CODE")]
    public class SYSCodeTableModel
    {
        #region SysCode table columns
        [Key]
        public int ID { get; set; }
        public string DESCREPTION { get; set; }
        public string META_DATA { get; set; }
        public string CODE_GROUP { get; set; }

        #endregion SysCode table columns
    }

    /// <summary>
    /// SYSCode - This class contains fields of system code.
    /// </summary>
    public class SYSCodeViewModel
    {
        #region SysCode model properties

        public int ID { get; set; }
        public string Descreption { get; set; }
        public string MetaData { get; set; }
        public string CodeGroup { get; set; }

        #endregion SysCode model properties
    }

    /// <summary>
    /// SYSCode - This class has all the static method to provide system code details.
    /// </summary>
    public static class SYSCode
    {
        #region SysCode static method
        /// <summary>
        /// SYSCode - This method is used to get all system code collection.
        /// </summary>
        /// <returns>SYSCode collection</returns>
        public static List<SYSCodeTableModel> GetSYSCode()
        {
            using (MyDBContext lbusCon = new MyDBContext())
            {
                var lclbSYSCode = lbusCon.idtbStatusTableModel.ToList();
                return lclbSYSCode;
            }
        }

        /// <summary>
        /// SYSCode - This method is used to get system code by code id.
        /// </summary>
        /// <param name="aCodeID">Code id</param>
        /// <returns>SYSCode model</returns>
        public static SYSCodeTableModel GetSYSCodeByCodeID(int aCodeID)
        {
            using (MyDBContext lbusCon = new MyDBContext())
            {
                if (aCodeID > 0)
                {
                    var lclbSYSCode = lbusCon.idtbStatusTableModel.Where(c => c.ID == aCodeID).FirstOrDefault();
                    return lclbSYSCode;
                }
                else
                    return new SYSCodeTableModel();
            }
        }

        /// <summary>
        /// SYSCode - This method is used to get system code collection by code group.
        /// </summary>
        /// <param name="astrCodeGroup">Code group id</param>
        /// <returns>SYSCode collection</returns>
        public static List<SYSCodeTableModel> GetSYSCodeByGroupID(string astrCodeGroup)
        {
            using (MyDBContext lbusCon = new MyDBContext())
            {
                if (!string.IsNullOrEmpty(astrCodeGroup))
                {
                    var lclbSYSCode = lbusCon.idtbStatusTableModel.Where(c => c.CODE_GROUP == astrCodeGroup).ToList();
                    return lclbSYSCode;
                }
                else
                    return new List<SYSCodeTableModel>();
            }
        }

        #endregion SysCode static method
    }


}
