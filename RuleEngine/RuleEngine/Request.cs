using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public class Request
    {
        public object Data { get; set; }

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
        GEN_COMMISSION_PAYMENT_FOR_AGENT

    }


}
