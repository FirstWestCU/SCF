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

namespace Coop.CategoryService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="CategoryServiceSoap", Namespace="http://tempuri.org/")]
    public partial class CategoryService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCategoryDescriptionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCategoryIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCategoriesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CategoryService() {
            this.Url = global::Coop.Properties.Settings.Default.Coop_CategoryService_CategoryService;
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
        public event GetCategoryDescriptionCompletedEventHandler GetCategoryDescriptionCompleted;
        
        /// <remarks/>
        public event GetCategoryIDCompletedEventHandler GetCategoryIDCompleted;
        
        /// <remarks/>
        public event GetCategoriesCompletedEventHandler GetCategoriesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCategoryDescription", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetCategoryDescription(int id) {
            object[] results = this.Invoke("GetCategoryDescription", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetCategoryDescriptionAsync(int id) {
            this.GetCategoryDescriptionAsync(id, null);
        }
        
        /// <remarks/>
        public void GetCategoryDescriptionAsync(int id, object userState) {
            if ((this.GetCategoryDescriptionOperationCompleted == null)) {
                this.GetCategoryDescriptionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCategoryDescriptionOperationCompleted);
            }
            this.InvokeAsync("GetCategoryDescription", new object[] {
                        id}, this.GetCategoryDescriptionOperationCompleted, userState);
        }
        
        private void OnGetCategoryDescriptionOperationCompleted(object arg) {
            if ((this.GetCategoryDescriptionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCategoryDescriptionCompleted(this, new GetCategoryDescriptionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCategoryID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetCategoryID(string description) {
            object[] results = this.Invoke("GetCategoryID", new object[] {
                        description});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetCategoryIDAsync(string description) {
            this.GetCategoryIDAsync(description, null);
        }
        
        /// <remarks/>
        public void GetCategoryIDAsync(string description, object userState) {
            if ((this.GetCategoryIDOperationCompleted == null)) {
                this.GetCategoryIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCategoryIDOperationCompleted);
            }
            this.InvokeAsync("GetCategoryID", new object[] {
                        description}, this.GetCategoryIDOperationCompleted, userState);
        }
        
        private void OnGetCategoryIDOperationCompleted(object arg) {
            if ((this.GetCategoryIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCategoryIDCompleted(this, new GetCategoryIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCategories", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Category[] GetCategories() {
            object[] results = this.Invoke("GetCategories", new object[0]);
            return ((Category[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCategoriesAsync() {
            this.GetCategoriesAsync(null);
        }
        
        /// <remarks/>
        public void GetCategoriesAsync(object userState) {
            if ((this.GetCategoriesOperationCompleted == null)) {
                this.GetCategoriesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCategoriesOperationCompleted);
            }
            this.InvokeAsync("GetCategories", new object[0], this.GetCategoriesOperationCompleted, userState);
        }
        
        private void OnGetCategoriesOperationCompleted(object arg) {
            if ((this.GetCategoriesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCategoriesCompleted(this, new GetCategoriesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class Category {
        
        private int idField;
        
        private string descriptionField;
        
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
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCategoryDescriptionCompletedEventHandler(object sender, GetCategoryDescriptionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCategoryDescriptionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCategoryDescriptionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCategoryIDCompletedEventHandler(object sender, GetCategoryIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCategoryIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCategoryIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetCategoriesCompletedEventHandler(object sender, GetCategoriesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCategoriesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCategoriesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Category[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Category[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591