﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.CRMSocket {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CRMSocket.ISocketMgtService")]
    public interface ISocketMgtService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketMgtService/HasLogged", ReplyAction="http://tempuri.org/ISocketMgtService/HasLoggedResponse")]
        bool HasLogged(string account, string ip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISocketMgtService/HasLogged", ReplyAction="http://tempuri.org/ISocketMgtService/HasLoggedResponse")]
        System.Threading.Tasks.Task<bool> HasLoggedAsync(string account, string ip);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISocketMgtServiceChannel : CRM.CRMSocket.ISocketMgtService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SocketMgtServiceClient : System.ServiceModel.ClientBase<CRM.CRMSocket.ISocketMgtService>, CRM.CRMSocket.ISocketMgtService {
        
        public SocketMgtServiceClient() {
        }
        
        public SocketMgtServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SocketMgtServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SocketMgtServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SocketMgtServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool HasLogged(string account, string ip) {
            return base.Channel.HasLogged(account, ip);
        }
        
        public System.Threading.Tasks.Task<bool> HasLoggedAsync(string account, string ip) {
            return base.Channel.HasLoggedAsync(account, ip);
        }
    }
}
