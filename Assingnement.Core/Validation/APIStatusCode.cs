using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingnement.Core.Validation
{
    public static class APIStatusCode
    {
        #region ERR01 - General Errors

        /// <summary>
        /// General Error Code
        /// </summary>
        public const string ERR01001 = "ERR01001";

        /// <summary>
        /// Record not found on this ID
        /// </summary>
        public const string ERR01002 = "ERR01002";

        /// <summary>
        /// Invalid parameter Or parameters
        /// </summary>
        public const string ERR01003 = "ERR01003";

        /// <summary>
        /// Main group can't duplicate or delete
        /// </summary>
        public const string ERR01006 = "ERR01006";

        /// <summary>
        ///  The record couldnt add to DB
        /// </summary>
        public const string ERR01008 = "ERR01008";


        #endregion

        #region ERR03 - ModelState Errors

        /// <summary>
        ///  Field Required
        /// </summary>
        public const string ERR03001 = "ERR03001";

        /// <summary>
        ///  Min Length Error
        /// </summary>
        public const string ERR03002 = "ERR03002";

        /// <summary>
        ///  Max Length Error
        /// </summary>
        public const string ERR03003 = "ERR03003";

        /// <summary>
        ///  Passwords Is Not Match
        /// </summary>
        public const string ERR03004 = "ERR03004";

        #endregion
    }
}
