﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18408.
// 
#pragma warning disable 1591

namespace Coop.MemberService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MemberServiceSoap", Namespace="http://tempuri.org/")]
    public partial class MemberService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AuthenticateMemberOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateMemberOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MemberService() {
            this.Url = global::Coop.Properties.Settings.Default.Coop_MemberService_MemberService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AuthenticateMemberCompletedEventHandler AuthenticateMemberCompleted;
        
        /// <remarks/>
        public event CreateMemberCompletedEventHandler CreateMemberCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AuthenticateMember", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Member AuthenticateMember(string hash, double latitude, double longitude) {
            object[] results = this.Invoke("AuthenticateMember", new object[] {
                        hash,
                        latitude,
                        longitude});
            return ((Member)(results[0]));
        }
        
        /// <remarks/>
        public void AuthenticateMemberAsync(string hash, double latitude, double longitude) {
            this.AuthenticateMemberAsync(hash, latitude, longitude, null);
        }
        
        /// <remarks/>
        public void AuthenticateMemberAsync(string hash, double latitude, double longitude, object userState) {
            if ((this.AuthenticateMemberOperationCompleted == null)) {
                this.AuthenticateMemberOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateMemberOperationCompleted);
            }
            this.InvokeAsync("AuthenticateMember", new object[] {
                        hash,
                        latitude,
                        longitude}, this.AuthenticateMemberOperationCompleted, userState);
        }
        
        private void OnAuthenticateMemberOperationCompleted(object arg) {
            if ((this.AuthenticateMemberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateMemberCompleted(this, new AuthenticateMemberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateMember", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Member CreateMember(string name, string email, int creditUnion, double latitude, double longitude) {
            object[] results = this.Invoke("CreateMember", new object[] {
                        name,
                        email,
                        creditUnion,
                        latitude,
                        longitude});
            return ((Member)(results[0]));
        }
        
        /// <remarks/>
        public void CreateMemberAsync(string name, string email, int creditUnion, double latitude, double longitude) {
            this.CreateMemberAsync(name, email, creditUnion, latitude, longitude, null);
        }
        
        /// <remarks/>
        public void CreateMemberAsync(string name, string email, int creditUnion, double latitude, double longitude, object userState) {
            if ((this.CreateMemberOperationCompleted == null)) {
                this.CreateMemberOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateMemberOperationCompleted);
            }
            this.InvokeAsync("CreateMember", new object[] {
                        name,
                        email,
                        creditUnion,
                        latitude,
                        longitude}, this.CreateMemberOperationCompleted, userState);
        }
        
        private void OnCreateMemberOperationCompleted(object arg) {
            if ((this.CreateMemberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateMemberCompleted(this, new CreateMemberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Member {
        
        private string hashField;
        
        private string nameField;
        
        private CreditUnion cuField;
        
        private double latitudeField;
        
        private double longitudeField;
        
        /// <remarks/>
        public string Hash {
            get {
                return this.hashField;
            }
            set {
                this.hashField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public CreditUnion CU {
            get {
                return this.cuField;
            }
            set {
                this.cuField = value;
            }
        }
        
        /// <remarks/>
        public double Latitude {
            get {
                return this.latitudeField;
            }
            set {
                this.latitudeField = value;
            }
        }
        
        /// <remarks/>
        public double Longitude {
            get {
                return this.longitudeField;
            }
            set {
                this.longitudeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CreditUnion {
        
        private string nameField;
        
        private string abbrField;
        
        private string websiteField;
        
        private double latitudeField;
        
        private double longitudeField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Abbr {
            get {
                return this.abbrField;
            }
            set {
                this.abbrField = value;
            }
        }
        
        /// <remarks/>
        public string Website {
            get {
                return this.websiteField;
            }
            set {
                this.websiteField = value;
            }
        }
        
        /// <remarks/>
        public double Latitude {
            get {
                return this.latitudeField;
            }
            set {
                this.latitudeField = value;
            }
        }
        
        /// <remarks/>
        public double Longitude {
            get {
                return this.longitudeField;
            }
            set {
                this.longitudeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void AuthenticateMemberCompletedEventHandler(object sender, AuthenticateMemberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateMemberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AuthenticateMemberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Member Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Member)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void CreateMemberCompletedEventHandler(object sender, CreateMemberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateMemberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateMemberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Member Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Member)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591