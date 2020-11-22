using System;
using System.Reflection;
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

        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {
            WriteObject(new AtemClient(IPAddress,true));            
        }

        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }
    [Cmdlet(VerbsCommon.Get,"ATEMModuleVersion")]   
    [OutputType(typeof(string))] 
    public class ATEMModuleVersion : PSCmdlet
    {
        [Parameter(Position = 0)]
    public string Version
    {
        get { return version; }
    }
    private string version;
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }
        protected override void ProcessRecord()
        {            
            //version = $"{Assembly.GetEntryAssembly().GetName().Version}"; 
            //version = $"{Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}";
            version = $"{Assembly.GetExecutingAssembly().GetName().Version.ToString()}"; 
            WriteObject(version);           
        }
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
                //client.SendCommand(new MixEffectCutCommand{Index = MixEffectBlockId.One});
                return client;            
        }   
    } 

    
}
