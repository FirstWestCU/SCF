﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCFWeb2.CategoryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoryService.CategoryServiceSoap")]
    public interface CategoryServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategoryDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetProjectCategoryDescription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategoryDescription", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetProjectCategoryDescriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategoryDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDonationCategoryDescription(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategoryDescription", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetDonationCategoryDescriptionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategoryID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetProjectCategoryID(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategoryID", ReplyAction="*")]
        System.Threading.Tasks.Task<int> GetProjectCategoryIDAsync(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategoryID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int GetDonationCategoryID(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategoryID", ReplyAction="*")]
        System.Threading.Tasks.Task<int> GetDonationCategoryIDAsync(string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SCFWeb2.CategoryService.Category[] GetProjectCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectCategories", ReplyAction="*")]
        System.Threading.Tasks.Task<SCFWeb2.CategoryService.Category[]> GetProjectCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SCFWeb2.CategoryService.Category[] GetDonationCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDonationCategories", ReplyAction="*")]
        System.Threading.Tasks.Task<SCFWeb2.CategoryService.Category[]> GetDonationCategoriesAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Category : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string descriptionField;
        
        private string detailsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
                this.RaisePropertyChanged("Details");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CategoryServiceSoapChannel : SCFWeb2.CategoryService.CategoryServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoryServiceSoapClient : System.ServiceModel.ClientBase<SCFWeb2.CategoryService.CategoryServiceSoap>, SCFWeb2.CategoryService.CategoryServiceSoap {
        
        public CategoryServiceSoapClient() {
        }
        
        public CategoryServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoryServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetProjectCategoryDescription(int id) {
            return base.Channel.GetProjectCategoryDescription(id);
        }
        
        public System.Threading.Tasks.Task<string> GetProjectCategoryDescriptionAsync(int id) {
            return base.Channel.GetProjectCategoryDescriptionAsync(id);
        }
        
        public string GetDonationCategoryDescription(int id) {
            return base.Channel.GetDonationCategoryDescription(id);
        }
        
        public System.Threading.Tasks.Task<string> GetDonationCategoryDescriptionAsync(int id) {
            return base.Channel.GetDonationCategoryDescriptionAsync(id);
        }
        
        public int GetProjectCategoryID(string description) {
            return base.Channel.GetProjectCategoryID(description);
        }
        
        public System.Threading.Tasks.Task<int> GetProjectCategoryIDAsync(string description) {
            return base.Channel.GetProjectCategoryIDAsync(description);
        }
        
        public int GetDonationCategoryID(string description) {
            return base.Channel.GetDonationCategoryID(description);
        }
        
        public System.Threading.Tasks.Task<int> GetDonationCategoryIDAsync(string description) {
            return base.Channel.GetDonationCategoryIDAsync(description);
        }
        
        public SCFWeb2.CategoryService.Category[] GetProjectCategories() {
            return base.Channel.GetProjectCategories();
        }
        
        public System.Threading.Tasks.Task<SCFWeb2.CategoryService.Category[]> GetProjectCategoriesAsync() {
            return base.Channel.GetProjectCategoriesAsync();
        }
        
        public SCFWeb2.CategoryService.Category[] GetDonationCategories() {
            return base.Channel.GetDonationCategories();
        }
        
        public System.Threading.Tasks.Task<SCFWeb2.CategoryService.Category[]> GetDonationCategoriesAsync() {
            return base.Channel.GetDonationCategoriesAsync();
        }
    }
}
