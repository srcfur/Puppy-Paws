using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naninovel;
using static Naninovel.Command;
using UnityEngine;

namespace SunnyPaws.NaniCommands
{
    [Serializable, Alias("SetPlayerControlState")]
    public class SetPlayerControlState : Command
    {
        public BooleanParameter Enabled;

        public override Awaitable Execute(ExecutionContext ctx)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = Enabled.Value;
            return Async.Completed;
        }
    }
}
