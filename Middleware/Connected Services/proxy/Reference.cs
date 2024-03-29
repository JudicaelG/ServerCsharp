﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Middleware.proxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://facade.communication.cesi.com/", ConfigurationName="proxy.AcquisitionEndpoint")]
    public interface AcquisitionEndpoint {
        
        // CODEGEN : La génération du contrat de message depuis le nom d'élément email de l'espace de noms  n'est pas marqué nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://facade.communication.cesi.com/AcquisitionEndpoint/acquisitionOperationRequ" +
            "est", ReplyAction="http://facade.communication.cesi.com/AcquisitionEndpoint/acquisitionOperationResp" +
            "onse")]
        Middleware.proxy.acquisitionOperationResponse acquisitionOperation(Middleware.proxy.acquisitionOperationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://facade.communication.cesi.com/AcquisitionEndpoint/acquisitionOperationRequ" +
            "est", ReplyAction="http://facade.communication.cesi.com/AcquisitionEndpoint/acquisitionOperationResp" +
            "onse")]
        System.Threading.Tasks.Task<Middleware.proxy.acquisitionOperationResponse> acquisitionOperationAsync(Middleware.proxy.acquisitionOperationRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class acquisitionOperationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="acquisitionOperation", Namespace="http://facade.communication.cesi.com/", Order=0)]
        public Middleware.proxy.acquisitionOperationRequestBody Body;
        
        public acquisitionOperationRequest() {
        }
        
        public acquisitionOperationRequest(Middleware.proxy.acquisitionOperationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class acquisitionOperationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string key;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string decipherMessage;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string appToken;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string fileName;
        
        public acquisitionOperationRequestBody() {
        }
        
        public acquisitionOperationRequestBody(string email, string key, string decipherMessage, string appToken, string fileName) {
            this.email = email;
            this.key = key;
            this.decipherMessage = decipherMessage;
            this.appToken = appToken;
            this.fileName = fileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class acquisitionOperationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="acquisitionOperationResponse", Namespace="http://facade.communication.cesi.com/", Order=0)]
        public Middleware.proxy.acquisitionOperationResponseBody Body;
        
        public acquisitionOperationResponse() {
        }
        
        public acquisitionOperationResponse(Middleware.proxy.acquisitionOperationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class acquisitionOperationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool acceptedAcquisition;
        
        public acquisitionOperationResponseBody() {
        }
        
        public acquisitionOperationResponseBody(bool acceptedAcquisition) {
            this.acceptedAcquisition = acceptedAcquisition;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AcquisitionEndpointChannel : Middleware.proxy.AcquisitionEndpoint, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AcquisitionEndpointClient : System.ServiceModel.ClientBase<Middleware.proxy.AcquisitionEndpoint>, Middleware.proxy.AcquisitionEndpoint {
        
        public AcquisitionEndpointClient() {
        }
        
        public AcquisitionEndpointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AcquisitionEndpointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AcquisitionEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AcquisitionEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Middleware.proxy.acquisitionOperationResponse Middleware.proxy.AcquisitionEndpoint.acquisitionOperation(Middleware.proxy.acquisitionOperationRequest request) {
            return base.Channel.acquisitionOperation(request);
        }
        
        public bool acquisitionOperation(string email, string key, string decipherMessage, string appToken, string fileName) {
            Middleware.proxy.acquisitionOperationRequest inValue = new Middleware.proxy.acquisitionOperationRequest();
            inValue.Body = new Middleware.proxy.acquisitionOperationRequestBody();
            inValue.Body.email = email;
            inValue.Body.key = key;
            inValue.Body.decipherMessage = decipherMessage;
            inValue.Body.appToken = appToken;
            inValue.Body.fileName = fileName;
            Middleware.proxy.acquisitionOperationResponse retVal = ((Middleware.proxy.AcquisitionEndpoint)(this)).acquisitionOperation(inValue);
            return retVal.Body.acceptedAcquisition;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Middleware.proxy.acquisitionOperationResponse> Middleware.proxy.AcquisitionEndpoint.acquisitionOperationAsync(Middleware.proxy.acquisitionOperationRequest request) {
            return base.Channel.acquisitionOperationAsync(request);
        }
        
        public System.Threading.Tasks.Task<Middleware.proxy.acquisitionOperationResponse> acquisitionOperationAsync(string email, string key, string decipherMessage, string appToken, string fileName) {
            Middleware.proxy.acquisitionOperationRequest inValue = new Middleware.proxy.acquisitionOperationRequest();
            inValue.Body = new Middleware.proxy.acquisitionOperationRequestBody();
            inValue.Body.email = email;
            inValue.Body.key = key;
            inValue.Body.decipherMessage = decipherMessage;
            inValue.Body.appToken = appToken;
            inValue.Body.fileName = fileName;
            return ((Middleware.proxy.AcquisitionEndpoint)(this)).acquisitionOperationAsync(inValue);
        }
    }
}
