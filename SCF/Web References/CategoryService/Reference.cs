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
        
        private System.Threading.SendOrPostCallback GetProjectCategoryDescriptionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDonationCategoryDescriptionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProjectCategoryIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDonationCategoryIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProjectCategoriesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDonationCategoriesOperationCompleted;
        
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
        public event GetProjectCategoryDescriptionCompletedEventHandler GetProjectCategoryDescriptionCompleted;
        
        /// <remarks/>
        public event GetDonationCategoryDescriptionCompletedEventHandler GetDonationCategoryDescriptionCompleted;
        
        /// <remarks/>
        public event GetProjectCategoryIDCompletedEventHandler GetProjectCategoryIDCompleted;
        
        /// <remarks/>
        public event GetDonationCategoryIDCompletedEventHandler GetDonationCategoryIDCompleted;
        
        /// <remarks/>
        public event GetProjectCategoriesCompletedEventHandler GetProjectCategoriesCompleted;
        
        /// <remarks/>
        public event GetDonationCategoriesCompletedEventHandler GetDonationCategoriesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProjectCategoryDescription", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetProjectCategoryDescription(int id) {
            object[] results = this.Invoke("GetProjectCategoryDescription", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetProjectCategoryDescriptionAsync(int id) {
            this.GetProjectCategoryDescriptionAsync(id, null);
        }
        
        /// <remarks/>
        public void GetProjectCategoryDescriptionAsync(int id, object userState) {
            if ((this.GetProjectCategoryDescriptionOperationCompleted == null)) {
                this.GetProjectCategoryDescriptionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProjectCategoryDescriptionOperationCompleted);
            }
            this.InvokeAsync("GetProjectCategoryDescription", new object[] {
                        id}, this.GetProjectCategoryDescriptionOperationCompleted, userState);
        }
        
        private void OnGetProjectCategoryDescriptionOperationCompleted(object arg) {
            if ((this.GetProjectCategoryDescriptionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProjectCategoryDescriptionCompleted(this, new GetProjectCategoryDescriptionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDonationCategoryDescription", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetDonationCategoryDescription(int id) {
            object[] results = this.Invoke("GetDonationCategoryDescription", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDonationCategoryDescriptionAsync(int id) {
            this.GetDonationCategoryDescriptionAsync(id, null);
        }
        
        /// <remarks/>
        public void GetDonationCategoryDescriptionAsync(int id, object userState) {
            if ((this.GetDonationCategoryDescriptionOperationCompleted == null)) {
                this.GetDonationCategoryDescriptionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDonationCategoryDescriptionOperationCompleted);
            }
            this.InvokeAsync("GetDonationCategoryDescription", new object[] {
                        id}, this.GetDonationCategoryDescriptionOperationCompleted, userState);
        }
        
        private void OnGetDonationCategoryDescriptionOperationCompleted(object arg) {
            if ((this.GetDonationCategoryDescriptionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDonationCategoryDescriptionCompleted(this, new GetDonationCategoryDescriptionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProjectCategoryID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetProjectCategoryID(string description) {
            object[] results = this.Invoke("GetProjectCategoryID", new object[] {
                        description});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetProjectCategoryIDAsync(string description) {
            this.GetProjectCategoryIDAsync(description, null);
        }
        
        /// <remarks/>
        public void GetProjectCategoryIDAsync(string description, object userState) {
            if ((this.GetProjectCategoryIDOperationCompleted == null)) {
                this.GetProjectCategoryIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProjectCategoryIDOperationCompleted);
            }
            this.InvokeAsync("GetProjectCategoryID", new object[] {
                        description}, this.GetProjectCategoryIDOperationCompleted, userState);
        }
        
        private void OnGetProjectCategoryIDOperationCompleted(object arg) {
            if ((this.GetProjectCategoryIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProjectCategoryIDCompleted(this, new GetProjectCategoryIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDonationCategoryID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetDonationCategoryID(string description) {
            object[] results = this.Invoke("GetDonationCategoryID", new object[] {
                        description});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetDonationCategoryIDAsync(string description) {
            this.GetDonationCategoryIDAsync(description, null);
        }
        
        /// <remarks/>
        public void GetDonationCategoryIDAsync(string description, object userState) {
            if ((this.GetDonationCategoryIDOperationCompleted == null)) {
                this.GetDonationCategoryIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDonationCategoryIDOperationCompleted);
            }
            this.InvokeAsync("GetDonationCategoryID", new object[] {
                        description}, this.GetDonationCategoryIDOperationCompleted, userState);
        }
        
        private void OnGetDonationCategoryIDOperationCompleted(object arg) {
            if ((this.GetDonationCategoryIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDonationCategoryIDCompleted(this, new GetDonationCategoryIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProjectCategories", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Category[] GetProjectCategories() {
            object[] results = this.Invoke("GetProjectCategories", new object[0]);
            return ((Category[])(results[0]));
        }
        
        /// <remarks/>
        public void GetProjectCategoriesAsync() {
            this.GetProjectCategoriesAsync(null);
        }
        
        /// <remarks/>
        public void GetProjectCategoriesAsync(object userState) {
            if ((this.GetProjectCategoriesOperationCompleted == null)) {
                this.GetProjectCategoriesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProjectCategoriesOperationCompleted);
            }
            this.InvokeAsync("GetProjectCategories", new object[0], this.GetProjectCategoriesOperationCompleted, userState);
        }
        
        private void OnGetProjectCategoriesOperationCompleted(object arg) {
            if ((this.GetProjectCategoriesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProjectCategoriesCompleted(this, new GetProjectCategoriesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDonationCategories", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Category[] GetDonationCategories() {
            object[] results = this.Invoke("GetDonationCategories", new object[0]);
            return ((Category[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDonationCategoriesAsync() {
            this.GetDonationCategoriesAsync(null);
        }
        
        /// <remarks/>
        public void GetDonationCategoriesAsync(object userState) {
            if ((this.GetDonationCategoriesOperationCompleted == null)) {
                this.GetDonationCategoriesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDonationCategoriesOperationCompleted);
            }
            this.InvokeAsync("GetDonationCategories", new object[0], this.GetDonationCategoriesOperationCompleted, userState);
        }
        
        private void OnGetDonationCategoriesOperationCompleted(object arg) {
            if ((this.GetDonationCategoriesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDonationCategoriesCompleted(this, new GetDonationCategoriesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
        
        private string detailsField;
        
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
        
        /// <remarks/>
        public string Details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetProjectCategoryDescriptionCompletedEventHandler(object sender, GetProjectCategoryDescriptionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProjectCategoryDescriptionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProjectCategoryDescriptionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetDonationCategoryDescriptionCompletedEventHandler(object sender, GetDonationCategoryDescriptionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDonationCategoryDescriptionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDonationCategoryDescriptionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetProjectCategoryIDCompletedEventHandler(object sender, GetProjectCategoryIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProjectCategoryIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProjectCategoryIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetDonationCategoryIDCompletedEventHandler(object sender, GetDonationCategoryIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDonationCategoryIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDonationCategoryIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetProjectCategoriesCompletedEventHandler(object sender, GetProjectCategoriesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProjectCategoriesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProjectCategoriesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetDonationCategoriesCompletedEventHandler(object sender, GetDonationCategoriesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDonationCategoriesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDonationCategoriesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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