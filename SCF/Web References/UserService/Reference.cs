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

namespace Coop.UserService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="UserServiceSoap", Namespace="http://tempuri.org/")]
    public partial class UserService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AuthenticateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetUserAccessOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public UserService() {
            this.Url = global::Coop.Properties.Settings.Default.Coop_UserService_UserService;
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
        public event AuthenticateUserCompletedEventHandler AuthenticateUserCompleted;
        
        /// <remarks/>
        public event CreateUserCompletedEventHandler CreateUserCompleted;
        
        /// <remarks/>
        public event SetUserAccessCompletedEventHandler SetUserAccessCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AuthenticateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User AuthenticateUser(string email, string pass) {
            object[] results = this.Invoke("AuthenticateUser", new object[] {
                        email,
                        pass});
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        public void AuthenticateUserAsync(string email, string pass) {
            this.AuthenticateUserAsync(email, pass, null);
        }
        
        /// <remarks/>
        public void AuthenticateUserAsync(string email, string pass, object userState) {
            if ((this.AuthenticateUserOperationCompleted == null)) {
                this.AuthenticateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateUserOperationCompleted);
            }
            this.InvokeAsync("AuthenticateUser", new object[] {
                        email,
                        pass}, this.AuthenticateUserOperationCompleted, userState);
        }
        
        private void OnAuthenticateUserOperationCompleted(object arg) {
            if ((this.AuthenticateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateUserCompleted(this, new AuthenticateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User CreateUser(string name, string email, string pass, int creditUnion) {
            object[] results = this.Invoke("CreateUser", new object[] {
                        name,
                        email,
                        pass,
                        creditUnion});
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        public void CreateUserAsync(string name, string email, string pass, int creditUnion) {
            this.CreateUserAsync(name, email, pass, creditUnion, null);
        }
        
        /// <remarks/>
        public void CreateUserAsync(string name, string email, string pass, int creditUnion, object userState) {
            if ((this.CreateUserOperationCompleted == null)) {
                this.CreateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateUserOperationCompleted);
            }
            this.InvokeAsync("CreateUser", new object[] {
                        name,
                        email,
                        pass,
                        creditUnion}, this.CreateUserOperationCompleted, userState);
        }
        
        private void OnCreateUserOperationCompleted(object arg) {
            if ((this.CreateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateUserCompleted(this, new CreateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetUserAccess", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User SetUserAccess(string userHash, int userID, int newAccessLevel) {
            object[] results = this.Invoke("SetUserAccess", new object[] {
                        userHash,
                        userID,
                        newAccessLevel});
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        public void SetUserAccessAsync(string userHash, int userID, int newAccessLevel) {
            this.SetUserAccessAsync(userHash, userID, newAccessLevel, null);
        }
        
        /// <remarks/>
        public void SetUserAccessAsync(string userHash, int userID, int newAccessLevel, object userState) {
            if ((this.SetUserAccessOperationCompleted == null)) {
                this.SetUserAccessOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetUserAccessOperationCompleted);
            }
            this.InvokeAsync("SetUserAccess", new object[] {
                        userHash,
                        userID,
                        newAccessLevel}, this.SetUserAccessOperationCompleted, userState);
        }
        
        private void OnSetUserAccessOperationCompleted(object arg) {
            if ((this.SetUserAccessCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetUserAccessCompleted(this, new SetUserAccessCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class User {
        
        private string hashField;
        
        private string nameField;
        
        private string emailField;
        
        private CreditUnion cuField;
        
        private int accessLevelField;
        
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
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
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
        public int AccessLevel {
            get {
                return this.accessLevelField;
            }
            set {
                this.accessLevelField = value;
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
        
        private int idField;
        
        private string nameField;
        
        private string abbrField;
        
        private string websiteField;
        
        private double latitudeField;
        
        private double longitudeField;
        
        /// <remarks/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
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
    public delegate void AuthenticateUserCompletedEventHandler(object sender, AuthenticateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AuthenticateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public User Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((User)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void CreateUserCompletedEventHandler(object sender, CreateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public User Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((User)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SetUserAccessCompletedEventHandler(object sender, SetUserAccessCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetUserAccessCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetUserAccessCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public User Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((User)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591