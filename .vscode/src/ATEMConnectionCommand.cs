using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Commands.SuperSource;
using LibAtem.Common;
using LibAtem.Net;

// [OutputType(typeof(LibAtem.Net.AtemClient))]
namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Add,"ATEMSwitch")]
    [OutputType(typeof(AtemClient))]
    public class ATEMConnectionCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string IPAddress { get; set; }
        
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
             //AtemClient myclient;
            //myclient = new AtemClient(IPAddress, true);
            //myclient.SendCommand(new MixEffectCutCommand{Index = MixEffectBlockId.One});
            //WriteObject(myclient);
            WriteObject(new AtemClient(IPAddress,true));
            
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    public class ATEMSwitch{
        //private AtemClient myclient;
        //public string IPAddress { get; set; }
         //public event EventHandler<ATEMEventArgs> ATEMEvent;
        public AtemClient client(string thisip){

                var client = new AtemClient(thisip,true);
                //client.OnReceive += OnCommand;
                client.SendCommand(new MixEffectCutCommand{Index = MixEffectBlockId.One});
                return client;            
        }
        
    }

    [Cmdlet(VerbsCommon.Set,"ATEMMECut")]
        [OutputType(typeof(bool))]
        
    public class ATEMGetConnections : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public AtemClient ATEMref { get; set; }
        [Parameter(
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public int MEID { get; set; } =0;
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            //var ATEMSwitch = new AtemClient(IPAddress);
            //WriteObject(ATEMSwitch);
            
            ATEMref.SendCommand(new MixEffectCutCommand {Index = (MixEffectBlockId)MEID});
            WriteObject(true);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    
}
