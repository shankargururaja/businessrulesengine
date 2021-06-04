using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Entity
{
    /// <summary>
    /// Request class for order processing
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Order Instance
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// List of Actions to be performed on the Order by the handlers
        /// </summary>
        public HashSet<Actions> Actions { get;}

        public Request()
        {
            Actions = new HashSet<Actions>(); 
        }

    }

    public enum Actions {

        /// <summary>
        /// create a duplicate packing slip for the royalty department
        /// </summary>
        CREATE_DUPLI_PACK_SLIP_FOR_ROYALTY_DEPARTMENT,
        /// <summary>
        /// generate a commission payment to the agent.
        /// </summary>
        GEN_COMMISSION_PAYMENT_FOR_AGENT,
        /// <summary>
        /// generate a packing slip for shipping.
        /// </summary>
        GEN_PACKING_SLIP_FOR_SHIPPING,
        /// <summary>
        /// activate membership.
        /// </summary>
        ACTIVATE_MEMBERSHIP,
        /// <summary>
        /// apply theupgrade.
        /// </summary>
        UPGRADE_MEMBERSHIP,
        /// <summary>
        /// e-mail the owner and inform them of the activation/upgrade.
        /// </summary>
        EMAIL_OWNER_ABT_ACTIVATION,
        /// <summary>
        /// add a free “First Aid” video to the packing slip
        /// </summary>
        ADD_FIRST_AID_VIDEO_TO_PACKING_SLIP

    }


}
